﻿using Sandbox_r24.Common;
using Sandbox_r24.Classes;

namespace Sandbox_r24
{
    [Transaction(TransactionMode.Manual)]
    public class cmdUpdateVTs : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // this is a variable for the Revit application
            UIApplication uiapp = commandData.Application;

            // this is a variable for the current Revit model
            Document curDoc = uiapp.ActiveUIDocument.Document;

            // this is a variable for the current Revit model in the UI
            UIDocument uidoc = uiapp.ActiveUIDocument;

            // get all the view templates in the project
            List<View> curVTs = Utils.GetAllViewTemplates(curDoc);

            // get all the views in the project
            List<View> nonTemplateViews = Utils.GetAllNonTemplateViews(curDoc);

            // set the path to the view template file
            string templateDoc = "S:\\Shared Folders\\Lifestyle USA Design\\Library 2025\\Template\\View Templates.rvt";

            // create a variable for the source document
            Document sourceDoc = uidoc.Application.OpenAndActivateDocument(templateDoc).Document;

            // create a transaction group
            using (TransactionGroup tGroup = new TransactionGroup(curDoc, "Update View Templates"))
            {
                // create the 1st transaction
                using (Transaction t = new Transaction(curDoc))
                {
                    // start the transaction group
                    tGroup.Start();

                    #region Delete View Templates

                    // start the 1st transaction
                    t.Start("Delete View Templates");

                    // delete all view templates that start with a letter or a number
                    foreach (View curVT in curVTs)
                    {
                        // get the name of the view template
                        string curName = curVT.Name;

                        // check if first character is letter
                        bool isLetter = !String.IsNullOrEmpty(curName) && Char.IsLetter(curName[0]);

                        // check if first two charactera is number                    
                        bool isNumber = !String.IsNullOrEmpty(curName) && Char.IsNumber(curName[0]);

                        // if yes, delete it
                        if (isLetter == true || isNumber == true)
                        {
                            try
                            {
                                curDoc.Delete(curVT.Id);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }

                    // commit the 1st transaction
                    t.Commit();

                    #endregion

                    // create a variable for the target document                  
                    Document targetDoc = uidoc.Document;

                    // get the view templates from the source document
                    List<View> listViewTemplates = new FilteredElementCollector(sourceDoc)
                        .OfClass(typeof(View))
                        .Cast<View>()
                        .Where(v => v.IsTemplate)
                        .ToList();

                    #region Transfer View Templates

                    // start the 2nd transaction
                    t.Start("Transfer View Teamplates");

                    // transfer the vew templates from the source document
                    foreach (View sourceTemplate in listViewTemplates)
                    {
                        ElementId newTemplateID = Utils.ImportViewTemplates(sourceDoc, sourceTemplate, targetDoc);
                    }

                    t.Commit();

                    #endregion

                    // create a variable for the new view template
                    View newViewTemp = null;

                    #region Assign View Templates

                    // start the 3rd transaction
                    t.Start("Assign View Teamplates");

                    foreach (View curView in nonTemplateViews)
                    {
                        // assign the appropriate view template
                        if (curView.Name.Contains("Annotation", StringComparison.Ordinal))
                        {
                            newViewTemp = Utils.GetViewTemplateByNameContains(curDoc, "Annotations");

                            curView.ViewTemplateId = newViewTemp.Id;
                        }
                        else if (curView.Name.Contains("Dimensions", StringComparison.Ordinal))
                        {
                            newViewTemp = Utils.GetViewTemplateByNameContains(curDoc, "Dimensions");

                            curView.ViewTemplateId = newViewTemp.Id;
                        }
                        else if (curView.Category.Equals("02:Exterior Elevations"))
                        {
                            newViewTemp = Utils.GetViewTemplateByCategoryEquals(curDoc, "02:Exterior Elevations");

                            curView.ViewTemplateId = newViewTemp.Id;
                        }
                        else if (curView.Name.Contains("Roof", StringComparison.Ordinal))
                        {
                            newViewTemp = Utils.GetViewTemplateByNameContains(curDoc, "Roof");

                            curView.ViewTemplateId = newViewTemp.Id;
                        }
                        else if (curView.Category.Equals("04:Sections"))
                        {
                            newViewTemp = Utils.GetViewTemplateByCategoryEquals(curDoc, "04:Sections");

                            curView.ViewTemplateId = newViewTemp.Id;
                        }
                        else if (curView.Category.Equals("05:Interior Elevations"))
                        {
                            newViewTemp = Utils.GetViewTemplateByCategoryEquals(curDoc, "05:Interior Elevations");

                            curView.ViewTemplateId = newViewTemp.Id;
                        }
                        else if (curView.Name.Contains("Electrical", StringComparison.Ordinal))
                        {
                            newViewTemp = Utils.GetViewTemplateByNameContains(curDoc, "Electrical");

                            curView.ViewTemplateId = newViewTemp.Id;
                        }
                        else if (curView.Name.Contains("Form", StringComparison.Ordinal))
                        {
                            newViewTemp = Utils.GetViewTemplateByNameContains(curDoc, "Form");

                            curView.ViewTemplateId = newViewTemp.Id;
                        }
                        else if (curView.Category.Equals("10:Floor Areas"))
                        {
                            newViewTemp = Utils.GetViewTemplateByCategoryEquals(curDoc, "10:Floor Areas");

                            curView.ViewTemplateId = newViewTemp.Id;
                        }
                        else if (curView.Category.Equals("11:Frame Areas"))
                        {
                            newViewTemp = Utils.GetViewTemplateByCategoryEquals(curDoc, "11:Frame Areas");

                            curView.ViewTemplateId = newViewTemp.Id;
                        }
                        else if (curView.Category.Equals("12:Attic Areas"))
                        {
                            newViewTemp = Utils.GetViewTemplateByCategoryEquals(curDoc, "12:Attic Areas");

                            curView.ViewTemplateId = newViewTemp.Id;
                        }
                    }

                    // commit the 3rd transaction
                    t.Commit();

                    #endregion

                    tGroup.Assimilate();
                }
            }

            return Result.Succeeded;
        }

        internal static PushButtonData GetButtonData()
        {
            // use this method to define the properties for this command in the Revit ribbon
            string buttonInternalName = "btnCommand2_1";
            string buttonTitle = "Update\rView Templates";
            string methodBase = MethodBase.GetCurrentMethod().DeclaringType?.FullName;

            if (methodBase == null)
            {
                throw new InvalidOperationException("MethodBase.GetCurrentMethod().DeclaringType?.FullName is null");
            }
            else
            {
                clsButtonData myButtonData1 = new Classes.clsButtonData(
                    buttonInternalName,
                    buttonTitle,
                    methodBase,
                    Properties.Resources.Yellow_32,
                    Properties.Resources.Yellow_16,
                    "Updates View Templates to current standards and applies them to the views");

                return myButtonData1.Data;
            }
        }
    }
}
