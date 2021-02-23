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
        private Watch selectedWatch;

        public ObservableCollection<Watch> Watches { get; set; }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                       (addCommand = new RelayCommand(obj =>
                       {
                           Watch watch = new Watch();
                           Watches.Insert(0, watch);
                           SelectedWatch = watch;
                       }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                       (removeCommand = new RelayCommand(obj =>
                           {
                               Watch watch = obj as Watch;
                               if (watch != null)
                               {
                                   Watches.Remove(watch);
                               }
                           },
                           (obj) => Watches.Count > 0));
            }
        }


        public Watch SelectedWatch
        {
            get { return selectedWatch; }
            set
            {
                selectedWatch = value;
                OnPropertyChanged("SelectedWatch");
            }
        }

        public ApplicationViewModel()
        {
            Watches = new ObservableCollection<Watch>
            {
                new Watch { Title="A168WEM-7VT", Company = "Casio", Price = 955, Icon = @"D:\projects\MyProjects\WatchStore\WatchStore\Images\gsk-a168wem7vt-na-na-5.jpg"},
                new Watch {Title="Watch Series 3", Company="Apple", Price = 4500, Icon = @"D:\projects\MyProjects\WatchStore\WatchStore\Images\1817618635.jpg"},
                new Watch {Title="Pro Diver", Company="Invicta", Price=2000, Icon = @"D:\projects\MyProjects\WatchStore\WatchStore\Images\3fd1eaf6d5b1325b132d2c97d9b417f0.jpg"},
                new Watch {Title="Seamaster", Company="Omega", Price=48000, Icon = @"D:\projects\MyProjects\WatchStore\WatchStore\Images\Omega21-Soldier_28a5e176-5585-4b81-aacb-5ae20cbc9967_1600x1600.jpg"}
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
