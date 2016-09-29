using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using PlatFormWeb.Utility;
using DbAccess;
namespace PlatFormWeb.Role
{
    public partial class UserRole_Set :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Session["UserId"].ToString()))
                {                    
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                    Alert.ShowInTop("您未选择用户，请至少选中一个用户！");
                }
                LoadData();
            }
        }

        private void LoadData()
        {
            string sql = string.Format("select Id,GroupCode,GroupName from GroupInfo");
            Grid1.RecordCount = GetTotalCount(sql);
            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(sql);
            // 3.绑定到Grid
            Grid1.DataSource = table;
            Grid1.DataBind();

        }
        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount(string sql)
        {
            DataTable dt = DBAccess.QueryDataTable(sql);
            return dt.Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(string sql)
        {
            int pageIndex = Grid1.PageIndex;
            int pageSize = Grid1.PageSize;

            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataTable dt = DBAccess.QueryDataTable(sql);

            //DataTable table2 = DataSourceUtil.GetDataTable2();
            DataTable table2 = dt;
            DataView view2 = table2.DefaultView;
            view2.Sort = String.Format("{0} {1}", sortField, sortDirection);

            DataTable table = view2.ToTable();

            DataTable paged = table.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > table.Rows.Count)
            {
                rowend = table.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(table.Rows[i]);
            }

            return paged;
        }


        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            //Grid1.PageIndex = e.NewPageIndex;

            LoadData();
        }

        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            //Grid1.SortDirection = e.SortDirection;
            //Grid1.SortField = e.SortField;

            LoadData();
        }

        protected void Grid1_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            object[] keys = Grid1.DataKeys[e.RowIndex];
            string sql_list = "select * from UserGroup where UsedId="+ Session["UserId"] + " and GroupCode='"+ keys[1] + "'";
            DataTable dt = DBAccess.QueryDataTable(sql_list);
            if (dt.Rows.Count>0)
            {
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            else {
                string sql =string.Format("insert into UserGroup(UsedId,GroupCode) values({0},'{1}')",Session["UserId"],keys[1]);
                int count = DBAccess.ExecTransSql(sql);
                if (count>0)
                {
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                }
                else
                {
                    Alert.ShowInTop("追加失败");
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                }
            }
        }
    }
}