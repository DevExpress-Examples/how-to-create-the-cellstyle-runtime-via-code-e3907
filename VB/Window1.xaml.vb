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
            Dim st As Style= TryCast(Me.FindResource(New GridRowThemeKeyExtension With {.ResourceKey= GridRowThemeKeys.LightweightCellStyle}), Style)
            newStyle = New Style(GetType(LightweightCellEditor),st)
            Dim s As New Setter()
            s.Property= LightweightCellEditor.BackgroundProperty
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
                If value.GetType() Is GetType(Integer) AndAlso DirectCast(value, Integer)<20 Then
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
            data.Add(New Product() With { _
                .ProductName = "Chai", _
                .UnitPrice = 18, _
                .UnitsOnOrder = 10 _
            })
            data.Add(New Product() With { _
                .ProductName = "Ipoh Coffee", _
                .UnitPrice = 36.8, _
                .UnitsOnOrder = 12 _
            })
            data.Add(New Product() With { _
                .ProductName = "Outback Lager", _
                .UnitPrice = 12, _
                .UnitsOnOrder = 25 _
            })
            data.Add(New Product() With { _
                .ProductName = "Boston Crab Meat", _
                .UnitPrice = 18.4, _
                .UnitsOnOrder = 18 _
            })
            data.Add(New Product() With { _
                .ProductName = "Konbu", _
                .UnitPrice = 6, _
                .UnitsOnOrder = 24 _
            })
            Return data
        End Function
    End Class
    Public Class Product
        Public Property ProductName() As String
        Public Property UnitPrice() As Double
        Public Property UnitsOnOrder() As Integer
    End Class
End Namespace
