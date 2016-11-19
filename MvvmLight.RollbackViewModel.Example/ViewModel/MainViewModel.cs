using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace MvvmLight.RollbackViewModel.Example.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        private MainWindow _mainWindow
        {
            get
            {
                return App.Instance.GetMainWindow();
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            this.RegisterCommands();
        }

        private void RegisterCommands()
        {
            this.SwitchMainFlyoutCommand = new RelayCommand(this.DoSwitchMainFlyoutCommand);
            this.AppOffMenuItemCommand = new RelayCommand(this.DoAppOffMenuItemCommand);
            this.SettingMenuItemCommand = new RelayCommand(this.DoSettingMenuItemCommand);
        }

        private void DoSwitchMainFlyoutCommand()
        {
            this._mainWindow.MainFlyout.IsOpen = !this._mainWindow.MainFlyout.IsOpen;
        }

        public RelayCommand SwitchMainFlyoutCommand { get; private set; }

        private void DoAppOffMenuItemCommand()
        {
            Application.Current.Shutdown();
        }

        public RelayCommand AppOffMenuItemCommand { get; private set; }

        private void DoSettingMenuItemCommand()
        {
            SettingWindow settingWindow = new SettingWindow();
            settingWindow.Show();
        }

        public RelayCommand SettingMenuItemCommand { get; private set; }

    }
}