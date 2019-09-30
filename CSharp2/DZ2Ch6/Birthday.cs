using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DZ2Ch6
{
    [Serializable]
    [XmlRoot]
    public class Birthdaies
    {
        [XmlArray]
        public List<Birthday> List { get; set; }
    }

    [Serializable]
    [XmlType]
    public class Birthday : INotifyPropertyChanged
    {
        private string name, lastName, middleName;
        private int day, month, year;

        [XmlElement]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        [XmlElement]
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        [XmlElement]
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        [XmlElement]
        public int Day
        {
            get { return day; }
            set
            {
                day = value;
                OnPropertyChanged("Day");
            }
        }

        [XmlElement]
        public int Month
        {
            get { return month; }
            set
            {
                month = value;
                OnPropertyChanged("Month");
            }
        }

        [XmlElement]
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        public Birthday()
        { }

        public Birthday(string name, string lastName, string middleName, int day, int month, int year)
        {
            Name = name;
            LastName = lastName;
            MiddleName = middleName;
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}.{2} {3} {4} {5}", Day.ToString(), Month.ToString(), Year.ToString(), LastName, Name, MiddleName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
