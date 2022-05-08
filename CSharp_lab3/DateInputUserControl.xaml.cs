using System;
using System.Windows;
using System.Windows.Controls;

namespace CSharp_lab3
{
    public partial class DateInputUserControl : UserControl
    {
        private DateInfo dateFromUser;

        public DateInputUserControl()
        {
            InitializeComponent();
            dateFromUser = new DateInfo();
            DataContext = dateFromUser;
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = DatePicker1.SelectedDate;
            MessageBox.Show(selectedDate.Value.Date.ToShortDateString());
        }


        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    bool check = dateFromUser.dateValid();
        //    if (check)
        //    {
        //        AgeOfUser.Text = dateFromUser.countAgeOfUser();
        //        WestSign.Text = dateFromUser.countWestAstroSign();
        //        EastSign.Text = dateFromUser.countEastAstroSign();
        //    }
        //}
    }
}
