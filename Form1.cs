using Microsoft.Data.Sqlite;
using Newtonsoft.Json.Linq;

namespace Wuthering_Waves_Fps_Unlocker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     

        private void connect_db(string dbPath)
        {
            string connectionString = $"Data Source={dbPath};";
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                // 查询 Key 为 GameQualitySetting 的行
                string query = "SELECT Value FROM LocalStorage WHERE Key = 'GameQualitySetting';";
                using (SqliteCommand command = new SqliteCommand(query, conn))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string jsonData = reader.GetString(0);
                            //解析JSON
                            JObject jsonObj = JObject.Parse(jsonData);
                            //提取KeyCustomFrameRate的值
                            int? KeyCustomFrameRate = jsonObj.Value<int?>("KeyCustomFrameRate");
                            if (KeyCustomFrameRate.HasValue)
                            {
                                textBox2.Text = KeyCustomFrameRate.Value.ToString();
                            }
                        }
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Title = "请选择",
                Filter = "数据库文件 (*.db)|*.db|所有文件 (*.*)|*.*"
            };
            //显示对话框并检查是否选择了文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取文件路径
                string filePath = openFileDialog.FileName;
                //将文件路径显示在文本框中
                textBox1.Text = filePath;
                connect_db(filePath);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请先选择数据库文件");
                return;
            }
            //如果帧率为空，提示用户输入
            if (textBox2.Text == "")
            {
                MessageBox.Show("请输入帧率！");
                return;
            }

            //如果帧率不是数字，提示用户输入数字
            if (!int.TryParse(textBox2.Text, out _))
            {
                MessageBox.Show("请输入数字！");
                return;
            }
            //如果帧率不在1-120之间，提示用户输入1-120之间的数字
            if (int.Parse(textBox2.Text) < 1 || int.Parse(textBox2.Text) > 120)
            {
                MessageBox.Show("请输入1-120之间的数字！");
                return;
            }

            //修改数据库的值，只修改KeyCustomFrameRate的值JSON别的不动
            string connectionString = $"Data Source={textBox1.Text};";
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Value FROM LocalStorage WHERE Key = 'GameQualitySetting';";
                using (SqliteCommand command = new SqliteCommand(query, conn))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string jsonData = reader.GetString(0);
                            JObject jsonObj = JObject.Parse(jsonData);
                            jsonObj["KeyCustomFrameRate"] = int.Parse(textBox2.Text);
                            string newJsonData = jsonObj.ToString();
                            //更新数据库
                            string update = $"UPDATE LocalStorage SET Value = '{newJsonData}' WHERE Key = 'GameQualitySetting';";
                            using (SqliteCommand updateCommand = new SqliteCommand(update, conn))
                            {
                                updateCommand.ExecuteNonQuery();
                            }
                            MessageBox.Show("修改成功！请打开游戏查看！");

                        }
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
