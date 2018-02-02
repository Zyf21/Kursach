using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenPop.Pop3;

namespace Kyrsach
{
    public partial class PopForm : Form
    {
        // We want to download all messages
        List<OpenPop.Mime.Message> allMessages;

        public PopForm()
        {
            InitializeComponent();
        }

        private List<OpenPop.Mime.Message> FetchAllMessages(string hostname, int port, bool useSsl, string username, string password)
        {
            // The client disconnects from the server when being disposed
            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(hostname, port, useSsl);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                // Get the number of messages in the inbox
                int messageCount = client.GetMessageCount();

                // We want to download all messages
                allMessages = new List<OpenPop.Mime.Message>(messageCount);

                // Messages are numbered in the interval: [1, messageCount]
                // Ergo: message numbers are 1-based.
                // Most servers give the latest message the highest number
                for (int i = messageCount; i > 0; i--)
                {
                    allMessages.Add(client.GetMessage(i));
                }

                // Now return the fetched messages
                return allMessages;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = FetchAllMessages("pop.mail.ru", 995, true, textBox1.Text, textBox2.Text);
            foreach (var item in a)
            {
                listBox1.Items.Add(string.Format("{0} [{1}]",item.Headers.From.Address.ToString(),item.Headers.Subject));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = allMessages[listBox1.SelectedIndex].Headers.Subject;
            textBox4.Text = allMessages[listBox1.SelectedIndex].Headers.DateSent.ToShortDateString();
            if (allMessages[listBox1.SelectedIndex].MessagePart.MessageParts[0].Body != null)
                textBox5.Text = Encoding.UTF8.GetString(allMessages[listBox1.SelectedIndex].MessagePart.MessageParts[0].Body);
            else
                textBox5.Text = "Текст сообщения отсутствует!";
        }
    }
}
