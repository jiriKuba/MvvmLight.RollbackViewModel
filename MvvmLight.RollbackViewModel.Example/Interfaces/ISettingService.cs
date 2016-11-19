using MvvmLight.RollbackViewModel.Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight.RollbackViewModel.Example.Interfaces
{
    public interface ISettingService
    {
        /// <summary>
        /// Load setting from file or create default
        /// </summary>
        Setting GetSetting();

        /// <summary>
        /// Save actual settings
        /// </summary>
        void SaveSetting();
    }
}
