using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kyrsach
{
    class Shlam :Well_pads
    {

        public string type_izol;
        // Конструктор
        public Shlam(string name_Object, string distance, string wightkust, string name, string type, string type_izol, string category, string lightkust,string heightkust)
            : base(name_Object, distance, wightkust, name, type, category, lightkust, heightkust)
        {

            this.type_izol = type_izol;
          
        }

        public string Type_izol
        {
            get { return type_izol; }
        }

        public override string ToString()
        {
            string outString;
            outString = string.Format(" Название объекта {0,10}  \r\n Ширина куста  {1,10} \r\n Длина куста {2,15} \r\n Высота куста {3, 10}  \r\n Тип изоляции {4, 10} ",
                                            name_Object.PadRight(5),
                                                  wightkust.PadRight(5),
                                             lightkust.PadRight(5),
                                             heightkust.PadRight(5),
                                            type_izol.PadRight(5));


            return outString;
        }
        public void Passportt()
        {
            Console.WriteLine(this.ToString());

        }

    }
}
