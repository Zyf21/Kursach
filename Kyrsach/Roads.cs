using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kyrsach
{
    class Roads : Objects_work 
    {
        public string wight;
        public string slope_angle;

        public Roads(string name_Object, string distance, string wight, string name, string type, string category, string slope_angle)
            : base(name_Object, distance, name, type, category)
        {

            this.wight = wight;
            this.slope_angle = slope_angle;
          
        }

        public string Wight
        {
            get { return wight; }
        }
        public string Slope_angle
        {
            get { return slope_angle; }
        }
         
    }
}
