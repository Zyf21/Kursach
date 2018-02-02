using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace Kyrsach
{
    public partial class FormSMTP : Form
    {
        string _path;
        public FormSMTP(string path)
        {
            InitializeComponent();
            _path = path;

            FileInfo info = new FileInfo(path);
            textBox4.Text = info.Name;
            textBox6.Text = info.FullName;
            textBox7.Text = (info.Length / (long)1024).ToString();
            textBox8.Text = info.LastWriteTime.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
                if(checkedListBox1.GetItemChecked(i))
                {
                    MessSend(checkedListBox1.Items[i].ToString());
                }
			}
            
            
        }

        private void MessSend(string emailTo)
        {
            SmtpClient client = new SmtpClient(comboBox1.Text.ToString(), int.Parse(textBox3.Text));

            client.Credentials = new NetworkCredential(textBox1.Text, textBox2.Text);

            client.EnableSsl = checkBox1.Checked;

            MailMessage mess = new MailMessage(textBox1.Text, emailTo , textBox9.Text, textBox10.Text);
           
            mess.Attachments.Add(new Attachment(_path));

            try
            {
                client.Send(mess);
                mess.Dispose();
                MessageBox.Show("Сообщение отправлено!", "Успех!", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
               
                //File.Delete(files[0]);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Сообщение небыло отправлено!", "Ошибка отправки!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textBox5.Text, false);
            textBox5.Text = string.Empty;
        }
    }
}
