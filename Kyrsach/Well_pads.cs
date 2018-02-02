using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kyrsach
{
    class Well_pads :Objects_work
    {

        public string wightkust;
        public string lightkust;
        public string heightkust;

        public Well_pads(string name_Object, string distance, string wightkust, string name, string type,  string category, string lightkust,string heightkust)
            : base( name_Object, distance,name,type, category)
        {

            this.wightkust = wightkust;
            this.lightkust = lightkust;
            this.heightkust = heightkust;
          
        }

         public string Wightkust
         {
             get { return wightkust; }
         }

         public string Lightkust
         {
             get { return lightkust; }
         }
    }
}
