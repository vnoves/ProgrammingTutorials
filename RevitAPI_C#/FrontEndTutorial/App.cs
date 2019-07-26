#region Namespaces
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Resources;
#endregion

namespace FrontEndTutorial
{
    class App : IExternalApplication
    {

        public Result OnStartup(UIControlledApplication application)
        {

            // Get the absolut path of this assembly
            string ExecutingAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly(
                ).Location;

            // Create a ribbon panel
            RibbonPanel m_projectPanel = application.CreateRibbonPanel(
                "FrontEndTutorial");

            //Button 01
            PushButton pushButton = m_projectPanel.AddItem(new PushButtonData(
                "FrontEndTutorial", "WinForm", ExecutingAssemblyPath,
                "FrontEndTutorial.WinFormCall")) as PushButton;

            //Add Help ToolTip 
            pushButton.ToolTip = "WindowsFormExample";

            //Add long description 
            pushButton.LongDescription =
             "This addin is an example tutorial";

            // Set the large image shown on button.
            pushButton.LargeImage = PngImageSource(
                "FrontEndTutorial.Resources.Logo01.png");



            //Button 02
            PushButton pushButton02 = m_projectPanel.AddItem(new PushButtonData(
                "FrontEndTutorial1", "WPF", ExecutingAssemblyPath,
                "FrontEndTutorial.WPFFormCall")) as PushButton;

            //Add Help ToolTip 
            pushButton02.ToolTip = "WPFExample";

            //Add long description 
            pushButton02.LongDescription =
             "This addin is an example tutorial";

            // Set the large image shown on button.
            pushButton02.LargeImage = PngImageSource(
                "FrontEndTutorial.Resources.Logo02.png");




            // Get the location of the solution DLL
            string path = System.IO.Path.GetDirectoryName(
               System.Reflection.Assembly.GetExecutingAssembly().Location);

            // Combine path with \
            string newpath = Path.GetFullPath(Path.Combine(path, @"..\"));

            ContextualHelp contextHelp = new ContextualHelp(
                ContextualHelpType.Url,
                "https://engworks.com/");

            // Assign contextual help to pushbutton
            pushButton.SetContextualHelp(contextHelp);

            // Assign contextual help to pushbutton
            pushButton02.SetContextualHelp(contextHelp);

            return Result.Succeeded;

        }

        private System.Windows.Media.ImageSource PngImageSource(string embeddedPath)
        {
            // Get Bitmap from Resources folder
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(embeddedPath);
            var decoder = new System.Windows.Media.Imaging.PngBitmapDecoder(stream,
                BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return decoder.Frames[0];
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}