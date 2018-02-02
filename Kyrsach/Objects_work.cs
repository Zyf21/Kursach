using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kyrsach
{
    class Objects_work
    {
         public string name_Object ;
         public string distance;
         public string name;
         public string type;
         public string category;

        //Конструктор
         public Objects_work(string name_Object, string distance, string category, string name, string type)
        {
            this.name_Object = name_Object;
            this.distance = distance;
            this.name = name;
            this.type = type;

            this.category = category;
           
        }
        //Свойства
         public string Name
        {
            get { return name; }
        }
         public string Type
         {
             get { return type; }
         }
   
        public string Name_Object
        {
            get { return name_Object; }
        }

        public string Distance
        {
            get { return distance; }
        }
        public string Category
        {
            get { return category; }
        }

        public override string ToString()
        {
            string outString;
            outString = string.Format(" Название объекта {0,10}  \r\n Название карьера {1,10} \r\n Расстояние {2,22}км \r\n Тип дороги {3,23} \r\n Тип груза {4,26}",
                                            name_Object.PadRight(5),
                                            name.PadRight(5),
                                            distance.PadRight(5),
                                            category.PadRight(5),
                                            type.PadRight(5));
            return outString;
        }
        public void Passport()
        {

            Console.WriteLine(this.ToString());

        }

  
    
    
        
    }
}
