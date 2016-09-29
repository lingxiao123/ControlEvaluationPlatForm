<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Plans_Add.aspx.cs" Inherits="PlatFormWeb.Office.Plans_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="SimpleForm1" />
        <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
            AutoScroll="true" BodyPadding="10px" runat="server">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSaveRefresh" Text="保存" runat="server" Icon="SystemSave" OnClick="btnSaveRefresh_Click">
                        </f:Button>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtPlanName" runat="server" Label="计划名称" Text="" LabelAlign="Right"></f:TextBox>
                        <f:TriggerBox ID="trgAddUser" TriggerIcon="Search" EnableEdit="false" runat="server" Label="内控对象" LabelAlign="Right"></f:TriggerBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:DatePicker runat="server" Required="true" Label="开始日期" DateFormatString="yyyy-MM-dd" EmptyText="请选择开始日期"
                            ID="dpAddTimeBegin" ShowRedStar="True" LabelAlign="Right">
                        </f:DatePicker>
                        <f:DatePicker ID="dpAddTimeEnd" Required="true" Label="结束日期" Readonly="false" CompareControl="dpAddTimeBegin" DateFormatString="yyyy-MM-dd"
                            CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" runat="server" ShowRedStar="True" LabelAlign="Right">
                        </f:DatePicker>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtPrincipal" runat="server" Label="负责人" Text="" LabelAlign="Right"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtRemark" runat="server" Label="备注" Text="" LabelAlign="Right"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:HtmlEditor runat="server" Label="计划内容" ID="HtmlEditor1" Height="300px" LabelAlign="Right">
                        </f:HtmlEditor>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
        <f:HiddenField ID="hdObjectCode" runat="server"></f:HiddenField>
        <f:Window ID="Window1" Title="内控对象" Hidden="true" EnableIFrame="true" runat="server"
            EnableMaximize="true" EnableResize="true" Target="Self" 
            IsModal="True" Width="650px" Height="450px">
        </f:Window>
    </form>
</body>
</html>
