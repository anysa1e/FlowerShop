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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowerShop
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();

            FillComboBox();
        }

        private void FillComboBox()
        {
            using (var context = new FlowerDeliveryEntities1())
            {
                try
                {
                    // Получение списка товаров из базы данных
                    var products = context.ProductCategories.ToList();

                    // Заполнение ComboBox названиями товаров, но сохранение идентификаторов в Tag
                    foreach (var product in products)
                    {
                        ComboBoxItem item = new ComboBoxItem
                        {
                            Content = product.Name,
                            Tag = product.CategoryID // Сохраняем идентификатор товара в Tag элемента ComboBoxItem
                        };
                        CategoryComboBox.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке товаров: " + ex.Message);
                }
            }

        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FlowerDeliveryEntities1())
            {

                try
                {
                    ComboBoxItem selectedItem = (ComboBoxItem)CategoryComboBox.SelectedItem;
                    int categoryProductId = (int)selectedItem.Tag; // Получение идентификатора товара из Tag

                    string name = ProductNameTextBox.Text;
                    string description = DescriptionTextBox.Text;
                    decimal price = Convert.ToDecimal(PriceTextBox.Text);

                    // Создание нового объекта заказа
                    Products newProducts = new Products
                    {
                        Name = name,
                        Description = description,
                        Price = price, // Установите статус заказа
                        CategoryID = categoryProductId
                    };

                    // Добавление заказа в контекст базы данных
                    context.Products.Add(newProducts);

                    // Сохранение изменений в базе данных
                    context.SaveChanges();

                    MessageBox.Show("Товар успешно сохранен!");

                    // Получение родительского окна текущей страницы
                    Window parentWindow = Window.GetWindow(this);

                    // Закрытие текущей страницы
                    parentWindow.Content = null;

                    // Открытие новой страницы
                    parentWindow.Content = MainWindow.lastPage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении заказа: " + ex.Message);
                }
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение родительского окна текущей страницы
            Window parentWindow = Window.GetWindow(this);

            // Закрытие текущей страницы
            parentWindow.Content = null;

            // Открытие новой страницы
            parentWindow.Content = MainWindow.lastPage;
        }
    }
}

