using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DZ2Ch6
{
    public partial class Form1 : Form
    {
        private List<Birthday> list = new List<Birthday>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            list.Add(new Birthday(tbName.Text, tbLastName.Text, tbMiddleName.Text, calendar.SelectionStart.Day, calendar.SelectionStart.Month, calendar.SelectionStart.Year));
            listBox.DataSource = list;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            tbDate.Text = calendar.SelectionStart.ToShortDateString();
        }
    }
}
