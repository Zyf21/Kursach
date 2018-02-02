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
    public partial class Form1 : Form
    {
        SqlConnection cn;
        private SqlDataAdapter adapter;
        private DataSet ds;
   
    

        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
           
            cn = new SqlConnection();
      
            cn.ConnectionString = @"Data Source=LENOVO;" +
                                     "Integrated Security=SSPI;" +
                                     "Initial Catalog=trt";
          //  cn.ConnectionString = @"Server=10.10.10.34; Database=14-IT-1-Brigadin; User Id=Brigadin; Password=wfr12390 ;";
            cn.Open();
            string strSelectPersons = "Select Name_Object  From Object";     
            SqlCommand cmdSelectPersons = new SqlCommand(strSelectPersons, cn);
            SqlDataReader personsDataReader = cmdSelectPersons.ExecuteReader();
           
              ArrayList personList = new ArrayList();     
            string nm;
            
           
            while (personsDataReader.Read())
            {
                nm = personsDataReader["Name_Object"].ToString();
               
           
                personList.Add(nm);
            }
            cn.Close();

            foreach ( string ps   in personList)
            {
                listBox1.Items.Add(ps);
            }
           
        }
    

        private void button2_Click(object sender, EventArgs e)

        {
            // добавление объектов
            try
            {
                string obekt = listBox1.SelectedItem.ToString();




                string zp = ("SELECT  TOP (100) PERCENT dbo.Cars.Registration_number, dbo.Drivers.Name, dbo.Drivers.Surname, dbo.Brands.Capacity, dbo.Brands.Load_capacity,    dbo.Object_work.Number_flights," +
                        "  dbo.Brands.Capacity * dbo.Object_work.Number_flights AS Total_Capacity, dbo.Brands.Load_capacity * dbo.Object_work.Number_flights AS Total_Load_capacity,   dbo.Object_work.ID_Object_work " +

                         " FROM         dbo.Brands INNER JOIN" +
                         " dbo.Cars ON dbo.Brands.ID_Brand = dbo.Cars.ID_Brand INNER JOIN" +
                         " dbo.Drivers ON dbo.Cars.ID_Cars = dbo.Drivers.ID_Car INNER JOIN" +
                         " dbo.Waybill ON dbo.Drivers.ID_Driver = dbo.Waybill.ID_Driver INNER JOIN" +
                         " dbo.Object_work ON dbo.Waybill.ID_Waybill = dbo.Object_work.ID_Waybill INNER JOIN" +

                         " dbo.Object ON dbo.Waybill.ID_Object = dbo.Object.ID_Object" +
                         " WHERE     (dbo.Object.Name_Object = '" + obekt + "')");


                adapter = new SqlDataAdapter(zp, cn);





                ds = new DataSet();


                adapter.Fill(ds);

                adapter.UpdateCommand = new SqlCommand("UPDATE Object_work SET Number_flights = @Number_flights WHERE ID_Object_work = @ID_Object_work", cn);
                adapter.UpdateCommand.Parameters.Add("@Number_flights", SqlDbType.Int, 5, "Number_flights");
                SqlParameter param = adapter.UpdateCommand.Parameters.Add("@ID_Object_work", SqlDbType.Int, 5, "ID_Object_work");
                param.SourceVersion = DataRowVersion.Original;

                dataGridView1.DataSource = ds.Tables[0];

                // информация о объектах
                string obekt2 = listBox1.SelectedItem.ToString();
                cn = new SqlConnection();

                   cn.ConnectionString = @"Data Source=LENOVO;" +
                   "Integrated Security=SSPI;" +
                      "Initial Catalog=trt";
               // cn.ConnectionString = @"Server=10.10.10.34; Database=14-IT-1-Brigadin; User Id=Brigadin; Password=wfr12390 ;";
                cn.Open();
                string strSelect = ("     SELECT Object.Name_Object, Object.Distance, Category_road.Category, Quarry.Type,Quarry.NameQ " +
                                      "FROM Object,Category_road,Quarry " +
                                      "WHERE Object.ID_Category_road=Category_road.ID_Category_road AND " +
                                      " Object.ID_Quarry=Quarry.ID_Quarry " +
                                        "AND Object.Name_Object= '" + obekt2 + "'");

                SqlCommand cmdSelect = new SqlCommand(strSelect, cn);
                SqlDataReader personsDataReader2 = cmdSelect.ExecuteReader();

                SqlDataAdapter adapter2 = new SqlDataAdapter(strSelect, cn);
                SqlCommandBuilder cb = new SqlCommandBuilder(adapter2);


                ArrayList personListt = new ArrayList();
                string no;
                string dis;
                string cat;
                string nam;
                string tp;


                while (personsDataReader2.Read())
                {

                    no = personsDataReader2["Name_Object"].ToString();
                    dis = personsDataReader2["Distance"].ToString();
                    cat = personsDataReader2["Category"].ToString();
                    nam = personsDataReader2["NameQ"].ToString();
                    tp = personsDataReader2["Type"].ToString();
                    Objects_work ob = new Objects_work(no, dis, cat, nam, tp);
                    personListt.Add(ob);

                }
                cn.Close();


                foreach (Objects_work ps2 in personListt)
                {
                    textBox1.Text = ps2.ToString();

                }



            }
            catch(Exception)
            {MessageBox.Show ("Не выбран объект работы");}


        }
        int column, roww;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // добавление объектов
            try
            {
                string obekt = listBox1.SelectedItem.ToString();




                string zp = ("SELECT  TOP (100) PERCENT dbo.Cars.Registration_number, dbo.Drivers.Name, dbo.Drivers.Surname, dbo.Brands.Capacity, dbo.Brands.Load_capacity,    dbo.Object_work.Number_flights," +
                        "  dbo.Brands.Capacity * dbo.Object_work.Number_flights AS Total_Capacity, dbo.Brands.Load_capacity * dbo.Object_work.Number_flights AS Total_Load_capacity,   dbo.Object_work.ID_Object_work " +

                         " FROM         dbo.Brands INNER JOIN" +
                         " dbo.Cars ON dbo.Brands.ID_Brand = dbo.Cars.ID_Brand INNER JOIN" +
                         " dbo.Drivers ON dbo.Cars.ID_Cars = dbo.Drivers.ID_Car INNER JOIN" +
                         " dbo.Waybill ON dbo.Drivers.ID_Driver = dbo.Waybill.ID_Driver INNER JOIN" +
                         " dbo.Object_work ON dbo.Waybill.ID_Waybill = dbo.Object_work.ID_Waybill INNER JOIN" +

                         " dbo.Object ON dbo.Waybill.ID_Object = dbo.Object.ID_Object" +
                         " WHERE     (dbo.Object.Name_Object = '" + obekt + "')");


                adapter = new SqlDataAdapter(zp, cn);





                ds = new DataSet();


                adapter.Fill(ds);

                adapter.UpdateCommand = new SqlCommand("UPDATE Object_work SET Number_flights = @Number_flights WHERE ID_Object_work = @ID_Object_work", cn);
                adapter.UpdateCommand.Parameters.Add("@Number_flights", SqlDbType.Int, 5, "Number_flights");
                SqlParameter param = adapter.UpdateCommand.Parameters.Add("@ID_Object_work", SqlDbType.Int, 5, "ID_Object_work");
                param.SourceVersion = DataRowVersion.Original;

                dataGridView1.DataSource = ds.Tables[0];

                // информация о объектах
                string obekt2 = listBox1.SelectedItem.ToString();
                cn = new SqlConnection();

                cn.ConnectionString = @"Data Source=LENOVO;" +
                "Integrated Security=SSPI;" +
                   "Initial Catalog=trt";
                // cn.ConnectionString = @"Server=10.10.10.34; Database=14-IT-1-Brigadin; User Id=Brigadin; Password=wfr12390 ;";
                cn.Open();
                string strSelect = ("     SELECT Object.Name_Object, Object.Distance, Category_road.Category, Quarry.Type,Quarry.NameQ " +
                                      "FROM Object,Category_road,Quarry " +
                                      "WHERE Object.ID_Category_road=Category_road.ID_Category_road AND " +
                                      " Object.ID_Quarry=Quarry.ID_Quarry " +
                                        "AND Object.Name_Object= '" + obekt2 + "'");

                SqlCommand cmdSelect = new SqlCommand(strSelect, cn);
                SqlDataReader personsDataReader2 = cmdSelect.ExecuteReader();

                SqlDataAdapter adapter2 = new SqlDataAdapter(strSelect, cn);
                SqlCommandBuilder cb = new SqlCommandBuilder(adapter2);


                ArrayList personListt = new ArrayList();
                string no;
                string dis;
                string cat;
                string nam;
                string tp;


                while (personsDataReader2.Read())
                {

                    no = personsDataReader2["Name_Object"].ToString();
                    dis = personsDataReader2["Distance"].ToString();
                    cat = personsDataReader2["Category"].ToString();
                    nam = personsDataReader2["NameQ"].ToString();
                    tp = personsDataReader2["Type"].ToString();
                    Objects_work ob = new Objects_work(no, dis, cat, nam, tp);
                    personListt.Add(ob);

                }
                cn.Close();


                foreach (Objects_work ps2 in personListt)
                {
                    textBox1.Text = ps2.ToString();

                }



            }
            catch (Exception)
            { MessageBox.Show("Не выбран объект работы"); } 


            //Вывод данных
            try
            {
                

                string obekt = listBox1.SelectedItem.ToString();
                string zp = ("SELECT  TOP (100) PERCENT dbo.Cars.Registration_number, dbo.Drivers.Name, dbo.Drivers.Surname, dbo.Brands.Capacity, dbo.Brands.Load_capacity,    dbo.Object_work.Number_flights," +
                        "  dbo.Brands.Capacity * dbo.Object_work.Number_flights AS Total_Capacity, dbo.Brands.Load_capacity * dbo.Object_work.Number_flights AS Total_Load_capacity,   dbo.Object_work.ID_Object_work " +
                         " FROM         dbo.Brands INNER JOIN" +
                         " dbo.Cars ON dbo.Brands.ID_Brand = dbo.Cars.ID_Brand INNER JOIN" +
                         " dbo.Drivers ON dbo.Cars.ID_Cars = dbo.Drivers.ID_Car INNER JOIN" +
                         " dbo.Waybill ON dbo.Drivers.ID_Driver = dbo.Waybill.ID_Driver INNER JOIN" +
                         " dbo.Object_work ON dbo.Waybill.ID_Waybill = dbo.Object_work.ID_Waybill INNER JOIN" +
                         " dbo.Object ON dbo.Waybill.ID_Object = dbo.Object.ID_Object" +
                         " WHERE     (dbo.Object.Name_Object = '" + obekt + "')");


                adapter = new SqlDataAdapter(zp, cn);
                ds = new DataSet();
                adapter.Fill(ds);
                adapter.UpdateCommand = new SqlCommand("UPDATE Object_work SET Number_flights = @Number_flights WHERE ID_Object_work = @ID_Object_work", cn);
                adapter.UpdateCommand.Parameters.Add("@Number_flights", SqlDbType.Int, 5, "Number_flights");
                SqlParameter param = adapter.UpdateCommand.Parameters.Add("@ID_Object_work", SqlDbType.Int, 5, "ID_Object_work");
                param.SourceVersion = DataRowVersion.Original;

                dataGridView1.DataSource = ds.Tables[0];
                //Подсчет общий показателей
                double cap = 0;
                double totalcap = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    double incom;
                    double incom2;
                    double.TryParse((row.Cells[7].Value ?? "0").ToString().Replace(".", ","), out incom);
                    cap += incom;
                    double.TryParse((row.Cells[6].Value ?? "0").ToString().Replace(".", ","), out incom2);
                    totalcap += incom2;
                }

                textBox2.Text = ("Общий вес        " + cap.ToString() + "\r\nОбщий объем  " + totalcap.ToString());



            }
            catch (Exception)
            { MessageBox.Show("Не выбрана ячейка количетва рейсов"); }








        }

       
        
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow roww = (dataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
                roww[column] = Convert.ToInt32(roww[column]) + 1;

                var a = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value;
                try
                {
                    adapter.Update(ds.Tables[0]);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                string obekt = listBox1.SelectedItem.ToString();
                string zp = ("SELECT  TOP (100) PERCENT dbo.Cars.Registration_number, dbo.Drivers.Name, dbo.Drivers.Surname, dbo.Brands.Capacity, dbo.Brands.Load_capacity,    dbo.Object_work.Number_flights," +
                        "  dbo.Brands.Capacity * dbo.Object_work.Number_flights AS Total_Capacity, dbo.Brands.Load_capacity * dbo.Object_work.Number_flights AS Total_Load_capacity,   dbo.Object_work.ID_Object_work " +
                         " FROM         dbo.Brands INNER JOIN" +
                         " dbo.Cars ON dbo.Brands.ID_Brand = dbo.Cars.ID_Brand INNER JOIN" +
                         " dbo.Drivers ON dbo.Cars.ID_Cars = dbo.Drivers.ID_Car INNER JOIN" +
                         " dbo.Waybill ON dbo.Drivers.ID_Driver = dbo.Waybill.ID_Driver INNER JOIN" +
                         " dbo.Object_work ON dbo.Waybill.ID_Waybill = dbo.Object_work.ID_Waybill INNER JOIN" +
                         " dbo.Object ON dbo.Waybill.ID_Object = dbo.Object.ID_Object" +
                         " WHERE     (dbo.Object.Name_Object = '" + obekt + "')");


                adapter = new SqlDataAdapter(zp, cn);
                ds = new DataSet();
                adapter.Fill(ds);
                adapter.UpdateCommand = new SqlCommand("UPDATE Object_work SET Number_flights = @Number_flights WHERE ID_Object_work = @ID_Object_work", cn);
                adapter.UpdateCommand.Parameters.Add("@Number_flights", SqlDbType.Int, 5, "Number_flights");
                SqlParameter param = adapter.UpdateCommand.Parameters.Add("@ID_Object_work", SqlDbType.Int, 5, "ID_Object_work");
                param.SourceVersion = DataRowVersion.Original;

                dataGridView1.DataSource = ds.Tables[0];
                //Подсчет общий показателей
                double cap = 0;
                double totalcap = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    double incom;
                    double incom2;
                    double.TryParse((row.Cells[7].Value ?? "0").ToString().Replace(".", ","), out incom);
                    cap += incom;
                    double.TryParse((row.Cells[6].Value ?? "0").ToString().Replace(".", ","), out incom2);
                    totalcap += incom2;
                }

                textBox2.Text = ("Общий вес        " + cap.ToString() + "\r\nОбщий объем  " + totalcap.ToString());



            }
            catch (Exception)
            { MessageBox.Show  ("Не выбрана ячейка количетва рейсов"); }
        }

      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            column = e.ColumnIndex;
            roww = e.RowIndex;

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string obekt = listBox1.SelectedItem.ToString();

            string zp = ("SELECT dbo.Object.Name_Object, dbo.Roads.Slope_angle, dbo.Roads.Width_roud, dbo.Soil.Type_soil, dbo.Slabs.Height, dbo.Slabs.Width , dbo.Slabs.Length, " +
            " dbo.Breakstone.Fraction, dbo.Asphalt.Color_marking " +
            " FROM dbo.Object FULL JOIN " +
            " dbo.Roads ON dbo.Object.ID_Roads = dbo.Roads.ID_Roads FULL JOIN " +
            " dbo.Soil ON dbo.Roads.ID_Soil = dbo.Soil.ID_Soil FULL JOIN " +
            " dbo.Slabs ON dbo.Roads.ID_Slabs = dbo.Slabs.ID_Slabs FULL JOIN " +
            " dbo.Asphalt ON dbo.Roads.ID_Asphalt = dbo.Asphalt.ID_Asphalt FULL JOIN " +
            " dbo.Breakstone ON dbo.Roads.ID_Breakstone = dbo.Breakstone.ID_Breakstone " +
            " WHERE (dbo.Object.Name_Object = '" + obekt + "')");


            adapter = new SqlDataAdapter(zp, cn);

            


            ds = new DataSet();
       


            adapter.Fill(ds);
            bool Type_soilVisible;
            Type_soilVisible = false;
            bool HeightVisible;
            HeightVisible = false;
            bool WidthVisible;
            WidthVisible = false;
            bool Color_markingVisible;
            Color_markingVisible = false;
            bool LengthVisible;
            LengthVisible = false;
            bool FractionVisible;
            FractionVisible = false;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (!Type_soilVisible && row["Type_soil"] != DBNull.Value && row["Type_soil"].ToString() != "")
          
                    Type_soilVisible = true;
                if (!HeightVisible && row["Height"] != DBNull.Value && row["Height"].ToString() != "")
       
                    HeightVisible = true;
                if (!WidthVisible && row["Width"] != DBNull.Value && row["Width"].ToString() != "")

                    WidthVisible = true;
                if (!Color_markingVisible && row["Color_marking"] != DBNull.Value && row["Color_marking"].ToString() != "")
             
                    Color_markingVisible = true;
                if (!LengthVisible && row["Length"] != DBNull.Value && row["Length"].ToString() != "")
              
                    LengthVisible = true;
                if (!FractionVisible && row["Fraction"] != DBNull.Value && row["Fraction"].ToString() != "")
       
                    FractionVisible = true;
            
            }
            

        //dataGridView2.DataSource = ds.Tables[0];


        //dataGridView2.Columns["Type_soil"].Visible = Type_soilVisible;
        //dataGridView2.Columns["Height"].Visible = HeightVisible;
        //dataGridView2.Columns["Width"].Visible = WidthVisible;
        //dataGridView2.Columns["Color_marking"].Visible = Color_markingVisible;
        //dataGridView2.Columns["Length"].Visible = LengthVisible;
        //dataGridView2.Columns["Fraction"].Visible = FractionVisible;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(); // создаем
            f.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void отправитьНаEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportExcel excel = new ExportExcel(dataGridView1);
            string path = excel.GetPathExcelDocument();

            FormSMTP _smtpForm = new FormSMTP(path);
            _smtpForm.ShowDialog();
        }

        private void проверкаПочтыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopForm formpop = new PopForm();
            formpop.ShowDialog();
        }

        private void списокОбъектовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            cn = new SqlConnection();

            cn.ConnectionString = @"Data Source=LENOVO;" +
                                     "Integrated Security=SSPI;" +
                                     "Initial Catalog=trt";
            //  cn.ConnectionString = @"Server=10.10.10.34; Database=14-IT-1-Brigadin; User Id=Brigadin; Password=wfr12390 ;";
            cn.Open();
            string strSelectPersons = "Select Name_Object  From Object";
            SqlCommand cmdSelectPersons = new SqlCommand(strSelectPersons, cn);
            SqlDataReader personsDataReader = cmdSelectPersons.ExecuteReader();

            ArrayList personList = new ArrayList();
            string nm;


            while (personsDataReader.Read())
            {
                nm = personsDataReader["Name_Object"].ToString();


                personList.Add(nm);
            }
            cn.Close();

            foreach (string ps in personList)
            {
                listBox1.Items.Add(ps);
            }
        }

        private void проверитьПочтуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopForm formpop = new PopForm();
            formpop.ShowDialog();
        }

        private void отправитьНаEmailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExportExcel excel = new ExportExcel(dataGridView1);
            string path = excel.GetPathExcelDocument();

            FormSMTP _smtpForm = new FormSMTP(path);
            _smtpForm.ShowDialog();
        }

        private void категорииОбъектовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(); // создаем
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow roww = (dataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
                roww[column] = Convert.ToInt32(roww[column]) - 1;

                var a = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value;
                try
                {
                    adapter.Update(ds.Tables[0]);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                string obekt = listBox1.SelectedItem.ToString();
                string zp = ("SELECT  TOP (100) PERCENT dbo.Cars.Registration_number, dbo.Drivers.Name, dbo.Drivers.Surname, dbo.Brands.Capacity, dbo.Brands.Load_capacity,    dbo.Object_work.Number_flights," +
                        "  dbo.Brands.Capacity * dbo.Object_work.Number_flights AS Total_Capacity, dbo.Brands.Load_capacity * dbo.Object_work.Number_flights AS Total_Load_capacity,   dbo.Object_work.ID_Object_work " +
                         " FROM         dbo.Brands INNER JOIN" +
                         " dbo.Cars ON dbo.Brands.ID_Brand = dbo.Cars.ID_Brand INNER JOIN" +
                         " dbo.Drivers ON dbo.Cars.ID_Cars = dbo.Drivers.ID_Car INNER JOIN" +
                         " dbo.Waybill ON dbo.Drivers.ID_Driver = dbo.Waybill.ID_Driver INNER JOIN" +
                         " dbo.Object_work ON dbo.Waybill.ID_Waybill = dbo.Object_work.ID_Waybill INNER JOIN" +
                         " dbo.Object ON dbo.Waybill.ID_Object = dbo.Object.ID_Object" +
                         " WHERE     (dbo.Object.Name_Object = '" + obekt + "')");


                adapter = new SqlDataAdapter(zp, cn);
                ds = new DataSet();
                adapter.Fill(ds);
                adapter.UpdateCommand = new SqlCommand("UPDATE Object_work SET Number_flights = @Number_flights WHERE ID_Object_work = @ID_Object_work", cn);
                adapter.UpdateCommand.Parameters.Add("@Number_flights", SqlDbType.Int, 5, "Number_flights");
                SqlParameter param = adapter.UpdateCommand.Parameters.Add("@ID_Object_work", SqlDbType.Int, 5, "ID_Object_work");
                param.SourceVersion = DataRowVersion.Original;

                dataGridView1.DataSource = ds.Tables[0];
                //Подсчет общий показателей
                double cap = 0;
                double totalcap = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    double incom;
                    double incom2;
                    double.TryParse((row.Cells[7].Value ?? "0").ToString().Replace(".", ","), out incom);
                    cap += incom;
                    double.TryParse((row.Cells[6].Value ?? "0").ToString().Replace(".", ","), out incom2);
                    totalcap += incom2;
                }

                textBox2.Text = ("Общий вес        " + cap.ToString() + "\r\nОбщий объем  " + totalcap.ToString());



            }
            catch (Exception)
            { MessageBox.Show("Не выбрана ячейка количетва рейсов"); }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
