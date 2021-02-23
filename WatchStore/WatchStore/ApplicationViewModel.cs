using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Watch selectedPhone;

        public ObservableCollection<Watch> Phones { get; set; }
        public Watch SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<Watch>
            {
                new Watch { Title="A168WEM-7VT", Company = "Casio", Price = 955 },
                new Watch {Title="Watch Series 3", Company="Apple", Price = 4500 },
                new Watch {Title="Pro Diver", Company="Rolex", Price=280000 },
                new Watch {Title="Seamaster", Company="Omega", Price=48000 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
