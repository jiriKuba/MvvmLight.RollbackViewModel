using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight.RollbackViewModel.Example.Models
{
    [Serializable()]
    public class Setting : ISerializable, ICloneable
    {
        public Double WindowWidth { get; set; }

        public Double WindowHeight { get; set; }

        public Boolean IsAlwaysOnTop { get; set; }

        public String ThemeBaseColor { get; set; }

        public String AccentColor { get; set; }
        
        public Setting()
        {
            this.WindowWidth = 500;
            this.WindowHeight = 400;
            this.IsAlwaysOnTop = false;
            this.ThemeBaseColor = "BaseLight";
            this.AccentColor = "Blue";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("SerializationInfo is null");

            info.AddValue(nameof(this.IsAlwaysOnTop), this.IsAlwaysOnTop);
            info.AddValue(nameof(this.WindowWidth), this.WindowWidth);
            info.AddValue(nameof(this.WindowHeight), this.WindowHeight);
            info.AddValue(nameof(this.ThemeBaseColor), this.ThemeBaseColor);
            info.AddValue(nameof(this.AccentColor), this.AccentColor);
        }

        public Object Clone()
        {
            return this.MemberwiseClone();   
        }
    }
}