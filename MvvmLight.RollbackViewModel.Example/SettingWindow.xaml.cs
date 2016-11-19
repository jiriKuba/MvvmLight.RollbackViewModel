using GalaSoft.MvvmLight.Ioc;
using MvvmLight.RollbackViewModel.Example.Base;
using MvvmLight.RollbackViewModel.Example.ViewModel;
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

namespace MvvmLight.RollbackViewModel.Example
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : BaseMainChildWindow
    {
        private SettingViewModel _settingViewModel;

        public SettingWindow()
            : base()
        {
            InitializeComponent();
            this._settingViewModel = SimpleIoc.Default.GetInstance<SettingViewModel>();
            this.DataContext = this._settingViewModel;
        }

        protected override void OnClosed(EventArgs e)
        {
            if (this._settingViewModel.WasChangeMade())
                this._settingViewModel.Rollback();

            base.OnClosed(e);
        }
    }
}