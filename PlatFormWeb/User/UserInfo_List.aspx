<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo_List.aspx.cs" Inherits="PlatFormWeb.User.UserInfo_List" %>

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
                        <f:Button ID="btnImport" runat="server" Text="新增用户"
                            Icon="Add" EnablePostBack="false">
                        </f:Button>
                        <f:Button ID="btnSave" runat="server" Text="保存修改" OnClick="btnSave_Click" Icon="Disk">
                        </f:Button>
                        <f:Window ID="Window1" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
                            WindowPosition="Center" IsModal="true" Title="新增用户" EnableMaximize="true"
                            EnableResize="true" Target="Self" EnableIFrame="true"
                            Height="500px" Width="650px">
                        </f:Window>
                        <f:ToolbarSeparator ID="ToolbarSeparator5" runat="server"></f:ToolbarSeparator>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Panel runat="server" ID="panelTopRegion" RegionPosition="Top" RegionSplit="true" EnableCollapse="true" MinHeight="300px"
                    Title="用户信息" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Items>
                        <f:Grid ID="Grid1" Title="" PageSize="10" ShowBorder="true" ShowHeader="true"
                            AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                            DataKeyNames="Id,UserName" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                            AllowSorting="true" SortField="id" SortDirection="ASC" ClicksToEdit="1" AllowCellEditing="true"
                            OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" EnableMultiSelect="false" EnableRowClickEvent="true" OnRowClick="Grid1_RowClick1">
                            <Columns>
                                <f:BoundField ID="Id" DataField="Id" HeaderText="序号"></f:BoundField>
                                <f:BoundField ID="UserName" DataField="UserName" HeaderText="用户名"></f:BoundField>
                                <%--<f:CheckBoxField DataField="Status" HeaderText="是否启用" />--%>
                                <f:RenderField Width="100px" ColumnID="Status" DataField="Status" FieldType="Int"
                                    RendererFunction="renderGender" HeaderText="状态">
                                    <Editor>
                                        <f:DropDownList ID="DropDownList1" Required="true" runat="server">
                                            <f:ListItem Text="启用" Value="1" />
                                            <f:ListItem Text="禁用" Value="0" />
                                        </f:DropDownList>
                                    </Editor>
                                </f:RenderField>
                                <f:BoundField ID="AddTime" DataField="AddTime" HeaderText="注册时间"></f:BoundField>
                                <f:BoundField ID="UpdateTime" DataField="UpdateTime" HeaderText="修改时间"></f:BoundField>
                                <f:LinkButtonField HeaderText="操作" Width="80px" CommandName="Action1" Text="重置密码" />
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelLeftRegion" RegionPosition="Left" RegionSplit="true" EnableCollapse="true"
                    Width="200px" Title="" ShowBorder="false" ShowHeader="false" MinWidth="700px" BodyPadding="0px">
                    <Items>
                        <f:Grid ID="Grid5" Title="用户角色" PageSize="5" ShowBorder="true" ShowHeader="true"
                            AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                            DataKeyNames="GroupCode,GroupName" IsDatabasePaging="true"
                            AllowSorting="true" SortField="GroupCode" SortDirection="ASC">
                            <Toolbars>
                                <f:Toolbar ID="tool" runat="server">
                                    <Items>
                                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server"></f:ToolbarSeparator>
                                        <f:Button ID="btnAddRole" runat="server" Text="追加角色"
                                            Icon="Add" EnablePostBack="false">
                                        </f:Button>
                                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server"></f:ToolbarSeparator>
                                        <f:Button ID="btnDeleteRole" runat="server" Text="删除角色"
                                            Icon="Delete"  OnClick="btnDeleteRole_Click">
                                        </f:Button>
                                        <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server"></f:ToolbarSeparator>
                                        <f:Window ID="Window2" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
                                            WindowPosition="Center" IsModal="true" Title="追加角色" EnableMaximize="true"
                                            EnableResize="true" Target="Self" EnableIFrame="true"
                                            Height="500px" Width="650px">
                                        </f:Window>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:RowNumberField />
                                <f:BoundField ID="GroupCode" DataField="GroupCode" HeaderText="角色编码"></f:BoundField>
                                <f:BoundField ID="GroupName" DataField="GroupName" HeaderText="角色名称"></f:BoundField>
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="Center"
                    Title="内控对象" ShowBorder="true" ShowHeader="true" BodyPadding="0px">
                    <Items>
                        <f:Grid ID="Grid3" Title="" PageSize="5" ShowBorder="true" ShowHeader="true"
                            AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                            DataKeyNames="Code,AgencyName" IsDatabasePaging="true"
                            AllowSorting="true" SortField="Code" SortDirection="ASC">
                            <Toolbars>
                                <f:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <f:ToolbarSeparator ID="ToolbarSeparator6" runat="server"></f:ToolbarSeparator>
                                        <f:Button ID="btnAdd" runat="server" Text="增加"
                                            Icon="Add" EnablePostBack="false">
                                        </f:Button>
                                        <f:ToolbarSeparator ID="ToolbarSeparator7" runat="server"></f:ToolbarSeparator>
                                        <f:Button ID="btnDelete" runat="server" Text="删除"
                                            Icon="Delete" OnClick="btnDelete_Click1">
                                        </f:Button>
                                        <f:ToolbarSeparator ID="ToolbarSeparator8" runat="server"></f:ToolbarSeparator>
                                        <f:Window ID="Window3" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
                                            WindowPosition="Center" IsModal="true" Title="增加内控对象" EnableMaximize="true"
                                            EnableResize="true" Target="Self" EnableIFrame="true"
                                            Height="500px" Width="650px">
                                        </f:Window>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:RowNumberField />
                                <f:BoundField ID="Code" DataField="Code" HeaderText="编码"></f:BoundField>
                                <f:BoundField ID="AgencyName" DataField="AgencyName" HeaderText="名称"></f:BoundField>
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:HiddenField ID="hfUserId" runat="server"></f:HiddenField>
        <script>
            function renderGender(value) {
                return value == 1 ? '启用' : '禁用';
            }
        </script>
    </form>
</body>
</html>
