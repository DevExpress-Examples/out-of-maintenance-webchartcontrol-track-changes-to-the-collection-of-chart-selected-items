Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace MultiSelection.Models
	Public Class DevAV
		Private ReadOnly Shared regions() As String = { "DevAV North", "DevAV South", "DevAV West", "DevAV East", "DevAV Central" }
'INSTANT VB NOTE: The field categorizedProducts was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private Shared categorizedProducts_Renamed As Dictionary(Of String, List(Of String))

		Public Shared ReadOnly Property CategorizedProducts() As Dictionary(Of String, List(Of String))
			Get
				If categorizedProducts_Renamed Is Nothing Then
					categorizedProducts_Renamed = New Dictionary(Of String, List(Of String))()
					categorizedProducts_Renamed("Cameras") = New List(Of String)() From {"Camera", "Camcorder", "Binoculars", "Flash", "Tripod"}
					categorizedProducts_Renamed("Cell Phones") = New List(Of String)() From {"Smartphone", "Mobile Phone", "Smart Watch", "Sim Card"}
					categorizedProducts_Renamed("Computers") = New List(Of String)() From {"Desktop", "Laptop", "Tablet", "Printer"}
					categorizedProducts_Renamed("TV, Audio") = New List(Of String)() From {"Television", "Home Audio", "Headphone", "DVD Player"}
					categorizedProducts_Renamed("Vehicle Electronics") = New List(Of String)() From {"GPS Unit", "Radar", "Car Alarm", "Car Accessories"}
					categorizedProducts_Renamed("Multipurpose Batteries") = New List(Of String)() From {"Battery", "Charger", "Converter", "Tester", "AC/DC Adapter"}
				End If
				Return categorizedProducts_Renamed
			End Get
		End Property
		Public Shared Function GetSales() As List(Of DevAVDataItem)
			Dim list As New List(Of DevAVDataItem)(15)
			Dim prevYear As Integer = Date.Now.Year - 1

			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 2, "Asia", 4.2372D))
			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 2, "Australia", 1.7871D))
			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 2, "Europe", 3.0884D))
			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 2, "North America", 3.4855D))
			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 2, "South America", 1.6027D))

			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 1, "Asia", 4.7685D))
			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 1, "Australia", 1.9576D))
			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 1, "Europe", 3.3579D))
			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 1, "North America", 3.7477D))
			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear - 1, "South America", 1.8237D))

			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear, "Asia", 5.2890D))
			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear, "Australia", 2.2727D))
			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear, "Europe", 3.7257D))
			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear, "North America", 4.1825D))
			list.Add(DevAVDataItem.CreateByYearRegionSales(prevYear, "South America", 2.1172D))

			Return list
		End Function
	End Class
	Public Class DevAVDataItem
		Public Shared Function CreateByYearRegionSales(ByVal year As Integer, ByVal region As String, ByVal sales As Decimal) As DevAVDataItem
			Dim item As New DevAVDataItem()
			item.Year = year
			item.Region = region
			item.Sales = sales
			Return item
		End Function
		Private privateYear As Integer
		Public Property Year() As Integer
			Get
				Return privateYear
			End Get
			Private Set(ByVal value As Integer)
				privateYear = value
			End Set
		End Property
		Private privateRegion As String
		Public Property Region() As String
			Get
				Return privateRegion
			End Get
			Private Set(ByVal value As String)
				privateRegion = value
			End Set
		End Property
		Private privateSales As Decimal
		Public Property Sales() As Decimal
			Get
				Return privateSales
			End Get
			Private Set(ByVal value As Decimal)
				privateSales = value
			End Set
		End Property
		Private privateCost As Decimal
		Public Property Cost() As Decimal
			Get
				Return privateCost
			End Get
			Private Set(ByVal value As Decimal)
				privateCost = value
			End Set
		End Property
		Private privateProductCategory As String
		Public Property ProductCategory() As String
			Get
				Return privateProductCategory
			End Get
			Private Set(ByVal value As String)
				privateProductCategory = value
			End Set
		End Property
		Private privateProductName As String
		Public Property ProductName() As String
			Get
				Return privateProductName
			End Get
			Private Set(ByVal value As String)
				privateProductName = value
			End Set
		End Property
		Private privateCompany As String
		Public Property Company() As String
			Get
				Return privateCompany
			End Get
			Private Set(ByVal value As String)
				privateCompany = value
			End Set
		End Property
		Private privateSaleDate As Date
		Public Property SaleDate() As Date
			Get
				Return privateSaleDate
			End Get
			Private Set(ByVal value As Date)
				privateSaleDate = value
			End Set
		End Property
		Private privateCharges As Decimal
		Public Property Charges() As Decimal
			Get
				Return privateCharges
			End Get
			Private Set(ByVal value As Decimal)
				privateCharges = value
			End Set
		End Property
		Private privatePenalties As Decimal
		Public Property Penalties() As Decimal
			Get
				Return privatePenalties
			End Get
			Private Set(ByVal value As Decimal)
				privatePenalties = value
			End Set
		End Property

		Private Sub New()
		End Sub
	End Class
End Namespace