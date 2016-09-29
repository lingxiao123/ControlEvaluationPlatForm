<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRole_Set.aspx.cs" Inherits="PlatFormWeb.Role.UserRole_Set" %>

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
                <f:Grid ID="Grid1"  Width="100%" PageSize="20" ShowBorder="true" ShowHeader="false"
                    AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                    DataKeyNames="Id,GroupCode,GroupName" IsDatabasePaging="true"
                    AllowSorting="true" SortField="Id" SortDirection="ASC"
                    OnSort="Grid1_Sort" EnableRowDoubleClickEvent="true" OnRowDoubleClick="Grid1_RowDoubleClick">
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField ID="GroupCode" DataField="GroupCode" HeaderText="角色编码"></f:BoundField>
                        <f:BoundField ID="GroupName" DataField="GroupName" HeaderText="角色名称"></f:BoundField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
