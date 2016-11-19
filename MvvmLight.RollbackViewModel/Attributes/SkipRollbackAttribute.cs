using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLight.RollbackViewModel.Attributes
{
    /// <summary>
    /// Property with this attribute will be ignored if rollback 
    /// </summary>
    public class SkipRollbackAttribute : System.Attribute
    {
        public SkipRollbackAttribute()
            : base()
        {

        }
    }
}
