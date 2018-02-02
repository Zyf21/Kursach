using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;


namespace Kyrsach
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void асфальтовыеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=LENOVO;" +
                                   "Integrated Security=SSPI;" +
                                   "Initial Catalog=trt";

           // cn.ConnectionString = @"Server=10.10.10.34; Database=14-IT-1-Brigadin; User Id=Brigadin; Password=wfr123490 ;";
            cn.Open();
            string strSelectPersons = "SELECT     dbo.Object.Name_Object, dbo.Object.Distance, dbo.Roads.Width_roud, dbo.Roads.Slope_angle, dbo.Category_road.Category, dbo.Quarry.NameQ, dbo.Quarry.Type, " +
                    "  dbo.Asphalt.Color_marking "+
                      " FROM         dbo.Asphalt INNER JOIN "+
                     " dbo.Roads ON dbo.Asphalt.ID_Asphalt = dbo.Roads.ID_Asphalt INNER JOIN "+
                    "  dbo.Object ON dbo.Roads.ID_Roads = dbo.Object.ID_Roads INNER JOIN "+
                    "  dbo.Quarry ON dbo.Object.ID_Quarry = dbo.Quarry.ID_Quarry INNER JOIN "+
                    "  dbo.Category_road ON dbo.Object.ID_Category_road = dbo.Category_road.ID_Category_road";
            SqlCommand cmdSelectPersons = new SqlCommand(strSelectPersons, cn);
            SqlDataReader personsDataReader2 = cmdSelectPersons.ExecuteReader();

            ArrayList personListt = new ArrayList();
            string no;
            string dis;
            string cat;
            string nam;
            string tp;
            string wg;
            string cm;
            string san;




            while (personsDataReader2.Read())
            {

                no = personsDataReader2["Name_Object"].ToString();
                dis = personsDataReader2["Distance"].ToString();
                wg = personsDataReader2["Width_roud"].ToString();
                nam = personsDataReader2["NameQ"].ToString();



                tp = personsDataReader2["Type"].ToString();
                cm = personsDataReader2["Color_marking"].ToString();
                cat = personsDataReader2["Category"].ToString();
                san = personsDataReader2["Slope_angle"].ToString();


                Asphalt ob = new Asphalt(no, dis, wg, nam, tp, cm, cat, san);
                personListt.Add(ob);

            }
            cn.Close();


            foreach (Asphalt ps2 in personListt)
            {
                listBox1.Items.Add(ps2);
                listBox1.DisplayMember = "name_Object";

               

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var obj = listBox1.SelectedItem;
            if (obj is Soil)
            {

                textBox1.Text = obj.ToString();
            }
            else
                if (obj is Slabs)
                {

                    textBox1.Text = obj.ToString();
                }
            else
                    if (obj is Asphalt)
                    {

                        textBox1.Text = obj.ToString();
                    }
                    else
                        if (obj is Breakstone)
                        {

                            textBox1.Text = obj.ToString();
                        }
            else
                            if (obj is Shlam)
                            {

                                textBox1.Text = obj.ToString();
                            }
            else
                                if (obj is Bezshlam)
                                {

                                    textBox1.Text = obj.ToString();
                                }


          
           
        }

        private void грунтовыеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            SqlConnection cn = new SqlConnection();

         
            cn.ConnectionString = @"Server=10.10.10.34; Database=14-IT-1-Brigadin; User Id=Brigadin; Password=wfr123490 ;";
            cn.Open();
            string strSelectPersons = "SELECT     dbo.Object.Name_Object, dbo.Object.Distance, dbo.Category_road.Category, dbo.Quarry.NameQ, dbo.Quarry.Type, dbo.Roads.Width_roud, dbo.Roads.Slope_angle, "+
                      "dbo.Soil.Type_soil "+
                     " FROM         dbo.Object INNER JOIN "+
                     " dbo.Category_road ON dbo.Object.ID_Category_road = dbo.Category_road.ID_Category_road INNER JOIN "+
                     " dbo.Quarry ON dbo.Object.ID_Quarry = dbo.Quarry.ID_Quarry INNER JOIN "+
                     " dbo.Roads ON dbo.Object.ID_Roads = dbo.Roads.ID_Roads INNER JOIN "+
                      "dbo.Soil ON dbo.Roads.ID_Soil = dbo.Soil.ID_Soil";
            SqlCommand cmdSelectPersons = new SqlCommand(strSelectPersons, cn);
            SqlDataReader personsDataReader2 = cmdSelectPersons.ExecuteReader();

            ArrayList personListt = new ArrayList();
            string no;
            string dis;
            string cat;
            string nam;
            string tp;
            string wg;
            string ts;
            string san;
          



            while (personsDataReader2.Read())
            {

                no = personsDataReader2["Name_Object"].ToString();
                dis = personsDataReader2["Distance"].ToString();
                wg = personsDataReader2["Width_roud"].ToString();
                nam = personsDataReader2["NameQ"].ToString();
         
               
            
                tp = personsDataReader2["Type"].ToString();
                ts = personsDataReader2["Type_soil"].ToString();
                cat = personsDataReader2["Category"].ToString();
                san = personsDataReader2["Slope_angle"].ToString();


                Soil ob = new Soil(no, dis, wg, nam, tp,ts, cat, san );
                personListt.Add(ob);

            }
            cn.Close();


            foreach (Soil ps2 in personListt)
            {
                listBox1.Items.Add(ps2);
              listBox1.DisplayMember = "name_Object";

               // textBox1.Text = ps2.ToString();

            }

        }

        private void изПлитToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            SqlConnection cn = new SqlConnection();


            cn.ConnectionString = @"Server=10.10.10.34; Database=14-IT-1-Brigadin; User Id=Brigadin; Password=wfr12390 ;";
            cn.Open();
            string strSelectPersons = "SELECT     dbo.Object.Name_Object, dbo.Object.Distance, dbo.Category_road.Category, dbo.Quarry.NameQ, dbo.Quarry.Type, dbo.Roads.Width_roud, dbo.Roads.Slope_angle, "+
                    "  dbo.Slabs.Height, dbo.Slabs.Width, dbo.Slabs.Length "+
                     " FROM         dbo.Object INNER JOIN "+
                     " dbo.Category_road ON dbo.Object.ID_Category_road = dbo.Category_road.ID_Category_road INNER JOIN "+
                     " dbo.Quarry ON dbo.Object.ID_Quarry = dbo.Quarry.ID_Quarry INNER JOIN "+
                    "  dbo.Roads ON dbo.Object.ID_Roads = dbo.Roads.ID_Roads INNER JOIN "+
                     " dbo.Slabs ON dbo.Roads.ID_Slabs = dbo.Slabs.ID_Slabs";
            SqlCommand cmdSelectPersons = new SqlCommand(strSelectPersons, cn);
            SqlDataReader personsDataReader2 = cmdSelectPersons.ExecuteReader();

            ArrayList personListt = new ArrayList();
            string no;
            string dis;
            string cat;
            string nam;
            string tp;
            string wg;
            double hig;
            double len;
            double wss;
            string san;




            while (personsDataReader2.Read())
            {

                no = personsDataReader2["Name_Object"].ToString();
                dis = personsDataReader2["Distance"].ToString();
                wg = personsDataReader2["Width_roud"].ToString();
                nam = personsDataReader2["NameQ"].ToString();



                tp = personsDataReader2["Type"].ToString();
                wss = (double)personsDataReader2["Width"];
                hig = (double)personsDataReader2["Height"];
                len = (double)personsDataReader2["Length"];
                cat = personsDataReader2["Category"].ToString();
                san = personsDataReader2["Slope_angle"].ToString();


               Slabs ob = new Slabs(no, dis, wg, nam, tp, wss,hig,len, cat, san);
                personListt.Add(ob);

            }
            cn.Close();


            foreach (Slabs ps2 in personListt)
            {
                listBox1.Items.Add(ps2);
                listBox1.DisplayMember = "name_Object";

                // textBox1.Text = ps2.ToString();

            }
           

        }

        private void изЩебняToolStripMenuItem_Click(object sender, EventArgs e)
        {


            listBox1.Items.Clear();

            SqlConnection cn = new SqlConnection();


            cn.ConnectionString = @"Server=10.10.10.34; Database=14-IT-1-Brigadin; User Id=Brigadin; Password=wfr12390 ;";
            cn.Open();
            string strSelectPersons = "SELECT     dbo.Object.Name_Object, dbo.Object.Distance, dbo.Roads.Width_roud, dbo.Roads.Slope_angle, dbo.Category_road.Category, dbo.Quarry.NameQ, dbo.Quarry.Type, "+
                    "  dbo.Breakstone.Fraction "+
                      "  FROM         dbo.Roads INNER JOIN "+
                    "  dbo.Object ON dbo.Roads.ID_Roads = dbo.Object.ID_Roads INNER JOIN "+
                   "   dbo.Quarry ON dbo.Object.ID_Quarry = dbo.Quarry.ID_Quarry INNER JOIN "+
                   "   dbo.Category_road ON dbo.Object.ID_Category_road = dbo.Category_road.ID_Category_road INNER JOIN "+
                   "   dbo.Breakstone ON dbo.Roads.ID_Breakstone = dbo.Breakstone.ID_Breakstone";
            SqlCommand cmdSelectPersons = new SqlCommand(strSelectPersons, cn);
            SqlDataReader personsDataReader2 = cmdSelectPersons.ExecuteReader();

            ArrayList personListt = new ArrayList();
            string no;
            string dis;
            string cat;
            string nam;
            string tp;
            string wg;
            string fr;
            string san;




            while (personsDataReader2.Read())
            {

                no = personsDataReader2["Name_Object"].ToString();
                dis = personsDataReader2["Distance"].ToString();
                wg = personsDataReader2["Width_roud"].ToString();
                nam = personsDataReader2["NameQ"].ToString();



                tp = personsDataReader2["Type"].ToString();
                fr = personsDataReader2["Fraction"].ToString();
                cat = personsDataReader2["Category"].ToString();
                san = personsDataReader2["Slope_angle"].ToString();


                Breakstone ob = new Breakstone(no, dis, wg, nam, tp, fr, cat, san);
                personListt.Add(ob);

            }
            cn.Close();


            foreach (Breakstone ps2 in personListt)
            {
                listBox1.Items.Add(ps2);
                listBox1.DisplayMember = "name_Object";



            }




        }

        private void шламовыеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            SqlConnection cn = new SqlConnection();


            cn.ConnectionString = @"Server=10.10.10.34; Database=14-IT-1-Brigadin; User Id=Brigadin; Password=wfr12390 ;";
            cn.Open();
            string strSelectPersons = "SELECT     dbo.Object.Name_Object, dbo.Object.Distance, dbo.Category_road.Category, dbo.Quarry.NameQ, dbo.Quarry.Type, dbo.Well_pads.Height, dbo.Well_pads.Width, "+ 
                    "  dbo.Well_pads.Length, dbo.Shlam.Type_izol "+
                     "  FROM         dbo.Object INNER JOIN "+
                    "  dbo.Quarry ON dbo.Object.ID_Quarry = dbo.Quarry.ID_Quarry INNER JOIN "+
                    "  dbo.Category_road ON dbo.Object.ID_Category_road = dbo.Category_road.ID_Category_road INNER JOIN "+
                    "  dbo.Well_pads ON dbo.Object.ID_Well_pads = dbo.Well_pads.ID_Well_pads INNER JOIN "+
                     " dbo.Shlam ON dbo.Well_pads.ID_Shlam = dbo.Shlam.ID_Shlam";
            SqlCommand cmdSelectPersons = new SqlCommand(strSelectPersons, cn);
            SqlDataReader personsDataReader2 = cmdSelectPersons.ExecuteReader();

            ArrayList personListt = new ArrayList();
            string no;
            string dis;
            string wigky;
            string nam;
            string tp;
            string tiz;
            string cat;
            string ligky;
            string hegky;





            while (personsDataReader2.Read())
            {

                no = personsDataReader2["Name_Object"].ToString();
                dis = personsDataReader2["Distance"].ToString();
                wigky = personsDataReader2["Width"].ToString();
                nam = personsDataReader2["NameQ"].ToString();



                tp = personsDataReader2["Type"].ToString();
                tiz = personsDataReader2["Type_izol"].ToString();
                cat = personsDataReader2["Category"].ToString();
                ligky = personsDataReader2["Length"].ToString();
                hegky = personsDataReader2["Height"].ToString();


                Shlam ob = new Shlam(no, dis, wigky, nam, tp, tiz, cat, ligky, hegky);
                personListt.Add(ob);

            }
            cn.Close();


            foreach (Shlam ps2 in personListt)
            {
                listBox1.Items.Add(ps2);
                listBox1.DisplayMember = "name_Object";



            }


        }

        private void безшламовыеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();

            SqlConnection cn = new SqlConnection();


            cn.ConnectionString = @"Server=10.10.10.34; Database=14-IT-1-Brigadin; User Id=Brigadin; Password=wfr12390 ;";
            cn.Open();
            string strSelectPersons = "SELECT     dbo.Object.Name_Object, dbo.Object.Distance, dbo.Category_road.Category, dbo.Quarry.NameQ, dbo.Quarry.Type, dbo.Well_pads.Height, dbo.Well_pads.Width, "+
                    "  dbo.Well_pads.Length, dbo.Bezshlam.Volume "+
                    "    FROM         dbo.Object INNER JOIN "+
                     " dbo.Quarry ON dbo.Object.ID_Quarry = dbo.Quarry.ID_Quarry INNER JOIN "+
                     " dbo.Category_road ON dbo.Object.ID_Category_road = dbo.Category_road.ID_Category_road INNER JOIN "+
                    "  dbo.Well_pads ON dbo.Object.ID_Well_pads = dbo.Well_pads.ID_Well_pads INNER JOIN "+
                    "  dbo.Bezshlam ON dbo.Well_pads.ID_Bezshlam = dbo.Bezshlam.ID_Bezshlam";
            SqlCommand cmdSelectPersons = new SqlCommand(strSelectPersons, cn);
            SqlDataReader personsDataReader2 = cmdSelectPersons.ExecuteReader();

            ArrayList personListt = new ArrayList();
            string no;
            string dis;
            string wigky;
            string nam;
            string tp;
            string vol;
            string cat;
            string ligky;
            string hegky;





            while (personsDataReader2.Read())
            {

                no = personsDataReader2["Name_Object"].ToString();
                dis = personsDataReader2["Distance"].ToString();
                wigky = personsDataReader2["Width"].ToString();
                nam = personsDataReader2["NameQ"].ToString();



                tp = personsDataReader2["Type"].ToString();
                vol = personsDataReader2["Volume"].ToString();
                cat = personsDataReader2["Category"].ToString();
                ligky = personsDataReader2["Length"].ToString();
                hegky = personsDataReader2["Height"].ToString();


                Bezshlam ob = new Bezshlam(no, dis, wigky, nam, tp, vol, cat, ligky, hegky);
                personListt.Add(ob);

            }
            cn.Close();


            foreach (Bezshlam ps2 in personListt)
            {
                listBox1.Items.Add(ps2);
                listBox1.DisplayMember = "name_Object";



            }

        }
    }
}
