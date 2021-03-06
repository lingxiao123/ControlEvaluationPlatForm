﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkNotice_List.aspx.cs" Inherits="PlatFormWeb.Office.WorkNotice_List" %>

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
                <f:Grid ID="Grid1" Width="100%" Title="工作通知" PageSize="20" ShowBorder="true" ShowHeader="true"
                    AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                    DataKeyNames="Id" IsDatabasePaging="true"
                    AllowSorting="true" SortField="Id" SortDirection="ASC"
                    OnSort="Grid1_Sort" >
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <f:ToolbarSeparator ID="ToolbarSeparator6" runat="server"></f:ToolbarSeparator>
                                <f:Button ID="btnAdd" runat="server" Text="新增"
                                    Icon="Add" EnablePostBack="false">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator7" runat="server"></f:ToolbarSeparator>
                                <f:Button ID="btnDelete" runat="server" Text="删除"
                                    Icon="Delete" OnClick="btnDelete_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator8" runat="server"></f:ToolbarSeparator>
                                <f:Window ID="Window1" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
                                    WindowPosition="Center" IsModal="true" Title="新增通知" EnableMaximize="true"
                                    EnableResize="true" Target="Self" EnableIFrame="true"
                                    Height="500px" Width="650px">
                                </f:Window>
                                <f:Window ID="Window2" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
                                    WindowPosition="Center" IsModal="true" Title="通知" EnableMaximize="true"
                                    EnableResize="true" Target="Self" EnableIFrame="true"
                                    Height="500px" Width="650px">
                                </f:Window>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField ID="NoticeName" DataField="NoticeName" HeaderText="通知名称"></f:BoundField>
                        <f:BoundField ID="NoticeTheme" DataField="NoticeTheme" HeaderText="通知主题"></f:BoundField>
                        <f:BoundField ID="Status" DataField="Status" HeaderText="状态"></f:BoundField>
                        <f:BoundField ID="AuthorCode" DataField="AuthorCode" HeaderText="编制编码"></f:BoundField>
                        <f:BoundField ID="AuthorName" DataField="AuthorName" HeaderText="编制名称"></f:BoundField>
                        <f:BoundField ID="AddTime" DataField="AddTime" HeaderText="编制时间"></f:BoundField>
                        <f:BoundField ID="Remark" DataField="Remark" HeaderText="备注"></f:BoundField>
                        <f:WindowField TextAlign="Center" Width="80px" HeaderText="操作" WindowID="Window4"
                            ToolTip="详情" Text="详情" DataIFrameUrlFields="Id" DataIFrameUrlFormatString="~/Office/WorkNotice_Edit.aspx?Id={0}"
                            Title="详情" />

                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="Window4" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
            WindowPosition="Center" IsModal="true" Title="详情" EnableMaximize="true"
            EnableResize="true" Target="Self" EnableIFrame="true"
            Height="700px" Width="1200px">
        </f:Window>
    </form>
</body>
</html>
