using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Drawing;
using Color = System.Drawing.Color;
using System.Timers;

namespace FrontEndTutorial
{

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class WPFFormCall : IExternalCommand
    {
        static AddInId appId = new AddInId(new Guid("3256F49C-7F76-4734-8992-3F1CF468BE9B"));

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            //Create an instance of the MainForm.xaml
            var mainForm = new SampleWPF();
            Process process = Process.GetCurrentProcess();

            var h = process.MainWindowHandle;

            //Show the WPF MainForm.xaml
            mainForm.ShowDialog();

            return 0;

        }


    }
}