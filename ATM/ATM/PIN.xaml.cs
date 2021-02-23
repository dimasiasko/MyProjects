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
    /// Логика взаимодействия для PIN.xaml
    /// </summary>
    public partial class PIN : Window
    {
        public PIN()
        {
            InitializeComponent();
        }


        private void BtnToConfirm_OnClick(object sender, RoutedEventArgs e)
        {
            int password;

            if (int.TryParse(passwordInput.Password, out password))
            {
                CardIsInto cardIsInto = new CardIsInto();
                cardIsInto.Show();
                this.Close();
                
            }
        }
    }
}
