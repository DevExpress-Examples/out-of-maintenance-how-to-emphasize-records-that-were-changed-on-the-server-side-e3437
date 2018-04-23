using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void grid_CustomJSProperties(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventArgs e) {
        Int32 startIndex = grid.PageIndex * grid.SettingsPager.PageSize;
        Int32 end = Math.Min(grid.VisibleRowCount, startIndex + grid.SettingsPager.PageSize);

        Object[] rowIndexes = new object[end - startIndex],
            locks = new object[end - startIndex];

        for (Int32 i = startIndex; i < end; i++) {
            rowIndexes[i - startIndex] = i;
            locks[i - startIndex] = grid.GetRowValues(i, "Lock");
        }

        e.Properties["cpRowIndexes"] = rowIndexes;
        e.Properties["cpLocks"] = locks;
    }
}