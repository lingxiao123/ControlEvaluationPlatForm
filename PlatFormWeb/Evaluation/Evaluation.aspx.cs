using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using DbAccess;
using System.Data;

namespace PlatFormWeb.Evaluation
{
    public partial class Evaluation :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            string sql = string.Format("select tl.Id, ti.Years,ti.Code as TaskCode,ti.TaskName,a.Code,a.AgencyName,a.Person,tl.Status,tl.SelfCode,tl.SelfName,tl.SelfTime,tl.ChargeCode,tl.ChargeName,tl.ChargeTime,tl.FinanceCode,tl.FinanceName,tl.FinanceTime,tl.Remark from TaskList as tl left join TaskInfo as ti on tl.TaskId=ti.Id left join Agency as a on tl.ObjectCode=a.Code");
            Grid1.RecordCount = GetTotalCount(sql);
            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(sql);
            if (table.Rows.Count>0)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row["Status"].ToString()=="1")
                    {
                        row["Status"] = "单位未自评";
                    }
                    if (row["Status"].ToString() == "2")
                    {
                        row["Status"] = "主管未审核";
                    }
                    if (row["Status"].ToString() == "3")
                    {
                        row["Status"] = "财政未审核";
                    }
                    if (row["Status"].ToString() == "4")
                    {
                        row["Status"] = "已评价";
                    }
                }
            }
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
            LoadData();
        }

    }
}