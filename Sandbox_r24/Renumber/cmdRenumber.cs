using Autodesk.Revit.DB.Architecture;
using Sandbox_r24.Common;
using System.Windows;

namespace Sandbox_r24
{
    [Transaction(TransactionMode.Manual)]
    public class cmdRenumber : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // this is a variable for the Revit application
            UIApplication uiapp = commandData.Application;

            // this is a variable for the current Revit model
            Document curDoc = uiapp.ActiveUIDocument.Document;

            // put code needed for form here

            // get the current view
            View curView = curDoc.ActiveView;

            // create list for categories to renumber
            List<string> catList = new List<string>();

            // populate the list based on view type
            if (curView is Autodesk.Revit.DB.ViewPlan)
            {
                List<string> catListVPlan = new List<string> { "Doors", "Grids", "Rooms", "Walls", "Windows" };

                foreach (string curCat in catListVPlan)
                {
                    catList.Add(curCat);
                }
            }
            else if (curView is Autodesk.Revit.DB.ViewSection)
            {
                List<string> catListVSection = new List<string> { "Grids", "Levels" };

                foreach(string curCat in catListVSection)
                {
                    catList.Add(curCat);
                }
            }
            else if (curView is Autodesk.Revit.DB.ViewSheet)
            {
                catList.Add("Viewports");
            }

            // open the form
            frmRenumber curForm = new frmRenumber(catList)
            {
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                Topmost = true,
            };

            curForm.ShowDialog();

            

            // get data from the form

            
            

            // create and start transaction
            using(Transaction t = new Transaction(curDoc, "Renumber Elements"))
            {
                t.Start();




                t.Commit();
            }

            return Result.Succeeded;
        }
        internal static PushButtonData GetButtonData()
        {
            // use this method to define the properties for this command in the Revit ribbon
            string buttonInternalName = "btnCommand1";
            string buttonTitle = "Button 1";
            string? methodBase = MethodBase.GetCurrentMethod().DeclaringType?.FullName;

            if (methodBase == null)
            {
                throw new InvalidOperationException("MethodBase.GetCurrentMethod().DeclaringType?.FullName is null");
            }
            else
            {
                clsButtonData myButtonData1 = new clsButtonData(
                    buttonInternalName,
                    buttonTitle,
                    methodBase,
                    Properties.Resources.Blue_32,
                    Properties.Resources.Blue_16,
                    "This is a tooltip for Button 1");

                return myButtonData1.Data;
            }
        }
    }

}
