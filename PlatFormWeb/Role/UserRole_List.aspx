<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRole_List.aspx.cs" Inherits="PlatFormWeb.Role.UserRole_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" Width="100%" ShowBorder="false" ShowHeader="false" Layout="Region">
            <Toolbars>
                <f:Toolbar ID="toolb1" runat="server">
                    <Items>
                        <f:ToolbarSeparator ID="ToolbarSeparator4" runat="server"></f:ToolbarSeparator>
                        <f:Button ID="btnImport" runat="server" Text="角色设置"
                            Icon="Add" EnablePostBack="false">
                        </f:Button>
                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server"></f:ToolbarSeparator>
                        <f:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" Icon="Disk">
                        </f:Button>
                        <f:Window ID="Window1" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
                            WindowPosition="Center" IsModal="true" Title="角色设置" EnableMaximize="true"
                            EnableResize="true" Target="Self" EnableIFrame="true"
                            Height="500px" Width="650px">
                        </f:Window>
                        <f:ToolbarSeparator ID="ToolbarSeparator5" runat="server"></f:ToolbarSeparator>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Grid ID="Grid1" Title="用户角色" Width="100%" PageSize="5" ShowBorder="true" ShowHeader="true"
                    AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                    DataKeyNames="GroupCode,UserName" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                    AllowSorting="true" SortField="GroupCode" SortDirection="ASC"
                    OnSort="Grid1_Sort">
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField ID="UserName" DataField="UserName" HeaderText="用户名称"></f:BoundField>
                        <f:BoundField ID="GroupName" DataField="GroupName" HeaderText="角色名称"></f:BoundField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
