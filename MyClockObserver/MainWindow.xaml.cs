﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyClockObserver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClockSubject subject = new();
        private bool running = true;

        public MainWindow()
        {
            InitializeComponent();
            new Thread(() =>
            {
                while (running)
                {
                    subject.Time = TimeOnly.FromDateTime(DateTime.Now).ToString("r");
                    Thread.Sleep(1000);
                }
            }).Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new ClockObserverWindow(subject);
            window.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            running = false;
        }
    }
}
