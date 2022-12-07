using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ExcelIras
{
    public partial class Form1 : Form
    {
        Excel.Application xlApp; // A Microsoft Excel alkalmazás
        Excel.Workbook xlWB;     // A létrehozott munkafüzet
        Excel.Worksheet xlSheet; // Munkalap a munkafüzeten belül

        public Form1()
        {
            InitializeComponent();
            CreateExcel();
        }

        void FormatTable()
        {
            Excel.Range fejllécRange = xlSheet.get_Range("A1", Type.Missing).get_Resize(1, 6);
            fejllécRange.Font.Bold = true;
            fejllécRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            fejllécRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            fejllécRange.EntireColumn.AutoFit();
            fejllécRange.RowHeight = 40;
            fejllécRange.Interior.Color = Color.Fuchsia;
            fejllécRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

            Excel.Range táblaRange = xlSheet.get_Range("A2", Type.Missing).get_Resize(xlSheet.UsedRange.Rows.Count-1, 6);
            táblaRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
            táblaRange = xlSheet.get_Range("A2", Type.Missing).get_Resize(xlSheet.UsedRange.Rows.Count-2, 1);
            táblaRange.Interior.Color = Color.LightYellow;
            táblaRange.Font.Bold = true;

            táblaRange = xlSheet.get_Range("F2", Type.Missing).get_Resize(xlSheet.UsedRange.Rows.Count - 2, 1);
            táblaRange.Interior.Color = Color.LightGreen;

            táblaRange = xlSheet.get_Range("E2", Type.Missing).get_Resize(xlSheet.UsedRange.Rows.Count - 2, 1);
            táblaRange.NumberFormat = "0.00";
        }

        void CreateTable()
        {
            string[] fejlécek = new string[] {
                                                "Kérdés",
                                                "1. válasz",
                                                "2. válaszl",
                                                "3. válasz",
                                                "Helyes válasz",
                                                "kép"};
            for(int i=0; i<fejlécek.Length; i++)
            {
                xlSheet.Cells[1, i+1] = fejlécek[i];
            }

            Models.HajosContext context = new();
            var adatok = context.Questions.ToList();
            object[,] adatTömb = new object[adatok.Count(), fejlécek.Count()];

            for (int i = 0; i < adatok.Count(); i++)
            {
                adatTömb[i, 0] = adatok[i].Question1;
                adatTömb[i, 1] = adatok[i].Answer1;
                adatTömb[i, 2] = adatok[i].Answer2;
                adatTömb[i, 3] = adatok[i].Answer3;
                adatTömb[i, 4] = adatok[i].CorrectAnswer;
                adatTömb[i, 5] = adatok[i].Image;
            }

            int nsorok = adatTömb.GetLength(0);
            int noszlopok = adatTömb.GetLength(1);

            Excel.Range adatRange = xlSheet.get_Range("A2", Type.Missing).get_Resize(nsorok, noszlopok);
            adatRange.Value2 = adatTömb;


            FormatTable();
        }

        void CreateExcel()
        {
            try
            {
                // Excel elindítása és az applikáció objektum betöltése
                xlApp = new Excel.Application();

                // Új munkafüzet
                xlWB = xlApp.Workbooks.Add(Missing.Value);

                // Új munkalap
                xlSheet = xlWB.ActiveSheet;

                // Tábla létrehozása
                CreateTable(); // Ennek megírása a következõ feladatrészben következik

                // Control átadása a felhasználónak
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex) // Hibakezelés a beépített hibaüzenettel
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                // Hiba esetén az Excel applikáció bezárása automatikusan
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }
    }
}