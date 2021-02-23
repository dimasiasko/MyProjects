using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Path = System.IO.Path;

namespace MusicPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool userIsDraggingSlider = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lstSongs.IsMouseOver)
                return;
            else
            {
                DragMove();
            }
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnRandom_OnClick(object sender, RoutedEventArgs e)
        {
            if (btnRandom.IsChecked == false)
                CheckedIcon.Kind = PackIconKind.ShuffleDisabled;
            else
            {
                CheckedIcon.Kind = PackIconKind.Shuffle;
                btnRandom.ToolTip = "Turn To Off Random Mode";
            }
        }

        private void BtnClearAll_OnClick(object sender, RoutedEventArgs e)
        {
            SystemSounds.Exclamation.Play();
            var result = MessageBox.Show("If you turn 'Yes', you will delete ALL tracks",
                "Are you really want to delete ALL tracks?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (result == MessageBoxResult.Yes)
            {
                DefaultValues();
                MessageBox.Show("Tracks deleted");
            }
            else
                return;
        }

        private void DefaultValues()
        {
            mediaPlayer.Close();
            SelectedNamesSongs.Clear();
            SelectedSongs.Clear();
            lblSongname.Text = "Выберите треки";
            lstSongs.SelectedIndex = -1;
            lblCurrenttime.Text = "0:00";
            lblMusicLength.Text = "0;00";
            TimerSlider.Value = 0;
        }
        private void BtnHide_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private ObservableCollection<string> _selectedSongs = new ObservableCollection<string>();

        public ObservableCollection<string> SelectedSongs
        {
            get { return _selectedSongs; }
            set { _selectedSongs = value; }
        }
        private ObservableCollection<string> _selectedNamesSongs = new ObservableCollection<string>();

        public ObservableCollection<string> SelectedNamesSongs
        {
            get { return _selectedNamesSongs; }
            set { _selectedNamesSongs = value; }
        }

        private void BtnFile_OnClick(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\"; // изначальная папка в окне
            openFileDialog.Filter = "All Supported Audio (*.mp3;...) | *.mp3; *.wav; | All files (*.*) | *.*"; // фильтр для лучшего поиска музыки                   
            
            openFileDialog.Title = "Выберите свою музыку"; // установка имени диалогового окна
            // для выбора нескольких файлов
            openFileDialog.Multiselect = true;


            if (openFileDialog.ShowDialog() == true)
            {
                // временный массив для сохранения имени и пути выбраных файлов
                string[] pathsNew = openFileDialog.FileNames;

                for (int i = 0; i < pathsNew.Length; i++)
                {
                    switch (System.IO.Path.GetExtension(pathsNew[i])) // проверка входящего формата
                    {
                        case ".mp3":
                        case ".wav":
                            SelectedNamesSongs.Add(System.IO.Path.GetFileNameWithoutExtension(pathsNew[i]));
                            SelectedSongs.Add(pathsNew[i]);
                            // Отобразить имена треков в листбоксе
                            break;
                        default:
                            MessageBox.Show($"Файл {pathsNew[i]} имеет неверный формат !");
                            break;
                    }
                }
            }
            else
                MessageBox.Show("Выберите файлы для проигрывания!");
            lstSongs.ItemsSource = SelectedSongs;
            
        }

        private MediaPlayer mediaPlayer = new MediaPlayer();

        private void LstSongs_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSongs.SelectedIndex != -1)
            {
                mediaPlayer.Open(new Uri((string)lstSongs.SelectedItem, UriKind.RelativeOrAbsolute));
                mediaPlayer.Play();

                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();

                lblSongname.Text = SelectedNamesSongs[lstSongs.SelectedIndex];
            }
            else
                return;

        }

        void timer_Tick(object sender, EventArgs e)
        {
            if ((mediaPlayer.Source != null) && (mediaPlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                TimerSlider.Minimum = 0;
                TimerSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                TimerSlider.Value = mediaPlayer.Position.TotalSeconds;
                lblMusicLength.Text = mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
            }
        }
        private void BtnPlay_OnClick(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void BtnStop_OnClick(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void BtnPause_OnClick(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void BtnPNext_OnClick(object sender, RoutedEventArgs e)
        {
            if (btnRandom.IsChecked == false)
            {
                if ((lstSongs.SelectedIndex + 1) >= SelectedSongs.Count)
                    lstSongs.SelectedIndex = 0;
                else
                    lstSongs.SelectedIndex += 1;
            }
            else
            {
                Random random = new Random();
                int newIndex = random.Next(SelectedSongs.Count);

                lstSongs.SelectedIndex = newIndex;
            }

            
        }

        private void BtnPRewind_OnClick(object sender, RoutedEventArgs e)
        {
            if ((lstSongs.SelectedIndex - 1) == -1)
                lstSongs.SelectedIndex = SelectedSongs.Count - 1;
            else
                lstSongs.SelectedIndex -= 1;
        }

        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            mediaPlayer.Position = TimeSpan.FromSeconds(TimerSlider.Value);
        }

        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblCurrenttime.Text = TimeSpan.FromSeconds(TimerSlider.Value).ToString(@"mm\:ss");
        }
    }
}
