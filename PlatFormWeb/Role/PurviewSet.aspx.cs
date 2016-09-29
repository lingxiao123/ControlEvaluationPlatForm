using System;
using System.Collections.Generic;
using System.Linq;
using FineUI;
using System.Data;
using DbAccess;

namespace PlatFormWeb.Role
{
    public partial class PurviewSet :PageBase
    {
        string GroupCode = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GroupCode = Request.QueryString["GroupCode"];
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                BindBaseSource(GroupCode);

                //loadData(id);
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            GroupCode = Request.QueryString["GroupCode"];
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
            //PageInit(GroupCode);
            //loadData(id);
        }
        private void BindBaseSource(string GroupCode)
        {
            #region BindMenuSource
            string sql1 = string.Empty;
            sql1 = sql1 + "select AcModuleTitleCode,AcModuleTitle,AcTypeCode,AcType,aiunjhd.AcCode,AcName,";
            sql1 = sql1 + "case gr.AcValue when '0' then 'false'  when '1' then 'true' else 'false' end as AcValue from AccessInfo aiunjhd ";
            sql1 = sql1 + "left join GroupRole gr on aiunjhd.AcCode = gr.AcCode and gr.GroupCode='" + GroupCode + "'  where AcTypeCode = 'mtc_Menu'";
            DataTable dt1 = DBAccess.QueryDataTable(sql1);
            gdMenu.DataSource = dt1;
            gdMenu.DataBind();
            #endregion
            #region BindServiceSource\
            string sql2 = string.Empty;
            sql2 = sql2 + "select AcModuleTitleCode,AcModuleTitle,AcTypeCode,AcType,aiunjhd.AcCode,AcName,";
            sql2 = sql2 + "case gr.AcValue when '0' then 'false'  when '1' then 'true' else 'false' end as AcValue from AccessInfo aiunjhd ";
            sql2 = sql2 + "left join GroupRole gr on aiunjhd.AcCode = gr.AcCode and gr.GroupCode='" + GroupCode + "' where AcTypeCode = 'mtc_Service'";
            DataTable dt2 = DBAccess.QueryDataTable(sql2);
            gdService.DataSource = dt2;
            gdService.DataBind();
            #endregion
        }
        #region 注释的代码
        //public void loadData(string str)
        //{
        //    string sql = "select * from Menu";
        //    DataTable dt = DBAccess.QueryDataTable(sql);
        //    string sql_rolemenu = "select MenuName from RoleMenu where RoleId=" + Convert.ToInt32(str) + "";
        //    DataTable dts = DBAccess.QueryDataTable(sql_rolemenu);
        //    int len = dt.Rows.Count % 3;
        //    int lens = Convert.ToInt32(dt.Rows.Count / 3);
        //    len = len + lens;
        //    int n = 0;
        //    for (int i = 1; i <= len; i++)
        //    {
        //        FormRow row = new FormRow();
        //        row.ID = "row" + i;
        //        Form2.Rows.Add(row);
        //        //CheckBoxList cbl = new CheckBoxList();
        //        //cbl.ID = "chkList"+i;
        //        //Form2.Items.Add(cbl);

        //        for (int j = 0; j < 3; j++)
        //        {
        //            if (n >= dt.Rows.Count)
        //            {
        //                return;
        //            }
        //            CheckBox chk = new CheckBox();
        //            chk.ID = "chk" + (n + 1);
        //            chk.Text = dt.Rows[n]["MenuName"].ToString();
        //            //chk.
        //            //CheckItem ci = new CheckItem();
        //            //ci.Text = dt.Rows[n]["MenuName"].ToString();
        //            //ci.Value = dt.Rows[n]["Id"].ToString();
        //            if (dts.Rows.Count > 0)
        //            {
        //                for (int k = 0; k < dts.Rows.Count; k++)
        //                {
        //                    if (dts.Rows[k]["MenuName"].ToString() == dt.Rows[n]["MenuName"].ToString())
        //                    {
        //                        chk.Checked = true;
        //                    }
        //                }
        //            }
        //            row.Items.Add(chk);
        //            n++;
        //        }

        //    }
        //    FormRow rows = new FormRow();
        //    rows.ID = "rowhidden";
        //    //rows.ClientID = "rowhidden";
        //    rows.ClientIDMode = System.Web.UI.ClientIDMode.Static;
        //    Form2.Rows.Add(rows);

        //    HiddenField hf = new HiddenField();
        //    hf.ID = "hiddenRole";
        //    hf.Hidden = true;
        //    hf.Text = str;
        //    rows.Items.Add(hf);

        //    HiddenField hfs = new HiddenField();
        //    hfs.ID = "hiddenLength";
        //    hfs.Hidden = true;
        //    hfs.Text = len.ToString();
        //    rows.Items.Add(hfs);
        //}


        #endregion
        private void PageInit(string GroupCode)
        {
            //Sql得到权限分类
            string sql1 = "select COUNT(AcTypeCode) as count, AcType,AcTypeCode from AccessInfo group by AcType,AcTypeCode;";
            DataTable dt1 = DBAccess.QueryDataTable(sql1);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                //循环分类，每个分类下有不同的模块
                foreach (DataRow row1 in dt1.Rows)
                {
                    Panel panel1 = new Panel();
                    panel1.ID = row1["AcTypeCode"].ToString();
                    panel1.EnableCollapse = true;
                    panel1.Expanded = true;
                    panel1.Title = row1["AcType"].ToString();
                    Form2.Items.Add(panel1);
                    //获取该分类下的模块
                    string sql2 = "select COUNT(AcModuleTitleCode) as count,AcModuleTitle,AcModuleTitleCode from AccessInfo where AcTypeCode='"
                        + row1["AcTypeCode"].ToString() + "' group by AcModuleTitle,AcModuleTitleCode;";
                    DataTable dt2 = DBAccess.QueryDataTable(sql2);
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        //循环每个分类下的每个模块，每个模块有不同的权限
                        foreach (DataRow row2 in dt2.Rows)
                        {
                            Grid gd = new Grid();
                            FormRow fr = new FormRow();
                            fr.ID = "Fr" + row2["AcModuleTitleCode"].ToString();
                            panel1.Items.Add(fr);
                            fr.Items.Add(gd);
                            //IList<string> strs = new List<string>();
                            //strs.Add("MenuCode");
                            //strs.Add("MenuName");
                            gd.ID = row2["AcModuleTitleCode"].ToString();
                            gd.Title = row2["AcModuleTitle"].ToString();
                            gd.ShowHeader = true;
                            gd.DataKeyNames = new string[] { "AcCode", "AcName" }; //strs.ToArray();
                            gd.ShowBorder = true;
                            gd.EnableRowLines = true;

                            BoundField bf = new BoundField();
                            bf.DataField = "AcName";
                            bf.DataFormatString = "{0}";
                            bf.HeaderText = "名称";
                            gd.Columns.Add(bf);

                            bf = new BoundField();
                            bf.DataField = "AcCode";
                            bf.DataFormatString = "{0}";
                            bf.HeaderText = "编号";
                            bf.Hidden = true;
                            gd.Columns.Add(bf);

                            CheckBoxField chkf = new CheckBoxField();
                            chkf.ColumnID = "chkAc";
                            chkf.DataField = "AcValue";
                            chkf.HeaderText = "授权";
                            chkf.RenderAsStaticField = false;
                            gd.Columns.Add(chkf);
                            //获取该模块下的所有权限
                            string sql3 = string.Empty;
                            sql3 = sql3 + "select ";
                            sql3 = sql3 + "a.AcCode,a.AcName, ";
                            sql3 = sql3 + "case gr.AcValue ";
                            sql3 = sql3 + "when '0' then 'false' ";
                            sql3 = sql3 + "when '1' then 'true' ";
                            sql3 = sql3 + "else 'false' end ";
                            sql3 = sql3 + "as AcValue ";
                            sql3 = sql3 + "from AccessInfo a ";
                            sql3 = sql3 + "left ";
                            sql3 = sql3 + "join GroupRole gr on gr.AcCode = a.AcCode and groupCode in ";
                            sql3 = sql3 + " (select GroupCode from UserGroup ug where ug.GroupCode = '" + GroupCode + "') where a.AcModuleTitleCode = '" + row2["AcModuleTitleCode"].ToString() + "'; ";
                            DataTable dt3 = DBAccess.QueryDataTable(sql3);
                            //gd.DataSource = dt3;
                            //gd.DataBind();
                        }
                    }
                }
            }
        }
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Empty;
                sql = GetNeedSaveSQL();
                DBAccess.ExecSql(sql);
                Alert.ShowInTop("操作成功！");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BindBaseSource(GroupCode);
            }
            #region 弃置的代码
            // 1. 这里放置保存窗体中数据的逻辑
            //try
            //{
            //    FormRow row = Form2.FindControl("rowhidden") as FormRow;
            //    HiddenField hf = row.FindControl("hiddenLength") as HiddenField;
            //    string length = hf.Text;

            //    for (int i = 0; i < Form2.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < Form2.Rows[i].Items.Count; j++)
            //        {
            //            CheckBox chk = Form2.Rows[i].Items[j] as CheckBox;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    WriteLog.WriteError(ex);
            //}

            //// 2. 关闭本窗体，然后刷新父窗体
            //PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference()); 
            #endregion
        }
        private string GetNeedSaveSQL()
        {
            string sql = string.Empty;
            CheckBoxField chkf1 = gdMenu.FindColumn("c_m_IsAllow") as CheckBoxField;
            foreach (GridRow row in gdMenu.Rows)
            {
                string IsChk1 = string.Empty;
                IsChk1 = chkf1.GetCheckedState(row.RowIndex) ? "1" : "0";
                string SelSql = "select id from GroupRole where GroupCode='" + GroupCode + "' and AcCode='" + row.DataKeys.GetValue(0).ToString() + "'";
                if (DBAccess.CheckIsExist(SelSql))
                {
                    sql = sql + " update GroupRole set AcValue='" + IsChk1 + "' where GroupCode='" + GroupCode + "' and AcCode='" + row.DataKeys.GetValue(0).ToString() + "';";
                }
                else
                {
                    sql = sql + " Insert into GroupRole values('" + GroupCode + "','" + row.DataKeys.GetValue(0).ToString() + "','" + IsChk1 + "');";
                }
            }
            CheckBoxField chkf2 = gdService.FindColumn("c_s_IsAllow") as CheckBoxField;
            foreach (GridRow row in gdService.Rows)
            {
                string IsChk2 = string.Empty;
                IsChk2 = chkf2.GetCheckedState(row.RowIndex) ? "1" : "0";
                string SelSql = "select id from GroupRole where GroupCode='" + GroupCode + "' and AcCode='" + row.DataKeys.GetValue(0).ToString() + "'";
                if (DBAccess.CheckIsExist(SelSql))
                {
                    sql = sql + " update GroupRole set AcValue='" + IsChk2 + "' where GroupCode='" + GroupCode + "' and AcCode='" + row.DataKeys.GetValue(0).ToString() + "';";
                }
                else
                {
                    sql = sql + " Insert into GroupRole values('" + GroupCode + "','" + row.DataKeys.GetValue(0).ToString() + "','" + IsChk2 + "');";
                }
            }
            return sql;
        }
        IList<int> intgdMenu = new List<int>();
        IList<int> intgdService = new List<int>();
        protected void gdMenu_RowDataBound(object sender, GridRowEventArgs e)
        {
            //if (e.RowIndex == 0)
            //{
            //    intgdMenu = new List<int>();
            //}
            if (true)//(e.RowIndex > 0)
            {
                string AcCode = gdMenu.Rows[e.RowIndex].DataKeys.GetValue(0).ToString();
                string sql = string.Empty;
                DataRowView row = e.DataItem as DataRowView;
                sql = sql + "select case gr.AcValue  when '0' then 'false'  when '1' then 'true'  ";
                sql = sql +
                    "else 'false' end  as AcValue  from AccessInfo a  left join GroupRole gr on a.AcCode=gr.AcCode and gr.GroupCode='"
                    + Request.QueryString["GroupCode"]
                    + "' where a.AcCode='"
                    + e.Values[6] + "';";
                string str = DBAccess.QueryValue(sql).ToString();
                bool AcValue = Convert.ToBoolean(str);
                if (AcValue)
                {
                    intgdMenu.Add(e.RowIndex);
                }
            }
            gdMenu.SelectedRowIndexArray = intgdMenu.ToArray();
        }

        protected void gdService_RowDataBound(object sender, GridRowEventArgs e)
        {
            //if (e.RowIndex == 0)
            //{
            //    intgdService = new List<int>();
            //}
            if (true)//(e.RowIndex > 0)
            {
                string AcCode = gdService.Rows[e.RowIndex].DataKeys.GetValue(0).ToString();
                string sql = string.Empty;
                sql = sql + "select case gr.AcValue  when '0' then 'false'  when '1' then 'true'  ";
                sql = sql + "else 'false' end  as AcValue  from AccessInfo a  left join GroupRole gr on a.AcCode=gr.AcCode and gr.GroupCode='"
                    + Request.QueryString["GroupCode"]
                    + "' where a.AcCode='"
                    + e.Values[6] + "';";
                string str = DBAccess.QueryValue(sql).ToString();
                bool AcValue = Convert.ToBoolean(str);
                if (AcValue)
                {
                    intgdService.Add(e.RowIndex);
                }
            }
            gdService.SelectedRowIndexArray = intgdService.ToArray();
        }
    }
}