using Sandbox_r24.Common;

namespace Sandbox_r24
{
    [Transaction(TransactionMode.Manual)]
    public class cmdTagSelectedViews : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // this is a variable for the Revit application
            UIApplication uiapp = commandData.Application;

            // this is a variable for the current Revit model
            Document curDoc = uiapp.ActiveUIDocument.Document;

            // put any code needed for the form here

            // create a list of the categories
            List<string> cats = new List<string>{ "Casework", "Detail Items", "Doors", "Electrical Fixtures",
                "Generic Models", "Lighting Fixtures", "Mechanical Equipment", "Multi-Category",
                "Plumbing Fixtures", "Property Line Segments", "Rooms", "Specialty Equipment",
                "Stairs", "Structrual Columns", "Structural Framing", "Walls", "Windows" };

            // get all the tags for the categories
            List<Element> caseworkTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_CaseworkTags);
            List<Element> detailTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_DetailComponentTags);
            List<Element> doorTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_DoorTags);
            List<Element> electricalTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_ElectricalFixtures);
            List<Element> genericTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_GenericModelTags);
            List<Element> lightingTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_LightingFixtureTags);
            List<Element> mechanicalTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_MechanicalEquipmentTags);
            List<Element> multiTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_MultiCategoryTags);
            List<Element> plumbingTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_PlumbingFixtureTags);
            List<Element> propertyTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_SitePropertyLineSegmentTags);
            List<Element> roomTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_RoomTags);
            List<Element> specialtyTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_SpecialityEquipmentTags);
            List<Element> stairTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_StairsTags);
            List<Element> columnTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_StructuralColumnTags);
            List<Element> framingTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_StructuralFramingTags);
            List<Element> wallTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_WallTags);
            List<Element> windowTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_WindowTags);

            // create list of tag orientations
            List<string> listTagOrients = new List<string> { "Horizontal", "Vertical" };



            // open form
            frmTagSelectedViews curForm = new frmTagSelectedViews()
            {
                Width = 800,
                Height = 450,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                Topmost = true,
            };

            curForm.ShowDialog();

            // get form data and do something

            // set leader variable
            string tLeader = "";

            if (curForm.GetCheckBoxLeader() == true)
            {
                tLeader = "true";
            }
            else
                tLeader = "false";

            // set leader length
            double lLength;



            // set leader orientation
            string tOrient = curForm.GetComboboxOrient();

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
