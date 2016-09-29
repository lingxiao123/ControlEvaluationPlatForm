<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evaluation.aspx.cs" Inherits="PlatFormWeb.Evaluation.Evaluation" %>

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
                <f:Grid ID="Grid1" Width="100%" Title="内控执行评价" PageSize="20" ShowBorder="true" ShowHeader="true"
                    AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                    DataKeyNames="Id" IsDatabasePaging="true"
                    AllowSorting="true" SortField="Id" SortDirection="ASC"
                    OnSort="Grid1_Sort">
                    <Columns>
                        <f:RowNumberField />
                        <f:GroupField HeaderText="任务" TextAlign="Center">
                            <Columns>
                                <f:BoundField ID="Years" DataField="Years" HeaderText="年度"></f:BoundField>
                                <f:BoundField ID="TaskCode" DataField="TaskCode" HeaderText="代码"></f:BoundField>
                                <f:BoundField ID="TaskName" DataField="TaskName" HeaderText="名称"></f:BoundField>
                            </Columns>
                        </f:GroupField>
                        <f:GroupField HeaderText="对象" TextAlign="Center">
                            <Columns>
                                <f:BoundField ID="Code" DataField="Code" HeaderText="代码"></f:BoundField>
                                <f:BoundField ID="AgencyName" DataField="AgencyName" HeaderText="名称"></f:BoundField>
                                <f:BoundField ID="Person" DataField="Person" HeaderText="负责人"></f:BoundField>
                            </Columns>
                        </f:GroupField>
                        <f:BoundField ID="Status" DataField="Status" HeaderText="状态"></f:BoundField>
                        <f:GroupField HeaderText="单位自评" TextAlign="Center">
                            <Columns>
                                <f:BoundField ID="SelfCode" DataField="SelfCode" HeaderText="评估人编码"></f:BoundField>
                                <f:BoundField ID="SelfName" DataField="SelfName" HeaderText="评估人名称"></f:BoundField>
                                <f:BoundField ID="SelfTime" DataField="SelfTime" HeaderText="评估时间"></f:BoundField>
                            </Columns>
                        </f:GroupField>
                        <f:GroupField HeaderText="主管复核" TextAlign="Center">
                            <Columns>
                                <f:BoundField ID="ChargeCode" DataField="ChargeCode" HeaderText="复核人编码"></f:BoundField>
                                <f:BoundField ID="ChargeName" DataField="ChargeName" HeaderText="复核人名称"></f:BoundField>
                                <f:BoundField ID="ChargeTime" DataField="ChargeTime" HeaderText="复核时间"></f:BoundField>
                            </Columns>
                        </f:GroupField>
                        <f:GroupField HeaderText="财政审核" TextAlign="Center">
                            <Columns>
                                <f:BoundField ID="FinanceCode" DataField="FinanceCode" HeaderText="审核人编码"></f:BoundField>
                                <f:BoundField ID="FinanceName" DataField="FinanceName" HeaderText="审核人名称"></f:BoundField>
                                <f:BoundField ID="FinanceTime" DataField="FinanceTime" HeaderText="审核时间"></f:BoundField>
                            </Columns>
                        </f:GroupField>
                        <f:BoundField ID="Remark" DataField="Remark" HeaderText="备注"></f:BoundField>
                        <f:WindowField TextAlign="Center" Width="80px" HeaderText="操作" WindowID="Window1"
                            ToolTip="详情" Text="详情" DataIFrameUrlFields="Id" DataIFrameUrlFormatString="~/Office/WorkNotice_Edit.aspx?Id={0}"
                            Title="详情" />

                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
            WindowPosition="Center" IsModal="true" Title="详情" EnableMaximize="true"
            EnableResize="true" Target="Self" EnableIFrame="true"
            Height="700px" Width="1200px">
        </f:Window>
    </form>
</body>
</html>
