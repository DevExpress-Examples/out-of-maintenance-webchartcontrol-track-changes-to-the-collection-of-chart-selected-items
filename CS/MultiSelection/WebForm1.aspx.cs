using DevExpress.Data.Filtering;
using DevExpress.XtraCharts;
using MultiSelection.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MultiSelection {
    public partial class WebForm1 : System.Web.UI.Page {

        const string RegionDataMember = "Region";

        Dictionary<string, int> colorIndices;
        List<int> paletteIndices = new List<int>();
        protected void Page_Load(object sender, EventArgs e) {
            WebChartControlBars.DataBind();
        }

        protected void WebChartControlPie_ObjectSelected(object sender, HotTrackEventArgs e) {
            if (!(e.Object is Series)) {
                e.Cancel = true;
                WebChartControlPie.SelectedItems.Clear();
            }
        }
        void InitColorIndices() {
            colorIndices = new Dictionary<string, int>();
            for (int i = 0; i < WebChartControlPie.Series[0].Points.Count; i++)
                colorIndices.Add(WebChartControlPie.Series[0].Points[i].Argument, i);
        }
        protected void WebChartControlPie_SelectedItemsChanged(object sender, SelectedItemsChangedEventArgs e) {
            InitColorIndices();
            paletteIndices = new List<int>();
            IList selectedItems = WebChartControlPie.SelectedItems;
            if (selectedItems == null || selectedItems.Count == 0)
                WebChartControlBars.SeriesTemplate.FilterCriteria = null;
            else {
                List<CriteriaOperator> filters = new List<CriteriaOperator>();
                HashSet<string> regions = new HashSet<string>();
                foreach (DevAVDataItem dataItem in WebChartControlPie.SelectedItems) {
                    string region = dataItem.Region;
                    if (!regions.Contains(region)) {
                        filters.Add(new BinaryOperator(RegionDataMember, region, BinaryOperatorType.Equal));
                        paletteIndices.Add(colorIndices[region]);
                        regions.Add(region);
                    }
                }
                WebChartControlBars.SeriesTemplate.FilterCriteria = new GroupOperator(filters.ToArray()) { OperatorType = GroupOperatorType.Or };
            }
        }
        protected void WebChartControlBars_BoundDataChanged(object sender, EventArgs e) {
            UpdateSeriesColors(paletteIndices);
        }
        void UpdateSeriesColors(List<int> paletteIndices) {
            PaletteEntry[] paletteEntries = WebChartControlPie.GetPaletteEntries(WebChartControlPie.Series[0].Points.Count);
            for (int i = 0; i < paletteIndices.Count; i++) {
                WebChartControlBars.Series[i].View.Color = paletteEntries[paletteIndices[i]].Color;
                ((BarSeriesView)WebChartControlBars.Series[i].View).FillStyle.FillMode = FillMode.Solid;
            }
        }
    }
}