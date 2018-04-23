Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Grid.Themes

Namespace DXGrid_ConditionalFormatting
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
			Dim st As Style= TryCast(Me.FindResource(New GridRowThemeKeyExtension With {.ResourceKey= GridRowThemeKeys.CellStyle}), Style)
			newStyle = New Style(GetType(CellContentPresenter),st)
			Dim s As New Setter()
			s.Property=CellContentPresenter.BackgroundProperty
			Dim b As New Binding("Value")
			b.Converter = New IntoToColorConverter()
			s.Value = b
			newStyle.Setters.Add(s)
			grid.ItemsSource = Products.GetData()
		End Sub

		Private newStyle As Style
		Private Sub grid_ColumnsPopulated(ByVal sender As Object, ByVal e As RoutedEventArgs)
			grid.View.CellStyle = newStyle
		End Sub
	End Class

	Public Class IntoToColorConverter
		Inherits MarkupExtension
		Implements IValueConverter

		#Region "IValueConverter Members"

		Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
				If value.GetType() Is GetType(Integer) AndAlso CInt(Fix(value))<20 Then
					Return New LinearGradientBrush(Color.FromArgb(100, 255, 0, 0), Color.FromArgb(0, 255, 0, 0), 0)
				Else
					Return Brushes.White
				End If

		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Throw New System.NotImplementedException()
		End Function

		#End Region

		Public Overrides Function ProvideValue(ByVal serviceProvider As System.IServiceProvider) As Object
			Return Me
		End Function
	End Class
	Public Class Products
		Public Shared Function GetData() As List(Of Product)
			Dim data As New List(Of Product)()
			data.Add(New Product() With {.ProductName = "Chai", .UnitPrice = 18, .UnitsOnOrder = 10})
			data.Add(New Product() With {.ProductName = "Ipoh Coffee", .UnitPrice = 36.8, .UnitsOnOrder = 12})
			data.Add(New Product() With {.ProductName = "Outback Lager", .UnitPrice = 12, .UnitsOnOrder = 25})
			data.Add(New Product() With {.ProductName = "Boston Crab Meat", .UnitPrice = 18.4, .UnitsOnOrder = 18})
			data.Add(New Product() With {.ProductName = "Konbu", .UnitPrice = 6, .UnitsOnOrder = 24})
			Return data
		End Function
	End Class
	Public Class Product
		Private privateProductName As String
		Public Property ProductName() As String
			Get
				Return privateProductName
			End Get
			Set(ByVal value As String)
				privateProductName = value
			End Set
		End Property
		Private privateUnitPrice As Double
		Public Property UnitPrice() As Double
			Get
				Return privateUnitPrice
			End Get
			Set(ByVal value As Double)
				privateUnitPrice = value
			End Set
		End Property
		Private privateUnitsOnOrder As Integer
		Public Property UnitsOnOrder() As Integer
			Get
				Return privateUnitsOnOrder
			End Get
			Set(ByVal value As Integer)
				privateUnitsOnOrder = value
			End Set
		End Property
	End Class
End Namespace
