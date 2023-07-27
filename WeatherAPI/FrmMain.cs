﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace WeatherAPI
{
    public partial class FrmMain : Form
    {

        string FilePath = string.Empty;

        List<string> City = new List<string>() { "臺北市", "新北市", "基隆市", "新竹市" };

        public FrmMain()
        {
            InitializeComponent();
        }


        // 表單載入
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 設定程式在螢幕正中間
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);

            // 防止程式重覆執行
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] myProcess = Process.GetProcessesByName(processName);
            if (myProcess.Length > 1) { Environment.Exit(0); }


            comboBox1.DataSource = City;

            // 取得檔案路徑
            FilePath = checkFile();
        }


        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string url = "https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-C0032-001?Authorization=CWB-E5AE9AD2-A2D9-4152-8EF3-4195DF68C9EB";
            if (comboBox1.Text.Length > 0)
            {
                url += "&locationName=" + comboBox1.Text;
            }
            url += "&elementName=MinT";

            // 取得API回傳結果
            var result = await GetResponseFromUrl(url);
            // 將取回的結果轉成Json Object
            JObject getData = JsonConvert.DeserializeObject<JObject>(result);

            // 取得描述的標題
            JToken jsonDatasetDescription = getData["records"]["datasetDescription"];
            // 取得回傳結果的時間
            JToken jsonTime = getData["records"]["location"][0]["weatherElement"][0]["time"];

            // 從檔案讀取現有的 JSON 資料
            List<HistoryItem> historyList = ReadJsonFile(FilePath);


            // 新增物件
            int newId = GetNextId(historyList);
            historyList.Add(new HistoryItem
            {
                Id = newId,
                Question = comboBox1.Text + Convert.ToString(jsonDatasetDescription),
                Result = Convert.ToString(jsonTime),
            });

            foreach(var item in jsonTime)
            {
                txt_result.Text += $"時間 : {Convert.ToString(item["startTime"])} - {Convert.ToString(item["endTime"])} 溫度為 { Convert.ToString(item["parameter"]["parameterName"]) + Convert.ToString(item["parameter"]["parameterUnit"]) + Environment.NewLine}";
            }

            // 將更新後的 JSON 資料寫入檔案
            WriteJsonFile(FilePath, historyList);

        }


        // 取得並判斷資料夾 檔案是否存在
        private string checkFile()
        {
            string HistoryPath = Application.StartupPath + "/HistoryPath";

            // 檢查檔案 資料夾是否存在
            if (!Directory.Exists(HistoryPath))
            {
                Directory.CreateDirectory(HistoryPath);
            }

            string filePath = HistoryPath + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".json";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            return filePath;
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


        // 將 JSON 資料寫入檔案
        private void WriteJsonFile(string filePath, List<HistoryItem> historyList)
        {
            string jsonString = JsonConvert.SerializeObject(historyList, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }


        // 取得下一個可用的 Id
        static int GetNextId(List<HistoryItem> historyList)
        {
            int maxId = 0;

            if (historyList != null && historyList.Count > 0)
            {
                foreach (var item in historyList)
                {
                    if (item.Id > maxId)
                    {
                        maxId = item.Id;
                    }
                }
            }

            return maxId + 1;
        }


        // 呼叫GPT 返回結果
        public static async Task<string> GetResponseFromUrl(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        // 如果回應不成功，您可以在這裡進行處理，例如拋出例外或回傳錯誤訊息。
                        // 這裡僅示範回傳空字串。
                        return string.Empty;
                    }
                }
                catch (HttpRequestException e)
                {
                    // 發生例外時的處理
                    // 這裡僅示範回傳錯誤訊息。
                    return e.Message;
                }
            }
        }


        private void btn_History_Click(object sender, EventArgs e)
        {
            FrmList frmList = new FrmList(FilePath);
            frmList.ShowDialog();
        }
    }
}