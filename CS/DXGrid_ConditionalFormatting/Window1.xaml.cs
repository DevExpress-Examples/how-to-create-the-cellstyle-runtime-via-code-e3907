using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.Themes;

namespace DXGrid_ConditionalFormatting {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            Style st= this.FindResource(new GridRowThemeKeyExtension{ResourceKey= GridRowThemeKeys.CellStyle}) as Style;            
            newStyle = new Style(typeof(CellContentPresenter),st);
            Setter s = new Setter();
            s.Property=CellContentPresenter.BackgroundProperty;
            Binding b = new Binding("Value");
            b.Converter = new IntoToColorConverter();
            s.Value = b;
            newStyle.Setters.Add(s);            
            grid.ItemsSource = Products.GetData();
        }

        Style newStyle;
        private void grid_ColumnsPopulated(object sender, RoutedEventArgs e) {
            grid.View.CellStyle = newStyle;
        }
    }

    public class IntoToColorConverter : MarkupExtension, IValueConverter {

        #region IValueConverter Members

        public object Convert(object value, System.Type targetType,
                    object parameter, System.Globalization.CultureInfo culture) {
                if (value.GetType() == typeof(int) && (int)value<20)
                    return new LinearGradientBrush(
                            Color.FromArgb(100, 255, 0, 0),
                            Color.FromArgb(0, 255, 0, 0), 0);
                else
                    return Brushes.White;

        }

        public object ConvertBack(object value, System.Type targetType, 
                    object parameter, System.Globalization.CultureInfo culture) {
            throw new System.NotImplementedException();
        }

        #endregion

        public override object ProvideValue(System.IServiceProvider serviceProvider) {
            return this;
        }
    }
    public class Products {
        public static List<Product> GetData() {
            List<Product> data = new List<Product>();
            data.Add(new Product() { ProductName = "Chai", 
                UnitPrice = 18, UnitsOnOrder = 10 });
            data.Add(new Product() { ProductName = "Ipoh Coffee", 
                UnitPrice = 36.8, UnitsOnOrder = 12 });
            data.Add(new Product() { ProductName = "Outback Lager", 
                UnitPrice = 12, UnitsOnOrder = 25 });
            data.Add(new Product() { ProductName = "Boston Crab Meat", 
                UnitPrice = 18.4, UnitsOnOrder = 18 });
            data.Add(new Product() { ProductName = "Konbu", 
                UnitPrice = 6, UnitsOnOrder = 24 });
            return data;
        }
    }
    public class Product {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsOnOrder { get; set; }
    }
}
