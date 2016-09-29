using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using DbAccess;

namespace PlatFormWeb.Office
{
    public partial class WorkNotice_Edit :PageBase
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
            string sql = string.Format("select * from WorkNotice where Id={0}",id);
            DataTable dt = DBAccess.QueryDataTable(sql);
            if (dt.Rows.Count>0)
            {
                txtNoticeName.Text = dt.Rows[0]["NoticeName"].ToString();
                txtNoticeTheme.Text = dt.Rows[0]["NoticeTheme"].ToString();
                txtRemark.Text = dt.Rows[0]["Remark"].ToString();
                HtmlEditor1.Text = dt.Rows[0]["NoticeContent"].ToString();
            }
        }

    }
}