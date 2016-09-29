using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbAccess;
using System.Data;
using FineUI;

namespace PlatFormWeb.iframe
{
    public partial class SelectCode :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            string sql = "select Id,Code,AgencyName from Agency";
            DataTable dt = DBAccess.QueryDataTable(sql);
            gdUserInfo.DataSource = dt;
            gdUserInfo.DataBind();
        }
        protected void btnGetUser_Click(object sender, EventArgs e)
        {
            int[] selections = gdUserInfo.SelectedRowIndexArray;
            string ids = string.Empty;
            string names = string.Empty;
            foreach (int rowIndex in selections)
            {
                ids = ids + gdUserInfo.DataKeys[rowIndex][1] + ',';
                names = names + gdUserInfo.DataKeys[rowIndex][0] + ',';
            }
            if (ids.Length > 1)
            {
                ids = ids.Substring(0, ids.Length - 1);
            }
            if (names.Length > 1)
            {
                names = names.Substring(0, names.Length - 1);
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(ids, names) + ActiveWindow.GetHideReference());
        }
    }
}