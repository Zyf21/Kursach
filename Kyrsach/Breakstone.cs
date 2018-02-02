using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kyrsach
{
    class Breakstone :Roads
    {
        public string fraction;
        //Конструктор
        public Breakstone(string name_Object, string distance, string wight, string name, string type, string fraction, string category, string slope_angle)
            : base(name_Object, distance, wight, name, type, category, slope_angle)
        {

            this.fraction = fraction;
          
        }

         public string Fraction
        {
            get { return fraction; }
        }

         public override string ToString()
         {
             string outString;
             outString = string.Format(" Название объекта {0,10}  \r\n Ширина дороги   {1,10} \r\n Угол откосов   {2,15} \r\n Фракция щебня   {3, 10}  \r\n  ",
                                             name_Object.PadRight(5),
                                                   wight.PadRight(5),
                                              slope_angle.PadRight(5),
                                             fraction.PadRight(5));
             return outString;
         }
         public void Passportt()
         {

             Console.WriteLine(this.ToString());
         }
    }
}
