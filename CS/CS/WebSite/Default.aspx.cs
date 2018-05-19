using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page {

    protected void ASPxGridView1_DataBound (object sender, EventArgs e) {
        ASPxGridView grid = (ASPxGridView)sender;
        SaveJsProperties(grid);
    }
    protected void ASPxGridView1_CustomCallback (object sender, ASPxGridViewCustomCallbackEventArgs e) {
        ASPxGridView grid = (ASPxGridView)sender;
        switch (e.Parameters) {
            case "Next":
                grid.PageIndex += 1;
                break;
            case "Prev":
                grid.PageIndex -= 1;
                break;
        }
        SaveJsProperties(grid);
    }
    private void SaveJsProperties (ASPxGridView grid) {
        grid.JSProperties["cpPageCount"] = grid.PageCount;
        grid.JSProperties["cpPageIndex"] = grid.PageIndex;
    }
}
