using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kyrsach
{
    class Soil : Roads
    {
        public string type_soil;

        public Soil(string name_Object, string distance, string wight, string name, string type, string type_soil, string category, string slope_angle)
            : base(name_Object, distance, wight, name, type, category, slope_angle)
        {

            this.type_soil = type_soil;
          
        }

        public string Type_soil
        {
            get { return type_soil; }
        }

        public override string ToString()
        {
            string outString;
            outString = string.Format(" Название объекта {0,10}  \r\n Ширина дороги {1,10} \r\n Угол откосов {2,15} \r\n Тип грунта {3, 10}  \r\n  ",
                                            name_Object.PadRight(5),
                                                  wight.PadRight(5),
                                             slope_angle.PadRight(5),
                                            type_soil.PadRight(5) );


            return outString;
        }
        public void Passportt()
        {
            Console.WriteLine(this.ToString());
                
        }

    }
}
