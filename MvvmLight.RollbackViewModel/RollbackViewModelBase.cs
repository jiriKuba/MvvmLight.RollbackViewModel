using GalaSoft.MvvmLight;
using MvvmLight.RollbackViewModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight.RollbackViewModel
{
    public class RollbackViewModelBase : ExtendedViewModel, IDisposable
    {
        protected Object _modelHistory;

        protected Boolean _wasModelChanged;

        protected Boolean _isRestoring;

        protected Boolean _risePropertyChangeWhenRestore;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public RollbackViewModelBase()
            : base()
        {
            
        }

        /// <summary>
        /// Basic setup
        /// </summary>
        public virtual void Init()
        {
            this._risePropertyChangeWhenRestore = false;
            this._wasModelChanged = false;
            this._isRestoring = false;

            this._modelHistory = this.Clone();
        }

        /// <summary>
        /// ViewModel was changed
        /// </summary>
        public virtual Boolean WasChangeMade()
        {
            return this._wasModelChanged;
        }

        public override void RaisePropertyChanged(String propertyName)
        {
            //TODO:
            // don't set this._wasModelChanged = true; when property has SkipRollbackAttribute

            //dont't rise property change when restoring viewModel
            if (!this._isRestoring || this._risePropertyChangeWhenRestore)
                base.RaisePropertyChanged(propertyName);

            this._wasModelChanged = true;
        }

        /// <summary>
        /// Commit viewModel changes
        /// </summary>
        public virtual void Commit()
        {
            this._wasModelChanged = false;
            this.CleanupHistory();
            this._modelHistory = this.Clone();
        }

        /// <summary>
        /// Revert viewModel changes
        /// </summary>
        public virtual void Rollback()
        {
            if (this._modelHistory != null)
            {
                this._isRestoring = true;

                TypeInfo typeInfo = this.GetType().GetTypeInfo();
                IEnumerable<PropertyInfo> properties = typeInfo.DeclaredProperties;

                if (properties != null && properties.Any())
                {
                    foreach (PropertyInfo prop in properties)
                    {
                        SkipRollbackAttribute[] attrs = (SkipRollbackAttribute[])prop.GetCustomAttributes(typeof(SkipRollbackAttribute), false);
                        if ((attrs == null || attrs.Length == 0) && prop.CanWrite)
                        {
                            prop.SetValue(this, prop.GetValue(this._modelHistory));
                        }
                    }
                }

                this._isRestoring = false;
            }

            this._wasModelChanged = false;
        }

        /// <summary>
        /// Clone this object
        /// </summary>
        public virtual Object Clone()
        {
            return this.MemberwiseClone();
        }

        protected void CleanupHistory()
        {
            if (this._modelHistory != null && this._modelHistory is ViewModelBase)
            {
                ((ViewModelBase)this._modelHistory).Cleanup();
            }
        }

        public override void Cleanup()
        {
            this.Dispose();            
        }

        public virtual void Dispose()
        {
            this.CleanupHistory();

            base.Cleanup();
        }
    }
}