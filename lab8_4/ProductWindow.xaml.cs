using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab8_4
{
    public partial class ProductWindow : Window
    {
        public Product Result { get; private set; }
        public ProductWindow()
        {
            InitializeComponent();
            Title = "Добавить товар";
        }

        public ProductWindow(Product product)
        {
            InitializeComponent();
            Title = "Редактировать товар";
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString("F2");
            txtQuantity.Text = product.Quantity.ToString();
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Введите название товара.");

                decimal price;
                if (!decimal.TryParse(txtPrice.Text, out price))
                    throw new FormatException("Цена должна быть числом.");
                if (price <= 0)
                    throw new ArgumentException("Цена должна быть больше нуля.");

                int qty;
                if (!int.TryParse(txtQuantity.Text, out qty))
                    throw new FormatException("Количество должно быть целым числом.");
                if (qty < 0)
                    throw new ArgumentException("Количество не может быть отрицательным.");

                Result = new Product { Name = name, Price = price, Quantity = qty };
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
