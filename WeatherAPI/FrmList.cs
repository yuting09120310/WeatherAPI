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

            DataTable dt = new DataTable();
            List<string> items = new List<string>(){ "編號","問題", "回答"};
            foreach (var item in items)
            {
                dt.Columns.Add(item);
            }

            foreach (var item in list)
            {
                dt.Rows.Add(item.Id, item.Question, item.Result);
            }

            dataGridView1.DataSource = dt;
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
