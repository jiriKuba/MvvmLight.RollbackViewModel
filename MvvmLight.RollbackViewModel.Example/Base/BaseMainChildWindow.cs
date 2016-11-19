using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmLight.RollbackViewModel.Example.Base
{
    /// <summary>
    /// Base class for child MetroWindow
    /// </summary>
    public class BaseMainChildWindow : MetroWindow
    {
        public BaseMainChildWindow()
            : base()
        {
            this.Owner = Application.Current.MainWindow;
            this.Icon = this.Owner.Icon;
            this.Owner.IsEnabled = false;
            this.Topmost = Owner.Topmost;
            this.ShowIconOnTitleBar = false;
            this.AllowsTransparency = this.Owner.AllowsTransparency;
            this.GlowBrush = ((MetroWindow)this.Owner).GlowBrush;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            this.Closed += Child_Closed;
        }

        private void Child_Closed(object sender, EventArgs e)
        {
            this.Owner.IsEnabled = true;
            this.Owner.Focus();
            this.Close();
        }
    }   
}