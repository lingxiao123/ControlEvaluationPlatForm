using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbAccess;
using FineUI;
using System.Data;
using PlatFormWeb.Utility;
namespace PlatFormWeb.User
{
    public partial class UserInfo_List :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnImport.OnClientClick = Window1.GetShowReference("~/User/UserInfo_Add.aspx");
                btnAddRole.OnClientClick = Window2.GetShowReference("~/Role/UserRole_Set.aspx");
                btnAdd.OnClientClick = Window3.GetShowReference("~/User/UserInfo_AddObject.aspx");
                Session["UserId"] = "";
                BindGrid("");
            }
        }

        #region BindGrid

        private void BindGrid(string str)
        {
            string sql = "select * from UserTable";
            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            Grid1.RecordCount = GetTotalCount(sql);
            int pageIndex = Grid1.PageIndex;
            int pageSize = Grid1.PageSize;

            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(sql,pageIndex,pageSize,sortField,sortDirection);
            // 3.绑定到Grid
            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        private void LoadRole(string str)
        {
            string sql = "select gi.GroupCode,gi.GroupName from UserGroup as ug left join GroupInfo as gi on ug.GroupCode=gi.GroupCode where 1=1 "+str;
            Grid5.RecordCount = GetTotalCount(sql);
            int pageIndex = Grid5.PageIndex;
            int pageSize = Grid5.PageSize;

            string sortField = Grid5.SortField;
            string sortDirection = Grid5.SortDirection;
            DataTable dt = GetPagedDataTable(sql, pageIndex, pageSize, sortField, sortDirection);
            Grid5.DataSource = dt;
            Grid5.DataBind();

        }

        private void LoadAgency(string str)
        {
            string sql = "select a.Code,a.AgencyName from UserAgency as ua left join Agency as a on ua.Code=a.Code where 1=1 "+str;
            Grid3.RecordCount = GetTotalCount(sql);
            int pageIndex = Grid3.PageIndex;
            int pageSize = Grid3.PageSize;

            string sortField = Grid3.SortField;
            string sortDirection = Grid3.SortDirection;
            DataTable dt = GetPagedDataTable(sql, pageIndex, pageSize, sortField, sortDirection);
            Grid3.DataSource = dt;
            Grid3.DataBind();
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
        private DataTable GetPagedDataTable(string sql,int pageIndex,int pageSize, string sortField, string sortDirection)
        {
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

        #endregion

        #region Events

        protected void Button1_Click(object sender, EventArgs e)
        {
            //labResult.Text = HowManyRowsAreSelected(Grid1);
        }


        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            //Grid1.PageIndex = e.NewPageIndex;

            BindGrid("");
        }

        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            //Grid1.SortDirection = e.SortDirection;
            //Grid1.SortField = e.SortField;

            BindGrid("");
        }

        #endregion



        protected void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, object>> modifiedDict = Grid1.GetModifiedDict();
            try
            {
                int count = 0;
                foreach (int rowIndex in modifiedDict.Keys)
                {
                    int rowID = Convert.ToInt32(Grid1.DataKeys[rowIndex][0]);
                    GridRow row = Grid1.Rows[rowIndex];
                    int status = Convert.ToInt32(Grid1.Rows[rowIndex].Values[2]);
                    string datetime = DateTime.Now.ToString("yyyy-MM-dd");
                    string sql = string.Format("update UserTable set Status={0},UpdateTime='{1}' where Id={2}", status, datetime, rowID);
                    count += DBAccess.ExecTransSql(sql);
                }
                if (count > 0)
                {
                    Alert.ShowInTop("修改成功");
                    BindGrid("");
                }
                else
                {
                    Alert.ShowInTop("修改失败");
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteError(ex);
            }
        }
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                try
                {
                    object[] keys = Grid1.DataKeys[e.RowIndex];
                    int id = Convert.ToInt32(keys[0]);
                    string sql = string.Format("update UserTable set Pwd='{0}' where Id={1}", DESEncrypt.Encrypt("123456"), id);
                    int count = DBAccess.ExecTransSql(sql);
                    if (count > 0)
                    {
                        Alert.ShowInTop("重置成功");
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteError(ex);
                }

            }
        }

        protected void Grid1_RowClick1(object sender, GridRowClickEventArgs e)
        {
            object[] keys = Grid1.DataKeys[e.RowIndex];
            hfUserId.Text = keys[0].ToString();
            Session["UserId"]= keys[0].ToString();
            string where = " and UsedId=" + keys[0]+"";
            LoadRole(where);
            LoadAgency(where);
        }

        protected void btnDeleteRole_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selections = Grid5.SelectedRowIndexArray;
                if (selections.Length == 0)
                {
                    Alert.ShowInTop("您未选中数据,请重新选择！");
                    return;
                }
                string ids = "";
                foreach (int rowIndex in selections)
                {
                    ids += Grid5.DataKeys[rowIndex][0] + ",";
                }
                ids = ids.Substring(0, ids.LastIndexOf(','));
                ids = StringHelper.SpiltStr(ids);
                string sql = "delete from UserGroup where GroupCode in(" + ids + ")";
                int count = DBAccess.ExecTransSql(sql);
                if (count > 0)
                {
                    Alert.ShowInTop("删除成功");
                    LoadRole("");
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

        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            try
            {
                int[] selections = Grid3.SelectedRowIndexArray;
                if (selections.Length == 0)
                {
                    Alert.ShowInTop("您未选中数据,请重新选择！");
                    return;
                }
                string ids = "";
                foreach (int rowIndex in selections)
                {
                    ids += Grid3.DataKeys[rowIndex][0] + ",";
                }
                ids = ids.Substring(0, ids.LastIndexOf(','));
                ids = StringHelper.SpiltStr(ids);
                string sql = "delete from UserAgency where Code in(" + ids + ")";
                int count = DBAccess.ExecTransSql(sql);
                if (count > 0)
                {
                    Alert.ShowInTop("删除成功");
                    LoadAgency("");
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