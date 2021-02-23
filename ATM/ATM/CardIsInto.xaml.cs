using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ATM
{
    /// <summary>
    /// Логика взаимодействия для CardIsInto.xaml
    /// </summary>
    public partial class CardIsInto : Window
    {
        public DateTime CurrentTime
        {
            get { return DateTime.Now; }
        }

        public CardIsInto()
        {
            InitializeComponent();
        }


        private void CardIsInto_OnLoaded(object sender, RoutedEventArgs e)
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) => { lblCurrentTime.Text = CurrentTime.ToShortDateString() + "\n" + CurrentTime.ToShortTimeString(); };
        }
    }
}
