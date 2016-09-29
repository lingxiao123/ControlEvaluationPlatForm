using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbAccess;
using System.Data;
using FineUI;
using PlatFormWeb.Utility;
namespace PlatFormWeb.Office
{
    public partial class Plans_List :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = Window1.GetShowReference("~/Office/Plans_Add.aspx", "", 800, 500);
                LoadData();
            }
        }

        private void LoadData()
        {
            string sql = string.Format("select Id,PlanName,ObjectCode,ObjectName,StartTime,EndTime,Principal,case Status when '1' then '已发布' end as Status,CompleteTime,AuthorName,AddTime,Remark from Plans");
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
            Grid1.PageIndex = e.NewPageIndex;

            LoadData();
        }

        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            //Grid1.SortDirection = e.SortDirection;
            //Grid1.SortField = e.SortField;

            LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selections = Grid1.SelectedRowIndexArray;
                if (selections.Length == 0)
                {
                    Alert.ShowInTop("您未选中数据,请重新选择！");
                    return;
                }
                string ids = "";
                foreach (int rowIndex in selections)
                {
                    ids += Grid1.DataKeys[rowIndex][0] + ",";
                }
                ids = ids.Substring(0, ids.LastIndexOf(','));
                string sql = "delete from Plans where Id in(" + ids + ")";
                int count = DBAccess.ExecTransSql(sql);
                if (count > 0)
                {
                    Alert.ShowInTop("删除成功");
                    LoadData();
                }
                else
                {
                    Alert.ShowInTop("删除失败");
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteError(ex);
            }
        }
    }
}