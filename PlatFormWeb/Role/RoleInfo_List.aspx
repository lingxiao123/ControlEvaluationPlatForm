<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleInfo_List.aspx.cs" Inherits="PlatFormWeb.Role.RoleInfo_List" %>

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
            <Items>
                <f:Grid ID="Grid1" Title="角色信息" Width="100%" PageSize="5" ShowBorder="true" ShowHeader="true"
                    AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                    DataKeyNames="Id,GroupCode" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                    AllowSorting="true" SortField="id" SortDirection="ASC" ClicksToEdit="1" AllowCellEditing="true"
                    OnSort="Grid1_Sort">
                    <Toolbars>
                        <f:Toolbar ID="toolb1" runat="server">
                            <Items>
                                <f:ToolbarSeparator ID="ToolbarSeparator4" runat="server"></f:ToolbarSeparator>
                                <f:Button ID="btnImport" runat="server" Text="新增角色"
                                    Icon="Add" EnablePostBack="false">
                                </f:Button>
                                <f:Button ID="btnSave" runat="server" Text="保存修改" Icon="Disk">
                                </f:Button>
                                <f:Window ID="Window1" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
                                    WindowPosition="Center" IsModal="true" Title="新增角色" EnableMaximize="true"
                                    EnableResize="true" Target="Self" EnableIFrame="true"
                                    Height="500px" Width="650px">
                                </f:Window>
                                <f:Window ID="Window2" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
                                    WindowPosition="Center" IsModal="true" Title="角色授权" EnableMaximize="true"
                                    EnableResize="true" Target="Self" EnableIFrame="true"
                                    Height="500px" Width="650px">
                                </f:Window>
                                <f:ToolbarSeparator ID="ToolbarSeparator5" runat="server"></f:ToolbarSeparator>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:BoundField ID="GroupCode" DataField="GroupCode" HeaderText="角色编号"></f:BoundField>
                        <f:BoundField ID="GroupName" DataField="GroupName" HeaderText="角色名称"></f:BoundField>
                        <f:WindowField TextAlign="Center" HeaderText="操作" Text="角色授权" Width="150px" WindowID="Window2"
                            ToolTip="" DataIFrameUrlFields="GroupCode" DataIFrameUrlFormatString="PurviewSet.aspx?GroupCode={0}"
                            Title="" IFrameUrl="~/alert.aspx" />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
