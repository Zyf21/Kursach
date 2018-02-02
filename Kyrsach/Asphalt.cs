using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kyrsach
{
    class Asphalt :Roads
    {

        public string color_marking ;
        //Конструктор
        public Asphalt(string name_Object, string distance, string wight, string name, string type, string color_marking, string category, string slope_angle)
            : base(name_Object, distance, wight, name, type, category, slope_angle)
        {

            this.color_marking = color_marking;
          
        }

        public string Color_marking
        {
            get { return color_marking; }
        }

        public override string ToString()
        {
            string outString;
            outString = string.Format(" Название объекта {0,10}  \r\n Ширина дороги {1,10} м \r\n Угол откосов {2,15} градусов \r\n Цвет разметки {3, 10}  \r\n  ",
                                            name_Object.PadRight(5),
                                             wight.PadRight(5),
                                             slope_angle.PadRight(5),
                                            color_marking.PadRight(5));

            return outString;
        }
        public void Passportt()
        {

            Console.WriteLine(this.ToString());
        }

    }
}
