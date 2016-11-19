using GalaSoft.MvvmLight.Ioc;
using MvvmLight.RollbackViewModel.Example.Interfaces;
using MvvmLight.RollbackViewModel.Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight.RollbackViewModel.Example.Services
{
    class SettingService : ISettingService
    {
        private const String SETTING_FILE_NAME = "MvvmLight.RollbackViewModel.Example.Setting.xml";
        private readonly String SettingPath;

        private Setting _setting;
        protected Setting Setting
        {
            get
            {
                if (this._setting == null)
                {
                    this._setting = this.LoadSettingFromFile();
                }

                return this._setting;
            }
            set
            {
                this._setting = value;
            }
        }

        public SettingService()
        {
            this.SettingPath = App.Instance.AppDirectory;
        }

        public Setting GetSetting()
        {
            return this.Setting;
        }

        public void SaveSetting()
        {
            this.SaveSetting(this.Setting);
        }

        private void SaveSetting(Setting setting)
        {
            try
            {
                SimpleIoc.Default.GetInstance<IDataService>().SaveObjectAsXmlToFile(setting, this.SettingPath + SETTING_FILE_NAME);
            }
            catch
            {
                //TODO: log error
            }
        }

        private Setting LoadSettingFromFile()
        {
            if (!System.IO.Directory.Exists(this.SettingPath) || !System.IO.File.Exists(this.SettingPath + SETTING_FILE_NAME))
            {
                //default
                Setting setting = new Setting();
                this.SaveSetting(setting);

                return setting;
            }
            else
            {
                return SimpleIoc.Default.GetInstance<IDataService>().LoadObjectAsXmlFromFile<Setting>(this.SettingPath + SETTING_FILE_NAME);
            }
        }
    }
}