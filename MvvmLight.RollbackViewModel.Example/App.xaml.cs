using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmLight.RollbackViewModel.Example
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static App Instance { get; private set; }

        public readonly String AppDirectory;

        public App()
            :base()
        {
            Instance = this;

            this.AppDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (!this.AppDirectory.EndsWith("\\"))
                this.AppDirectory = this.AppDirectory + "\\";
        }

        public virtual void SwitchThemeColor(String baseColor, String accentColor)
        {
            Accent accent = ThemeManager.GetAccent(accentColor);
            AppTheme theme = ThemeManager.GetAppTheme(baseColor);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme);
        }

        public MainWindow GetMainWindow()
        {
            return ((MainWindow)Application.Current.MainWindow);
        }
    }
}