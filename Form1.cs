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
                // ��ѯ Key Ϊ GameQualitySetting ����
                string query = "SELECT Value FROM LocalStorage WHERE Key = 'GameQualitySetting';";
                using (SqliteCommand command = new SqliteCommand(query, conn))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string jsonData = reader.GetString(0);
                            //����JSON
                            JObject jsonObj = JObject.Parse(jsonData);
                            //��ȡKeyCustomFrameRate��ֵ
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
                Title = "��ѡ��",
                Filter = "���ݿ��ļ� (*.db)|*.db|�����ļ� (*.*)|*.*"
            };
            //��ʾ�Ի��򲢼���Ƿ�ѡ�����ļ�
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //��ȡ�ļ�·��
                string filePath = openFileDialog.FileName;
                //���ļ�·����ʾ���ı�����
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
                MessageBox.Show("����ѡ�����ݿ��ļ�");
                return;
            }
            //���֡��Ϊ�գ���ʾ�û�����
            if (textBox2.Text == "")
            {
                MessageBox.Show("������֡�ʣ�");
                return;
            }

            //���֡�ʲ������֣���ʾ�û���������
            if (!int.TryParse(textBox2.Text, out _))
            {
                MessageBox.Show("���������֣�");
                return;
            }
            //���֡�ʲ���1-120֮�䣬��ʾ�û�����1-120֮�������
            if (int.Parse(textBox2.Text) < 1 || int.Parse(textBox2.Text) > 120)
            {
                MessageBox.Show("������1-120֮������֣�");
                return;
            }

            //�޸����ݿ��ֵ��ֻ�޸�KeyCustomFrameRate��ֵJSON��Ĳ���
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
                            //�������ݿ�
                            string update = $"UPDATE LocalStorage SET Value = '{newJsonData}' WHERE Key = 'GameQualitySetting';";
                            using (SqliteCommand updateCommand = new SqliteCommand(update, conn))
                            {
                                updateCommand.ExecuteNonQuery();
                            }
                            MessageBox.Show("�޸ĳɹ��������Ϸ�鿴��");

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
