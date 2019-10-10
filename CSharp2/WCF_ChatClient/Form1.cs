using System;
using System.Windows.Forms;

namespace WCF_ChatClient
{
    public partial class Form1 : Form
    {
        private localhost.ChatService cs = new localhost.ChatService();

        public Form1()
        {
            InitializeComponent();
            tbChat.Text = cs.GetChat();
            tbUsers.Text = cs.GetUsers();
            timer.Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text != "Del")
            {
                cs.Say("anonim: " + tbSend.Text);
                tbChat.Text = cs.GetChat();
            }
            else
            {
                string text = string.IsNullOrEmpty(tbUser.Text) ? "anonim: " + tbSend.Text : tbUser.Text + ": " + tbSend.Text;

                cs.Say(text);
                tbChat.Text = cs.GetChat();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tbChat.Text = cs.GetChat();
            tbUsers.Text = cs.GetUsers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUser.Text)) return;

            if (btnAdd.Text != "Del")
            {
                cs.AddUser(tbUser.Text);
                tbUsers.Text = cs.GetUsers();

                tbUser.Enabled = false;

                btnAdd.Text = "Del";
            }
            else
            {
                cs.DelUser(tbUser.Text);
                tbUsers.Text = cs.GetUsers();

                tbUser.Enabled = true;

                btnAdd.Text = "Add";
            }
        }
    }
}
