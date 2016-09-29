<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalObject.aspx.cs" Inherits="PlatFormWeb.Basis.InternalObject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region" TableConfigColumns="2" AutoScroll="true">
            <Items>
                <f:Panel ID="PanelLeft" runat="server" Title="基础资料分级" MinWidth="300px" RegionPosition="Left">
                    <Items>
                        <f:Tree ID="Tree1" Width="300px" ShowHeader="false" OnNodeCommand="Tree1_NodeCommand" EnableCollapse="true"
                            Title="" runat="server">
                        </f:Tree>
                    </Items>
                </f:Panel>
                <f:Panel ID="PanelRight" runat="server" Title="" MinHeight="300px" RegionPosition="Center">
                    <Items>
                        <f:Panel ID="PanelTop" runat="server" Title="当前基础资料信息" MinHeight="300px" RegionPosition="Top">
                            <Toolbars>
                                <f:Toolbar ID="toolbar" runat="server">
                                    <Items>
                                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server"></f:ToolbarSeparator>
                                        <f:Button ID="btnSelect" runat="server" Icon="Disk" Text="保存" OnClick="btnSelect_Click"></f:Button>
                                        <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server"></f:ToolbarSeparator>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Items>
                                <f:Form ID="formmain" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="5px" RowHeight="80px">
                                    <Rows>
                                        <f:FormRow Height="45px">
                                            <Items>
                                                <f:TextBox ID="txtCode" runat="server" Label="代码" Required="true" RequiredMessage="请输入编码" Text="" LabelAlign="Right"></f:TextBox>
                                                <f:TextBox ID="txtParentCode" runat="server" Label="上级单位" Text="" LabelAlign="Right"></f:TextBox>
                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow Height="45px">
                                            <Items>
                                                <f:TextBox ID="txtAgencyName" runat="server" Label="名称" Text="" LabelAlign="Right"></f:TextBox>
                                                <f:TextBox ID="txtType" runat="server" Label="类型" Text="" LabelAlign="Right"></f:TextBox>

                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow Height="45px">
                                            <Items>
                                                <f:TextBox ID="txtIndustry" runat="server" Label="所属行业" Text="" LabelAlign="Right"></f:TextBox>
                                                <f:TextBox ID="txtPerson" runat="server" Label="负责人" Text="" LabelAlign="Right"></f:TextBox>

                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow Height="45px">
                                            <Items>
                                                <f:TextBox ID="txtEmail" runat="server" Label="Email" Text="" LabelAlign="Right"></f:TextBox>
                                                <f:TextBox ID="txtPhone" runat="server" Label="电话" Text="" LabelAlign="Right"></f:TextBox>
                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow Height="45px">
                                            <Items>
                                                <f:TextBox ID="txtAddress" runat="server" Label="地址" Text="" LabelAlign="Right"></f:TextBox>
                                                <f:TextArea ID="txtRemark" runat="server" Label="备注" LabelAlign="Right"></f:TextArea>
                                            </Items>
                                        </f:FormRow>
                                    </Rows>
                                </f:Form>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="PanelCenter" runat="server" Title="" MinHeight="600px" RegionPosition="Center">
                            <Items>
                                <f:Grid ID="Grid1" runat="server" Title="" ShowHeader="true" ShowBorder="true" ShowGridHeader="true" DataKeyNames="Id,Number,Type"
                                    KeepCurrentSelection="true" SortField="Id" AllowSorting="false">
                                    <Columns>
                                        <f:BoundField ID="Code" DataField="Code" HeaderText="代码"></f:BoundField>
                                        <f:BoundField ID="AgencyName" DataField="AgencyName" HeaderText="名称"></f:BoundField>
                                        <f:BoundField ID="Type" DataField="Type" HeaderText="单位类型"></f:BoundField>
                                        <f:BoundField ID="Industry" DataField="Industry" HeaderText="所属行业"></f:BoundField>
                                        <f:BoundField ID="Person" DataField="Person" HeaderText="负责人"></f:BoundField>
                                        <f:BoundField ID="Phone" DataField="Phone" HeaderText="电话"></f:BoundField>
                                        <f:BoundField ID="Email" DataField="Email" HeaderText="Email"></f:BoundField>
                                        <f:BoundField ID="Address" DataField="Address" HeaderText="地址"></f:BoundField>
                                        <f:BoundField ID="Remark" DataField="Remark" HeaderText="备注"></f:BoundField>
                                    </Columns>
                                </f:Grid>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>

    </form>
</body>
</html>
