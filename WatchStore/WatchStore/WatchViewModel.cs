using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore
{
    public class WatchViewModel : INotifyPropertyChanged
    {
        private Watch watch;

        public WatchViewModel(Watch p)
        {
            watch = p;
        }

        public string Title
        {
            get { return watch.Title; }
            set
            {
                watch.Title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Company
        {
            get { return watch.Company; }
            set
            {
                watch.Company = value;
                OnPropertyChanged("Company");
            }
        }
        public int Price
        {
            get { return watch.Price; }
            set
            {
                watch.Price = value;
                OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
