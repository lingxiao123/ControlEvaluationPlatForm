using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineUI;
using DbAccess;
using System.Data;
namespace PlatFormWeb.Basis
{
    public partial class InternalObject :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData("");
                LoadTree();
            }
        }

        private void LoadData(string where)
        {
            string sql = "select * from Agency where 1=1 "+where;
            Grid1.RecordCount = GetTotalCount(sql);
            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(sql);
            // 3.绑定到Grid
            Grid1.DataSource = table;
            Grid1.DataBind();
        }
        private void getData(string str,ref DataTable dts)
        {
            if (dts.Rows.Count > 0)
            {
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    string sql = string.Format("select * from Agency where ParentCode='" + dts.Rows[i]["Code"] + "'");
                    DataTable dt = DBAccess.QueryDataTable(sql);
                    dts = dt;
                }               
            }
        }
        private void LoadTree()
        {
            string sql = "select * from Agency";
            // 模拟从数据库返回数据表
            DataTable table =DBAccess.QueryDataTable(sql);
            DataSet ds = new DataSet();
            ds.Tables.Add(table.Copy());
            ds.Relations.Add("TreeRelation", ds.Tables[0].Columns["Code"], ds.Tables[0].Columns["ParentCode"],false);
            

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (string.IsNullOrEmpty(row["ParentCode"].ToString()))
                {
                    TreeNode node = new TreeNode();
                    node.Text = row["AgencyName"].ToString();
                    node.Expanded = true;
                    node.NodeID = row["Code"].ToString();
                    node.EnableClickEvent = true;
                    Tree1.Nodes.Add(node);
                    ResolveSubTree(row, node);
                }
            }
        }
        private void ResolveSubTree(DataRow dataRow, TreeNode treeNode)
        {
            DataRow[] rows = dataRow.GetChildRows("TreeRelation");
            if (rows.Length > 0)
            {
                treeNode.Expanded = true;
                foreach (DataRow row in rows)
                {
                    TreeNode node = new TreeNode();
                    node.Text = row["AgencyName"].ToString();
                    node.EnableClickEvent = true;
                    node.NodeID = row["Code"].ToString();
                    treeNode.Nodes.Add(node);
                    ResolveSubTree(row, node);
                }
            }
        }
        protected void Tree1_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            string code = e.Node.NodeID.ToString();
            string where = "";
            where += " and Code like '%"+code+"%'";
            LoadData(where);

            string sql = string.Format("select * from Agency where Code='"+code+"'");
            DataTable dt = DBAccess.QueryDataTable(sql);
            if (dt.Rows.Count>0)
            {
                txtCode.Text = dt.Rows[0]["Code"].ToString();
                txtAgencyName.Text = dt.Rows[0]["AgencyName"].ToString();
                txtType.Text = dt.Rows[0]["Type"].ToString();
                txtIndustry.Text = dt.Rows[0]["Industry"].ToString();
                txtPerson.Text = dt.Rows[0]["Person"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                txtRemark.Text = dt.Rows[0]["Remark"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
            }

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
            //DataTable table2 = DataSourceUtil.GetDataTable2();
            DataTable dt = DBAccess.QueryDataTable(sql);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            //labResult.Text = HowManyRowsAreSelected(Grid1);
        }


        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            LoadData("");
        }

        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            //Grid1.SortDirection = e.SortDirection;
            //Grid1.SortField = e.SortField;
            LoadData("");
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            if (string.IsNullOrEmpty(code))
            {
                return;
            }
            string parentcode = txtParentCode.Text;
            string name = txtAgencyName.Text;
            string type = txtType.Text;
            string industry = txtIndustry.Text;
            string person = txtPerson.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string remark = txtRemark.Text;
            string address = txtAddress.Text;

            string sql = string.Format("insert into Agency(AgencyName,Type,Industry,Person,Email,Phone,Address,Code,ParentCode,Remark) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",name,type,industry,person,email,phone,address,code,parentcode,remark);
            int counts = DBAccess.ExecTransSql(sql);
            if (counts>0)
            {
                LoadData("");
                LoadTree();
            }
            else
            {

            }
        }
    }
}