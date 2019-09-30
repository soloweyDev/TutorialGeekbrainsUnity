using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DZ2Ch6
{
    public partial class Form1 : Form
    {
        string path = "birthday.xml";
        Birthdaies birthdaies = new Birthdaies();

        public Form1()
        {
            InitializeComponent();
            birthdaies.List = new List<Birthday>();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            listBox.DataSource = null;
            birthdaies.List.Add(new Birthday(tbName.Text, tbLastName.Text, tbMiddleName.Text, calendar.SelectionStart.Day, calendar.SelectionStart.Month, calendar.SelectionStart.Year));
            listBox.DataSource = birthdaies.List;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            tbDate.Text = calendar.SelectionStart.ToShortDateString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Birthdaies));
                xml.Serialize(sw, birthdaies);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Birthdaies));
                var temp = xml.Deserialize(sr) as Birthdaies;

                foreach (var birthday in temp.List)
                {
                    birthdaies.List.Add(new Birthday(birthday.Name, birthday.LastName, birthday.MiddleName, birthday.Day, birthday.Month, birthday.Year));
                }

                listBox.DataSource = null;
                listBox.DataSource = birthdaies.List;
            }
        }
    }
}
