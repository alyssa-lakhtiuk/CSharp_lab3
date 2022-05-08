using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace CSharp_lab3
{
    public class DateInfo : INotifyPropertyChanged, ILoaderOwner
    {
        private Person _person = new Person();
        private DateTime selectedDateFromUser;
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;
        private bool _isAdult;
        private string _sunSign;
        private string _chinesseSign;
        private bool _isBirthday;
        private int _age;

        private bool _isEnabled = true;
        private Visibility _loaderVisibility = Visibility.Collapsed;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public Visibility LoaderVisibility
        {
            get
            {
                return _loaderVisibility;
            }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? new RelayCommand<object>(_ => proceed(), CanExecute);
            }
        }

        public string FirstName
        {
            get
            {
                return _person.FirstName;
            }
            set
            {
                _person.FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _person.LastName;
            }
            set
            {
                _person.LastName = value;
            }
        }

        public string EmailAdress
        {
            get
            {
                return _person.EmailAdress;
            }
            set
            {
                _person.EmailAdress = value;
            }
        }

        public DateTime DateBirth
        {
            get
            {
                return _person.DateBirth;
            }
            set
            {
                _person.DateBirth = value;
            }
        }

        public bool IsAdult
        {
            get
            {
                return _age >= 18;
            }
            set
            {
                _isAdult = value;
            }
        }

        public bool IsBirthday
        {
            get
            {
                return _isBirthday;
            }
            set
            {
                _isBirthday = value;
            }
        }


        public string SunSign
        {
            get
            {
                return _sunSign;
            }
            set
            {
                _sunSign = value;
                OnPropertyChanged();
            }
        }

        public string ChineseSign
        {
            get
            {
                return _chinesseSign;
            }
            set
            {
                _chinesseSign = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }
        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_person.FirstName) && !String.IsNullOrWhiteSpace(_person.LastName);
        }

        enum WestSigns
        {
            Aries = 1,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius,
            Capricorn,
            Aquarius,
            Pisces
        }

        enum EastSigns
        {
            Rat = 1,
            Ox,
            Tiger,
            Rabbit,
            Dragon,
            Snake,
            Horse,
            Goat,
            Monkey,
            Rooster,
            Dog,
            Pig
        }

        public DateTime SelectedDateFromUser
        {
            get
            {
                return selectedDateFromUser;
            }
            set
            {
                selectedDateFromUser = value;
            }
        }

        public bool dateValid()
        {
            DateTime todayDate = DateTime.Today;
            int difference = todayDate.Year - SelectedDateFromUser.Year;
            //if (difference > 135 || difference < 0)
            //{
            //    MessageBox.Show("The date is wrong");
            //    return false;
            //}
            if (difference > 135)
            {
                throw new exceptionsFold.DateFarInPast(difference);
            } else if (difference < 0)
            {
                throw new exceptionsFold.DateInFuture(difference);
            }
            return true;
        }

        public void countAgeOfUser()
        {
            Thread.Sleep(1500);
            DateTime? todayDate = DateTime.Today;
            int age = todayDate.Value.Year - selectedDateFromUser.Year;
            if ((todayDate.Value.Day < selectedDateFromUser.Day && todayDate.Value.Month == selectedDateFromUser.Month) || (todayDate.Value.Month < selectedDateFromUser.Month))
            {
                age--;
            }
            Age = age;
        }

        public void countWestAstroSign()
        {
            Thread.Sleep(2000);
            int month = SelectedDateFromUser.Month;
            int day = SelectedDateFromUser.Day;
            WestSigns astroSign;
            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
            {
                astroSign = WestSigns.Aries;
            } else if ((month == 4 && day >= 21) || (month == 5 && day <= 21))
            {
                astroSign = WestSigns.Taurus;
            } else if ((month == 5 && day >= 22) || (month == 6 && day <= 21))
            {
                astroSign = WestSigns.Gemini;
            } else if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
            {
                astroSign = WestSigns.Cancer;
            } else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                astroSign = WestSigns.Leo;
            } else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            {
                astroSign = WestSigns.Virgo;
            } else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                astroSign = WestSigns.Libra;
            } else if ((month == 10 && day >= 23) || (month == 11 && day <= 22))
            {
                astroSign = WestSigns.Scorpio;
            } else if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
            {
                astroSign = WestSigns.Sagittarius;
            } else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
            {
                astroSign = WestSigns.Capricorn;
            } else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                astroSign = WestSigns.Aquarius;
            } else
            {
                astroSign = WestSigns.Pisces;
            }
            SunSign = astroSign.ToString();
        }

        public void countEastAstroSign()
        {
            Thread.Sleep(2000);
            int numOfSign = (SelectedDateFromUser.Year - 1900) % 12 + 1;
            EastSigns astroSign = (EastSigns)numOfSign;
            ChineseSign = astroSign.ToString();
        }

        public void isBirtDayToday()
        {
            Thread.Sleep(1000);
            DateTime todayDate = DateTime.Today;
            if (selectedDateFromUser.Day == todayDate.Day && selectedDateFromUser.Month == todayDate.Month)
            {
                MessageBox.Show("Happy Birthady! Be Happy and free!");
                IsBirthday = true;
                return;
            }
            else IsBirthday = false;
        }

        private void check_email()
        {
            Regex regex = new Regex("^\\S+@\\S+\\.\\S+$");
            if (!regex.IsMatch(_person.EmailAdress))
                throw new exceptionsFold.WrongEmail(_person.EmailAdress);
        }

        private async void proceed()
        {
            bool check = false;
            try
            {
                check = dateValid();
            }
            catch (Exception ex)
            {
                if (ex is exceptionsFold.DateFarInPast || ex is exceptionsFold.DateInFuture)
                {
                    MessageBox.Show($"Exception: {ex.Message}");
                }
            }
            try
            {
                check_email();
            }
            catch (exceptionsFold.WrongEmail ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
            if (check)
            {
                try
                {
    
                    //LoaderManager.Instance.ShowLoader();
                   
                    await Task.Run(() => countEastAstroSign());
                    await Task.Run(() => countAgeOfUser());
                    await Task.Run(() => countWestAstroSign());
                    await Task.Run(() => isBirtDayToday());


                } catch (Exception ex)
                {
                    MessageBox.Show($"Something went wrong: {ex.Message}");
                    return;
                } finally
                {
                    //LoaderManager.Instance.HideLoader();
                }
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ??= new RelayCommand<object>(_ => Environment.Exit(0));
            }
        }


        //private void update(object? sender, PropertyChangedEventArgs e)
        //{
        //    if(e.PropertyName == nameof(SelectedDateFromUser))
        //    {
        //        //PropertyChanged?.Invoke(this, nameof(ChineseCalendar));
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
