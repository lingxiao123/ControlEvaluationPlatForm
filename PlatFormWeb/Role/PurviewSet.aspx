<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurviewSet.aspx.cs" Inherits="PlatFormWeb.Role.PurviewSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Form Width="638px" BodyPadding="5px" ID="Form2"
            Title="角色授权" Height="455px" LabelWidth="120px" LabelAlign="Top" runat="server">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSaveRefresh" Text="保存" runat="server" Icon="SystemSave" ValidateForms="Form2"
                            OnClick="btnSaveRefresh_Click">
                        </f:Button>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Panel ID="PanelMenu" runat="server" Title="菜单" EnableCollapse="True" Expanded="true">
                    <Items>
                        <f:Grid ID="gdMenu" runat="server" Title="菜单权限" ShowBorder="true" EnableRowLines="false"
                            ShowHeader="false" DataKeyNames="AcCode,Id" OnRowDataBound="gdMenu_RowDataBound">
                            <Columns>
                                <f:CheckBoxField ID="m_IsAllow" ColumnID="c_m_IsAllow" HeaderText="授权" DataField="AcValue" RenderAsStaticField="false"></f:CheckBoxField>
                                <f:BoundField ID="m_Id" DataField="Id" HeaderText="数据库序号"></f:BoundField>
                                <f:BoundField ID="m_AcModuleTitleCode" DataField="AcModuleTitleCode" HeaderText="模块编码" Hidden="true"></f:BoundField>
                                <f:BoundField ID="m_AcModuleTitle" DataField="AcModuleTitle" HeaderText="模块名称"></f:BoundField>
                                <f:BoundField ID="m_AcTypeCode" DataField="AcTypeCode" HeaderText="分类编码" Hidden="true"></f:BoundField>
                                <f:BoundField ID="m_AcType" DataField="AcType" HeaderText="分类名称"></f:BoundField>
                                <f:BoundField ID="m_AcCode" DataField="AcCode" HeaderText="权限编码"></f:BoundField>
                                <f:BoundField ID="m_AcName" DataField="AcName" HeaderText="权限名称"></f:BoundField>
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
            <Items>
                <f:Panel ID="PanelService" runat="server" Title="功能" EnableCollapse="True" Expanded="true">
                    <Items>
                        <f:Grid ID="gdService" runat="server" Title="功能权限" ShowBorder="true" EnableRowLines="false"
                            ShowHeader="false" DataKeyNames="AcCode,Id" OnRowDataBound="gdService_RowDataBound">
                            <Columns>
                                <f:CheckBoxField ID="s_IsAllow" ColumnID="c_s_IsAllow" HeaderText="授权" DataField="AcValue" RenderAsStaticField="false"></f:CheckBoxField>
                                <f:BoundField ID="s_Id" DataField="Id" HeaderText="数据库序号"></f:BoundField>
                                <f:BoundField ID="s_AcModuleTitleCode" DataField="AcModuleTitleCode" HeaderText="模块编码" Hidden="true"></f:BoundField>
                                <f:BoundField ID="s_AcModuleTitle" DataField="AcModuleTitle" HeaderText="模块名称"></f:BoundField>
                                <f:BoundField ID="s_AcTypeCode" DataField="AcTypeCode" HeaderText="分类编码" Hidden="true"></f:BoundField>
                                <f:BoundField ID="s_AcType" DataField="AcType" HeaderText="分类名称"></f:BoundField>
                                <f:BoundField ID="s_AcCode" DataField="AcCode" HeaderText="权限编码"></f:BoundField>
                                <f:BoundField ID="s_AcName" DataField="AcName" HeaderText="权限名称"></f:BoundField>
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Form>
    </form>
</body>
</html>
