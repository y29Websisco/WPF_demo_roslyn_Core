using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_demo_roslyn_Core.Entities
{
    public static class Roslyn
    {
        public static object CompileAndExecuteCode(Window window, string formulaCode, out bool isError)
        {
            isError = false;
            try
            {
                Microsoft.CodeAnalysis.Scripting.Script<object> script = CSharpScript.Create(formulaCode, ScriptOptions.Default.
                    WithImports("System", "System.Collections", "OfficeOpenXml", "System.IO").
                    WithReferences(typeof(ExcelPackage).Assembly));

                Microsoft.CodeAnalysis.Scripting.ScriptState<object> result = script.RunAsync().Result;
                return result.ReturnValue;
            }
            catch (CompilationErrorException ex)
            {
                string errors = ex.Diagnostics.Select(d => d.GetMessage()).First().ToString();
                isError = true;
                MessageBox.Show(window, errors,string.Empty, MessageBoxButton.OK);
                return null;
            }
        }
    }
}
