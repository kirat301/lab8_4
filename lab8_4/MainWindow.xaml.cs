using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab8_4
{
    public partial class MainWindow : Window
    {
        private readonly List<Product> _products = new List<Product>();
        public MainWindow()
        {
            InitializeComponent();
            listProducts.ItemsSource = _products;
            UpdateCounter();
        }
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ProductWindow { Owner = this }; // объявление + привязка к глав. окну
            if (dlg.ShowDialog() == true) //A.16
            {
                _products.Add(dlg.Result);
                listProducts.Items.Refresh();
                UpdateCounter();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var select = listProducts.SelectedItem as Product;
            if (select == null)
            {
                MessageBox.Show("Выберите товар для редактирования.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var dlg = new ProductWindow(select) { Owner = this };
            if (dlg.ShowDialog() == true)
            {
                var r = dlg.Result;
                select.Name = r.Name;
                select.Price = r.Price;
                select.Quantity = r.Quantity;
                listProducts.Items.Refresh();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var select = listProducts.SelectedItem as Product;
            if (select == null)
            {
                MessageBox.Show("Выберите товар для удаления.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var answ = MessageBox.Show(
                "Удалить товар " + select.Name + "?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (answ == MessageBoxResult.Yes)
            {
                _products.Remove(select);
                listProducts.Items.Refresh();
                UpdateCounter();
            }
        }

        private void lstProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void UpdateCounter()
        {
            tbCount.Text = "Товаров: " + _products.Count;
        }

    }
}
