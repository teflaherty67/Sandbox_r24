namespace Sandbox_r24.Common
{
    internal static class Utils
    {
        internal static RibbonPanel CreateRibbonPanel(UIControlledApplication app, string tabName, string panelName)
        {
            RibbonPanel currentPanel = GetRibbonPanelByName(app, tabName, panelName);

            if (currentPanel == null)
                currentPanel = app.CreateRibbonPanel(tabName, panelName);

            return currentPanel;
        }

        internal static RibbonPanel GetRibbonPanelByName(UIControlledApplication app, string tabName, string panelName)
        {
            foreach (RibbonPanel tmpPanel in app.GetRibbonPanels(tabName))
            {
                if (tmpPanel.Name == panelName)
                    return tmpPanel;
            }

            return null;
        }

        #region Views

        internal static List<View> GetAllViews(Document curDoc)
        {
            {
                FilteredElementCollector m_colviews = new FilteredElementCollector(curDoc);
                m_colviews.OfCategory(BuiltInCategory.OST_Views);

                List<View> m_views = new List<View>();
                foreach (View x in m_colviews.ToElements())
                {
                    if (x.IsTemplate == false)

                        m_views.Add(x);
                }

                return m_views;
            }
        }

        internal static List<View> GetAllViewsByNameContains(Document curDoc, string v)
        {
            throw new NotImplementedException();
        }

        internal static List<View> GetAllViewsByNameContains(Document curDoc, string v1, string v2)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Categories

        internal static List<Element> GetCategoryByName(Document curDoc, BuiltInCategory bicTags)
        {
            List<Element> m_returnCat = new List<Element>();

            FilteredElementCollector m_colCat = new FilteredElementCollector(curDoc)
                .OfCategory(bicTags)
                .WhereElementIsElementType();

            foreach (Element curCat in m_colCat)
            {
                m_returnCat.Add(curCat);
            }

            return m_returnCat;
        }

        #endregion
    }
}