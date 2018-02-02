using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kyrsach
{
    class ExportExcel
    {
        Microsoft.Office.Interop.Excel.Application appXL;
        Microsoft.Office.Interop.Excel._Workbook WB;
        Microsoft.Office.Interop.Excel._Worksheet oSheet;
        DataGridView data;

        //Конструктор
        public ExportExcel(DataGridView data)
        {
            this.data = data;
        }

        public string GetPathExcelDocument()
        {
            appXL = new Microsoft.Office.Interop.Excel.Application();//приложение excel
            //   appXL.Visible = true;
            appXL.SheetsInNewWorkbook = 1;
            appXL.Workbooks.Add(Type.Missing);

            WB = (Microsoft.Office.Interop.Excel.Workbook)(appXL.ActiveWorkbook);
            oSheet = appXL.ActiveSheet;//рабочий лист
            //объединение ячеек
            ((Microsoft.Office.Interop.Excel.Range)oSheet.get_Range("B1", "I1")).Merge();
            oSheet.Cells[1, 2] = "Производственный реестр";



            oSheet.Cells[2, 2] = "Регистрационный номер";
            oSheet.Cells[2, 3] = "Имя";
            oSheet.Cells[2, 4] = "Фамилия";
            oSheet.Cells[2, 5] = "Вес";
            oSheet.Cells[2, 6] = "Объем";
            oSheet.Cells[2, 7] = "Количество рейсов";
            oSheet.Cells[2, 8] = "Общий вес";
            oSheet.Cells[2, 9] = "Общий обхем";


            for (int i = 0; i < data.Rows.Count; i++)
            {
                oSheet.Cells[i + 3, 2] = data[0, i].Value;
                oSheet.Cells[i + 3, 3] = data[1, i].Value;
                oSheet.Cells[i + 3, 4] = data[2, i].Value;
                oSheet.Cells[i + 3, 5] = data[3, i].Value;
                oSheet.Cells[i + 3, 6] = data[4, i].Value;
                oSheet.Cells[i + 3, 7] = data[5, i].Value;
                oSheet.Cells[i + 3, 8] = data[6, i].Value;
                oSheet.Cells[i + 3, 9] = data[7, i].Value;
            }
        
            try
            {
                string fileName = string.Format("Отчет {0}", DateTime.Now.ToString("dd_MM_yyyy HH_mm"));

                appXL.ActiveWorkbook.SaveAs((Environment.CurrentDirectory + "\\" + fileName + ".xlsx"));
                //Путь к файлу
                var fullPath = appXL.ActiveWorkbook.Path.ToString() + "\\" + fileName + ".xlsx";
                //Закрываем Excel
                WB.Close(true, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                appXL.Quit();

                return fullPath;
            }
            catch
            {
                return null;
            }
        }
    }
}
