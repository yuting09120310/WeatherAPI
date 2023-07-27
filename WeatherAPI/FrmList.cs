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
        public string FilePath = string.Empty;
        
        Dictionary<string, string> dic = new Dictionary<string, string>();


        public FrmList()
        {
            InitializeComponent();
        }

        public FrmList(string filePath)
        {
            InitializeComponent();
            this.FilePath = filePath;
        }


        private void FrmList_Load(object sender, EventArgs e)
        {
            var list = ReadJsonFile(FilePath);

            foreach (HistoryItem item in list)
            {
                string key = item.Id + "." + item.Question;

                lst_History.Items.Add(key);

                dic.Add(key, item.Result);
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


        private void lst_History_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = lst_History.SelectedItem.ToString();
            txt_Result.Text = dic[item].ToString();
        }
    }
}
