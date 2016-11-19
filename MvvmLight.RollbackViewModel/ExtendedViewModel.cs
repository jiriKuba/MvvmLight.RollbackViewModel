using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MvvmLight.RollbackViewModel
{
    public class ExtendedViewModel : ViewModelBase
    {
        public ExtendedViewModel()
            : base()
        {

        }

        protected void RaiseAllPropertyChanged()
        {
            this.RaiseAllPropertyChanged(false);
        }

        protected void RaiseAllPropertyChanged(Boolean writableOnly)
        {
            TypeInfo typeInfo = this.GetType().GetTypeInfo();
            IEnumerable<PropertyInfo> properties = typeInfo.DeclaredProperties;
            if (properties != null && properties.Any())
            {
                foreach (PropertyInfo prop in properties)
                {
                    if (writableOnly && !prop.CanWrite)
                        continue;
                    else
                        this.RaisePropertyChanged(prop.Name);
                }
            }
        }

        protected void RaiseAllWritablePropertyChanged()
        {
            this.RaiseAllPropertyChanged(true);
        }
    }
}