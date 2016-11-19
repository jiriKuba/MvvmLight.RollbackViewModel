using GalaSoft.MvvmLight.CommandWpf;
using MvvmLight.RollbackViewModel.Attributes;
using MvvmLight.RollbackViewModel.Example.Interfaces;
using MvvmLight.RollbackViewModel.Example.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MvvmLight.RollbackViewModel.Example.ViewModel
{
    public class SettingViewModel : RollbackViewModelBase
    {
        private Setting _setting;

        private ISettingService _settingService;
        
        public String ThemeBaseColor
        {
            get
            {
                return this._setting.ThemeBaseColor;
            }
            set
            {
                this._setting.ThemeBaseColor = value;
                this.RaisePropertyChanged(nameof(this.ThemeBaseColor));
            }
        }

        public String ThemeAccentColor
        {
            get
            {
                return this._setting.AccentColor;
            }
            set
            {
                this._setting.AccentColor = value;
                this.RaisePropertyChanged(nameof(this.ThemeAccentColor));
            }
        }

        public Boolean? IsAlwaysOnTopNullable
        {
            get
            {
                return this._setting.IsAlwaysOnTop;
            }
            set
            {
                if (value.HasValue && value == true)
                {
                    this._setting.IsAlwaysOnTop = true;
                }
                else
                {
                    this._setting.IsAlwaysOnTop = false;
                }

                this.RaisePropertyChanged(nameof(this.IsAlwaysOnTopNullable));
                this.RaisePropertyChanged(nameof(this.IsAlwaysOnTop));
            }
        }

        public Boolean IsAlwaysOnTop
        {
            get
            {
                if (this.IsAlwaysOnTopNullable.HasValue && this.IsAlwaysOnTopNullable.Value == true)
                    return true;
                else
                    return false;
            }
            set
            {
                this.IsAlwaysOnTopNullable = value;
            }
        }

        [SkipRollback]
        public Double WindowWidth
        {
            get
            {
                return this._setting.WindowWidth;
            }
            set
            {
                this._setting.WindowWidth = value;
                this.RaisePropertyChanged(nameof(this.WindowWidth));
            }
        }

        [SkipRollback]
        public Double WindowHeight
        {
            get
            {
                return this._setting.WindowHeight;
            }
            set
            {
                this._setting.WindowHeight = value;
                this.RaisePropertyChanged(nameof(this.WindowHeight));
            }
        }

        public SettingViewModel(ISettingService settingService)
            : base()
        {
            this._settingService = settingService;
            this._setting = this._settingService.GetSetting();

            this._saveCommand = new RelayCommand<Window>((w) => this.DoSaveCommand(w));
            this._cancelCommand = new RelayCommand<Window>((w) => this.DoCancelCommand(w));

            this.Init();
        }

        public override void RaisePropertyChanged(String propertyName)
        {
            base.RaisePropertyChanged(propertyName);

            if (propertyName.Equals(nameof(this.ThemeBaseColor)) || propertyName.Equals(nameof(this.ThemeAccentColor)))
            {
                App.Instance.SwitchThemeColor(this._setting.ThemeBaseColor, this._setting.AccentColor);
            }
        }

        public void SaveSettings()
        {
            this._settingService.SaveSetting();
        }

        //commands

        /// <summary>
        /// save command
        /// </summary>
        private RelayCommand<Window> _saveCommand;

        /// <summary>
        /// cancel command
        /// </summary>
        private RelayCommand<Window> _cancelCommand;

        /// <summary>
        /// save command
        /// </summary>
        public RelayCommand<Window> SaveCommand
        {
            get { return this._saveCommand; }
        }

        /// <summary>
        /// cancel command
        /// </summary>
        public RelayCommand<Window> CancelCommand
        {
            get { return this._cancelCommand; }
        }


        private void DoSaveCommand(Window w)
        {
            if (this.WasChangeMade())
            {
                this.Commit();
                this.SaveSettings();
            }

            if (w != null)
                w.Close();
        }

        private void DoCancelCommand(Window w)
        {
            if (this.WasChangeMade())
            {
                this.Rollback();
            }

            if (w != null)
                w.Close();
        }

        public override Object Clone()
        {
            Object tempObj = base.Clone();

            if (tempObj is SettingViewModel)
            {
                //model clone
                ((SettingViewModel)tempObj)._setting = (Setting)this._setting.Clone();
            }
            return tempObj;
        }
    }
}