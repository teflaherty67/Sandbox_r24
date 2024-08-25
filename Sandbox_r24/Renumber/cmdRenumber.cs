﻿using Autodesk.Revit.DB.Architecture;
using Sandbox_r24.Common;

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
            
            // open the form

            // get the current view
            View curView = curDoc.ActiveView;

            // set the form to display based on the current view
            if (curView is Autodesk.Revit.DB.ViewPlan)
            {
                List<string> catList = new List<string>{ "Doors", "Grids", "Rooms", "Walls", "Windows" };      
            }
            else if (curView is Autodesk.Revit.DB.ViewSection)
            {
                List<string> catList = new List<string> { "Grids", "Levels" };
            }
            else if (curView is Autodesk.Revit.DB.ViewSheet)
            {
                List<string> catList = new List<string> { "Viewports" };
            }

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
