<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Policy_Edit.aspx.cs" Inherits="PlatFormWeb.Office.Policy_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="SimpleForm1" />
        <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
            AutoScroll="true" BodyPadding="10px" runat="server">
            <Rows>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtNoticeName" runat="server" Label="制度名称" Text=""></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtNoticeTheme" runat="server" Label="制度主题" Text=""></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtRemark" runat="server" Label="备注" Text=""></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>                     
                        <f:HtmlEditor runat="server" Label="制度内容" ID="HtmlEditor1" Height="500px">
                        </f:HtmlEditor>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
