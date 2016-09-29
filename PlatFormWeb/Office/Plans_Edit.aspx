<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Plans_Edit.aspx.cs" Inherits="PlatFormWeb.Office.Plans_Edit" %>

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
                        <f:TextBox ID="txtPlanName" runat="server" Label="计划名称" Text="" LabelAlign="Right"></f:TextBox>
                        <f:TextBox ID="trgAddUser"  runat="server" Label="内控对象" LabelAlign="Right"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:DatePicker runat="server" Required="true" Readonly="true" Label="开始日期" DateFormatString="yyyy-MM-dd" EmptyText="请选择开始日期"
                            ID="dpAddTimeBegin" ShowRedStar="True" LabelAlign="Right">
                        </f:DatePicker>
                        <f:DatePicker ID="dpAddTimeEnd" Required="true" Readonly="true" Label="结束日期"  CompareControl="dpAddTimeBegin" DateFormatString="yyyy-MM-dd"
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
                        <f:HtmlEditor runat="server" Label="计划内容" ID="HtmlEditor1" Height="500px" LabelAlign="Right">
                        </f:HtmlEditor>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
