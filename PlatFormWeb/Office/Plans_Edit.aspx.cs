using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbAccess;
using System.Data;
namespace PlatFormWeb.Office
{
    public partial class Plans_Edit :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"].ToString();
            string sql = string.Format("select * from Plans where Id={0}", id);
            DataTable dt = DBAccess.QueryDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                txtPlanName.Text = dt.Rows[0]["PlanName"].ToString();
                trgAddUser.Text = dt.Rows[0]["ObjectCode"].ToString()+" "+dt.Rows[0]["ObjectName"];
                txtPrincipal.Text = dt.Rows[0]["Principal"].ToString();
                dpAddTimeBegin.Text = Convert.ToDateTime(dt.Rows[0]["StartTime"]).ToString("yyyy-MM-dd");
                dpAddTimeEnd.Text = Convert.ToDateTime(dt.Rows[0]["EndTime"]).ToString("yyyy-MM-dd");
                txtRemark.Text = dt.Rows[0]["Remark"].ToString();
                HtmlEditor1.Text = dt.Rows[0]["Content"].ToString();
            }
        }
    }
}