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
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            string text = this.syntaxEditor.Document.CurrentSnapshot.GetText();
            WPF_demo_roslyn_Core.Entities.RoslynCompiler.CompileCode(this, text, out bool isError);


        }
    }
}
