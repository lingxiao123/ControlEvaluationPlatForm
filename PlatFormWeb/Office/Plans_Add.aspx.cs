using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineUI;
using DbAccess;
using System.Data;

namespace PlatFormWeb.Office
{
    public partial class Plans_Add :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetControlEventHandler();
                LoadData();
            }
        }
        private void LoadData()
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }

        /// <summary>
        /// 处理部分控件的事件关联
        /// </summary>
        private void SetControlEventHandler()
        {
            trgAddUser.OnClientTriggerClick = Window1.GetSaveStateReference(trgAddUser.ClientID, hdObjectCode.ClientID)
                
                    + Window1.GetShowReference("~/iframe/SelectCode.aspx");
        }
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            string name = txtPlanName.Text.Trim();
            string content = HtmlEditor1.Text;
            string starttime = dpAddTimeBegin.Text;
            string endtime=dpAddTimeEnd.Text;
            string principal = txtPrincipal.Text;
            string remark = txtRemark.Text;
            string code = hdObjectCode.Text;
            string objectname = trgAddUser.Text;
            if (string.IsNullOrEmpty(name))
            {
                Alert.ShowInTop("通知名称不能为空");
                return;
            }
            if (string.IsNullOrEmpty(content))
            {
                Alert.ShowInTop("通知内容不能为空");
                return;
            }
            string sql = string.Format("insert into Plans(PlanName,ObjectCode,ObjectName,Content,StartTime,EndTime,Principal,Status,CompleteTime,AuthorName,AddTime,Remark) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}','{9}','{10}','{11}')", 
                name,code, objectname,content, starttime, endtime, principal,1,DateTime.Now.ToString("yyyy-MM-dd"),Session["UserName"],DateTime.Now,remark);
            int count = DBAccess.ExecTransSql(sql);
            if (count > 0)
            {
                Alert.ShowInTop("新增成功");
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("新增失败");
            }
        }
    }
}