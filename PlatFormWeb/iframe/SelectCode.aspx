<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectCode.aspx.cs" Inherits="PlatFormWeb.iframe.SelectCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1"></f:PageManager>
        <f:Panel ID="Panel1" runat="server" Width="100%" ShowBorder="false" ShowHeader="false">
            <Items>
                <f:Panel ID="pannelMain" runat="server" ShowHeader="false" ShowBorder="false">
                    <Toolbars>
                        <f:Toolbar ID="toobar1" runat="server">
                            <Items>
                                <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server"></f:ToolbarSeparator>
                                <f:Button ID="btnGetUser" runat="server" Icon="Accept" Text="选择" OnClick="btnGetUser_Click"></f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server"></f:ToolbarSeparator>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Items>
                        <f:HiddenField ID="hdCodeID" runat="server"></f:HiddenField>
                        <f:Form ID="form3" runat="server" ShowHeader="false" ShowBorder="false" LabelAlign="Right">
                            <Items>
                                <f:Grid runat="server" Title="内控对象列表" ID="gdUserInfo" ShowHeader="false" ShowBorder="false" ShowGridHeader="true"
                                    EnableCheckBoxSelect="true" KeepCurrentSelection="true" DataKeyNames="Code,AgencyName">
                                    <Columns>
                                        <f:RowNumberField ID="RowNum" runat="server" HeaderText="序号" Width="60px"></f:RowNumberField>
                                        <f:BoundField ID="Code" DataField="Code" HeaderText="编码"></f:BoundField>
                                        <f:BoundField ID="AgencyName" DataField="AgencyName" HeaderText="对象名称"></f:BoundField>
                                    </Columns>
                                </f:Grid>
                            </Items>
                        </f:Form>
                    </Items>
                </f:Panel>
                <f:Form ID="form2" runat="server" ShowHeader="false" ShowBorder="false">
                    <Items>
                    </Items>
                </f:Form>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
