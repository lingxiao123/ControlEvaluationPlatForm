<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo_AddObject.aspx.cs" Inherits="PlatFormWeb.User.UserInfo_AddObject" %>

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
                <f:Grid ID="Grid1" Width="100%" PageSize="20" ShowBorder="true" ShowHeader="false"
                    AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                    DataKeyNames="Id,Code,AgencyName" IsDatabasePaging="true"
                    AllowSorting="true" SortField="Id" SortDirection="ASC"
                    OnSort="Grid1_Sort" EnableRowDoubleClickEvent="true" OnRowDoubleClick="Grid1_RowDoubleClick">
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField ID="Code" DataField="Code" HeaderText="编码"></f:BoundField>
                        <f:BoundField ID="AgencyName" DataField="AgencyName" HeaderText="名称"></f:BoundField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
