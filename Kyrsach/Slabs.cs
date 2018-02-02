using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kyrsach
{
    class Slabs :Roads
    {
        public double weightslab;
        public double height;
        public double length;

        public Slabs(string name_Object, string distance, string wight, string name, string type, double weightslab, double height, double length, string category, string slope_angle)
            : base(name_Object, distance, wight, name, type, category, slope_angle)
        {

            this.weightslab = weightslab;
            this.height = height;
            this.length = length;
  
        }

        public double Weightslab
        {
            get { return weightslab; }
            set { weightslab = value; }

        }
        public double Height
        {
            get { return height; }
            set { height = value; }

        }
        public double Length
        {
            get { return length; }
            set { length = value; }

        }

        public double Skr
        {
            get { return Math.Round( height,3) *  Math.Round( weightslab ,3)* Math.Round(length,3); }
        }

        public override string ToString()
        {
            string outString;
            outString = string.Format(" Название объекта {0,10}  \r\n Ширина дороги {1,10} м \r\n Угол откосов {2,22} градусов  \r\n Ширина плиты {3, 10} м  \r\n Длина плиты {4, 10} м  \r\n Высота плиты {5, 10} м \r\n Объём плиты {6, 10} м куб. \r\n",
                                            name_Object.PadRight(5),
                                             wight.PadRight(5),
                                               slope_angle.PadRight(5),
                                            weightslab.ToString().PadRight(5),
                                            height.ToString().PadRight(5),
                                           Math.Round(length, 3).ToString().PadRight(5),
                                            Skr.ToString().PadRight(5));

            return outString;
        }
        public void Passportt()
        {
            Console.WriteLine(this.ToString());
        }

    }
}
