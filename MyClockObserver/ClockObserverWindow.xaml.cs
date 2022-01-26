using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MyClockObserver
{
    /// <summary>
    /// Interaction logic for ClockObserverWindow.xaml
    /// </summary>
    public partial class ClockObserverWindow : Window, INotifyPropertyChanged, IObserver
    {
        private string time = string.Empty;
        private readonly ClockSubject clockSubject;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string? Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged(nameof(time));
            }
        }
        public ClockObserverWindow(ClockSubject clockSubject)
        {
            InitializeComponent();
            DataContext = this;
            this.clockSubject = clockSubject;
            this.clockSubject.Attach(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Update()
        {
            // Check if right thread is being used
            if (!CheckAccess())
            {
                Dispatcher.Invoke(Update);
            }
            Time = clockSubject.Time;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            clockSubject.Detach(this);
        }
    }
}
