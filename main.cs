using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab01
{
    class Main : INotifyPropertyChanged
    {
        private int _age;
        private string _horoscope;
        private DateTime _date;

        private string[] _zodiac = new string[]
        {
            "Rat", "Bull",
            "Tiger", "Bunny",
            "Dragon", "Snake",
            "Horse", "Goat",
            "Monkey", "Rooster",
            "Dog", "Pig"
        };

        public int Age
        {
            get
            {
                return _age;
            }
        }

        public string Horoscope
        {
            get
            {
                return _horoscope;
            }
        }
        public DateTime GetDate
        {
            set
            {
                _date = value;
                AsyncCountAge();
                createHoroscope();
                OnPropertyChanged();
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(Horoscope));
            }
        }

        private void createHoroscope()
        {
            _horoscope = _zodiac[(_date.Year - 4) % 12];
        }

        private void CountAge()
        {
            _age = (DateTime.Today - _date).Days / 365;
            if (_age > 135)
            {
                MessageBox.Show("There's some kind of a mistake, you can't be so old.");
            }
            else if (_date > DateTime.Today)
            {
                MessageBox.Show("There's some kind of a mistake, you have to exist.");
            }
            else if (_date == DateTime.Today)
            {
                MessageBox.Show("Happy Birthday! Congratulations!");
            }
        }
        private async void AsyncCountAge()
        {
            await Task.Run(() => CountAge());
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
