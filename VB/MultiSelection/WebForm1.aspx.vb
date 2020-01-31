Imports DevExpress.Data.Filtering
Imports DevExpress.XtraCharts
Imports MultiSelection.Models
Imports System
Imports System.Collections
Imports System.Collections.Generic

Namespace MultiSelection
	Partial Public Class WebForm1
		Inherits System.Web.UI.Page

		Private Const RegionDataMember As String = "Region"

		Private colorIndices As Dictionary(Of String, Integer)
		Private paletteIndices As New List(Of Integer)()
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			WebChartControlBars.DataBind()
		End Sub

		Protected Sub WebChartControlPie_ObjectSelected(ByVal sender As Object, ByVal e As HotTrackEventArgs)
			If Not (TypeOf e.Object Is Series) Then
				e.Cancel = True
				WebChartControlPie.SelectedItems.Clear()
			End If
		End Sub
		Private Sub InitColorIndices()
			colorIndices = New Dictionary(Of String, Integer)()
			Dim i As Integer = 0
			Do While i < WebChartControlPie.Series(0).Points.Count
				colorIndices.Add(WebChartControlPie.Series(0).Points(i).Argument, i)
				i += 1
			Loop
		End Sub
		Protected Sub WebChartControlPie_SelectedItemsChanged(ByVal sender As Object, ByVal e As SelectedItemsChangedEventArgs)
			InitColorIndices()
			paletteIndices = New List(Of Integer)()
			Dim selectedItems As IList = WebChartControlPie.SelectedItems
			If selectedItems Is Nothing OrElse selectedItems.Count = 0 Then
				WebChartControlBars.SeriesTemplate.FilterCriteria = Nothing
			Else
				Dim filters As New List(Of CriteriaOperator)()
				Dim regions As New HashSet(Of String)()
				For Each dataItem As DevAVDataItem In WebChartControlPie.SelectedItems
					Dim region As String = dataItem.Region
					If Not regions.Contains(region) Then
						filters.Add(New BinaryOperator(RegionDataMember, region, BinaryOperatorType.Equal))
						paletteIndices.Add(colorIndices(region))
						regions.Add(region)
					End If
				Next dataItem
				WebChartControlBars.SeriesTemplate.FilterCriteria = New GroupOperator(filters.ToArray()) With {.OperatorType = GroupOperatorType.Or}
			End If
		End Sub
		Protected Sub WebChartControlBars_BoundDataChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateSeriesColors(paletteIndices)
		End Sub
		Private Sub UpdateSeriesColors(ByVal paletteIndices As List(Of Integer))
			Dim paletteEntries() As PaletteEntry = WebChartControlPie.GetPaletteEntries(WebChartControlPie.Series(0).Points.Count)
			For i As Integer = 0 To paletteIndices.Count - 1
				WebChartControlBars.Series(i).View.Color = paletteEntries(paletteIndices(i)).Color
				CType(WebChartControlBars.Series(i).View, BarSeriesView).FillStyle.FillMode = FillMode.Solid
			Next i
		End Sub
	End Class
End Namespace