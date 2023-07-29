using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherAPI
{
    public partial class FrmList : Form
    {
        // 檔案 + 檔案路徑的字典
        Dictionary<string, string> DicFileNamePath = new Dictionary<string, string>();

        // 左邊事件
        Dictionary<string, string> DicHistoryItem = new Dictionary<string, string>();


        public FrmList()
        {
            InitializeComponent();
        }


        private void FrmList_Load(object sender, EventArgs e)
        {
            // 取得HistoryPath 資料夾內的所有檔案
            string[] historyFiles = Directory.GetFiles(Application.StartupPath + "/HistoryPath");

            // 利用字典 將檔名跟路徑配對
            foreach (string filePath in historyFiles)
            {
                string fileName = Path.GetFileName(filePath);
                DicFileNamePath.Add(fileName, filePath);
            }

            // 把字典內的所有Key 加入於ComboBox的選項
            foreach (var item in DicFileNamePath.Keys)
            {
                cmb_Date.Items.Add(item);
            }
        }


        // 左邊選單事件
        private void lst_History_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = lst_History.SelectedItem.ToString();
            txt_Result.Text = DicHistoryItem[item].ToString();
        }


        // 時間下拉選單事件
        private void cmb_Date_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 清除字典內容 以及 清空選單
            DicHistoryItem.Clear();
            lst_History.Items.Clear();


            // 讀取使用者選擇的日期
            var list = ReadJsonFile(DicFileNamePath[cmb_Date.SelectedItem.ToString()]);

            foreach (HistoryItem item in list)
            {
                string key = item.Id + "." + item.Question;

                lst_History.Items.Add(key);

                DicHistoryItem.Add(key, item.Result);
            }
        }


        // 從檔案讀取現有的 JSON 資料
        private List<HistoryItem> ReadJsonFile(string filePath)
        {
            List<HistoryItem> historyList = new List<HistoryItem>();

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                historyList = JsonConvert.DeserializeObject<List<HistoryItem>>(jsonString) ?? new List<HistoryItem>();
            }

            return historyList;
        }
    }
}
