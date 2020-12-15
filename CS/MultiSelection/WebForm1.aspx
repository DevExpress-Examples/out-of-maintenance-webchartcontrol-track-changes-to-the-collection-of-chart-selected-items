<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MultiSelection.WebForm1" %>

<%@ Register Assembly="DevExpress.XtraCharts.v19.2.Web, Version=19.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v19.2, Version=19.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:WebChartControl ID="WebChartControlPie" EnableCallBacks="False" runat="server" Height="250px" Width="700px" CrosshairEnabled="False" RenderFormat="Svg"
                ClientInstanceName="chartTotal" OnObjectSelected="WebChartControlPie_ObjectSelected" DataSourceID="chartDataSource1"
                SelectionMode="Multiple" SeriesSelectionMode="Point" OnSelectedItemsChanged="WebChartControlPie_SelectedItemsChanged">
                <Titles>
                    <dx:ChartTitle Text="The DevAV Company Sales Comparison"></dx:ChartTitle>
                </Titles>
                <SeriesSerializable>
                    <dx:Series
                        LabelsVisibility="False"
                        ArgumentDataMember="Region"
                        ValueDataMembersSerializable="Sales"
                        ToolTipPointPattern="{A} : {V:c2}M ({VP:P2})"
                        LegendTextPattern="{A} {VP:P}">
                        <QualitativeSummaryOptions SummaryFunction="SUM([Sales])" />
                        <ViewSerializable>
                            <dx:PieSeriesView></dx:PieSeriesView>
                        </ViewSerializable>
                    </dx:Series>
                </SeriesSerializable>
                <Legend Visibility="True"></Legend>
                <DiagramSerializable>
                    <dx:SimpleDiagram></dx:SimpleDiagram>
                </DiagramSerializable>
                <BorderOptions Visibility="False"/>
            </dx:WebChartControl>
            <dx:WebChartControl ID="WebChartControlBars" runat="server" Height="400px" Width="700px" CssClass="TopLargeMargin" CrosshairEnabled="False"
                DataSourceID="chartDataSource2" SeriesDataMember="Region" OnBoundDataChanged="WebChartControlBars_BoundDataChanged"
                ClientInstanceName="chart" SettingsLoadingPanel-Enabled="false" RenderFormat="Svg">
                <SeriesTemplate LabelsVisibility="False" ArgumentScaleType="Qualitative" CrosshairLabelPattern="{S} : {V:c2}M"
                    ArgumentDataMember="Year" ValueDataMembersSerializable="Sales">
                    <ViewSerializable>
                        <dx:SideBySideBarSeriesView></dx:SideBySideBarSeriesView>
                    </ViewSerializable>
                    <LabelSerializable>
                        <dx:SideBySideBarSeriesLabel TextPattern="{V:N2}">
                        </dx:SideBySideBarSeriesLabel>
                    </LabelSerializable>
                </SeriesTemplate>
                <Legend Visibility="False"></Legend>
                <DiagramSerializable>
                    <dx:XYDiagram>
                        <AxisX VisibleInPanesSerializable="-1">
                        </AxisX>
                        <AxisY Title-Text="Millions of Dollars" Title-Visibility="True" VisibleInPanesSerializable="-1">
                            <GridLines MinorVisible="True"></GridLines>
                        </AxisY>
                    </dx:XYDiagram>
                </DiagramSerializable>
                <EmptyChartText Text="" />
                <BorderOptions Visibility="False" />
                <SettingsLoadingPanel Enabled="False" />
            </dx:WebChartControl>
            <asp:ObjectDataSource ID="chartDataSource1" runat="server" TypeName="MultiSelection.Models.DevAV" DataObjectTypeName="DevAVDataItem" SelectMethod="GetSales"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="chartDataSource2" runat="server" TypeName="MultiSelection.Models.DevAV" DataObjectTypeName="DevAVDataItem" SelectMethod="GetSales"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
