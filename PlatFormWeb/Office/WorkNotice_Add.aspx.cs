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
    public partial class WorkNotice_Add :PageBase
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
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            string name = txtNoticeName.Text.Trim();           
            string theme = txtNoticeTheme.Text.Trim();
            string content = HtmlEditor1.Text;
            if (string.IsNullOrEmpty(name))
            {
                Alert.ShowInTop("通知名称不能为空");
                return;
            }
            if (string.IsNullOrEmpty(theme))
            {
                Alert.ShowInTop("通知主题不能为空");
                return;
            }
            if (string.IsNullOrEmpty(content))
            {
                Alert.ShowInTop("通知内容不能为空");
                return;
            }
            string sql = string.Format("insert into WorkNotice(NoticeName,NoticeTheme,NoticeContent,Status,AuthorName,AddTime,Remark) values('{0}','{1}','{2}',{3},'{4}','{5}','{6}')",name,theme,content,1,Session["UserName"],DateTime.Now,txtRemark.Text.Trim());
            int count = DBAccess.ExecTransSql(sql);
            if (count>0)
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