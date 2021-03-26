using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls.SyntaxEditor.Tagging.Taggers;

namespace WPF_demo_roslyn_Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            var cSharptagger = new CSharpTagger(this.syntaxEditor);
            this.syntaxEditor.TaggersRegistry.RegisterTagger(cSharptagger);

            //string code = "using (ExcelPackage excelPackage = new ExcelPackage())\n" +
            //    "{\n" +
            //    "excelPackage.Workbook.Properties.Author = \"VDWWD\"; \n" +
            //    "excelPackage.Workbook.Properties.Title = \"Title of Document\";\n" +
            //    "excelPackage.Workbook.Properties.Subject = \"EPPlus demo export data\";\n" +
            //    "excelPackage.Workbook.Properties.Created = DateTime.Now;\n\n" +

            //    "//Create the WorkSheet\n" +
            //    "ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(\"Sheet 1\");\n\n" +

            //    "//Add some text to cell A1\n" +
            //    "worksheet.Cells[\"A1\"].Value = \"My first EPPlus spreadsheet!\";\n" +
            //    "//You could also use [line, column] notation:\n" +
            //    "worksheet.Cells[1, 2].Value = \"This is cell B1!\";\n\n" +

            //    "//Save your file\n" +
            //    "FileInfo fi = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +\n" +
            //    "\"\\\\File.xlsx\");\n" +
            //    "excelPackage.SaveAs(fi);\n" +
            //"}";

            //this.syntaxEditor.Document = new Telerik.Windows.SyntaxEditor.Core.Text.TextDocument(code);
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            string text = this.syntaxEditor.Document.CurrentSnapshot.GetText();
            WPF_demo_roslyn_Core.Entities.Roslyn.CompileAndExecuteCode(this, text, out bool isError);


        }
    }
}
