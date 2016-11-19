using GalaSoft.MvvmLight.Ioc;
using MahApps.Metro.Controls;
using MvvmLight.RollbackViewModel.Example.Interfaces;
using MvvmLight.RollbackViewModel.Example.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MvvmLight.RollbackViewModel.Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Setting s = SimpleIoc.Default.GetInstance<ISettingService>().GetSetting();
            App.Instance.SwitchThemeColor(s.ThemeBaseColor, s.AccentColor);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            SimpleIoc.Default.GetInstance<ISettingService>().SaveSetting();
            base.OnClosing(e);
        }
    }
}
