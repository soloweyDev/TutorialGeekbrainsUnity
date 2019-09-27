using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DZ2Ch6
{
    class Birthday : INotifyPropertyChanged
    {
        private string name, lastName, middleName;
        private int day, month, year;

        string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        int Day
        {
            get { return day; }
            set
            {
                day = value;
                OnPropertyChanged("Day");
            }
        }

        int Month
        {
            get { return month; }
            set
            {
                month = value;
                OnPropertyChanged("Month");
            }
        }

        int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

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
