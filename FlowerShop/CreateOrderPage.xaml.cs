using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowerShop
{
    /// <summary>
    /// Логика взаимодействия для CreateOrderPage.xaml
    /// </summary>
    public partial class CreateOrderPage : Page
    {
        public CreateOrderPage()
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
                    var products = context.Products.ToList();

                    // Заполнение ComboBox названиями товаров, но сохранение идентификаторов в Tag
                    foreach (var product in products)
                    {
                        ComboBoxItem item = new ComboBoxItem
                        {
                            Content = product.Name,
                            Tag = product.ProductID // Сохраняем идентификатор товара в Tag элемента ComboBoxItem
                        };
                        ProductComboBox.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке товаров: " + ex.Message);
                }
            }           
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FlowerDeliveryEntities1())
            {

                try
                {
                    ComboBoxItem selectedItem = (ComboBoxItem)ProductComboBox.SelectedItem;
                    int productId = (int)selectedItem.Tag; // Получение идентификатора товара из Tag

                    int quantity = Convert.ToInt32(QuantityTextBox.Text);
                    string address = AddressTextBox.Text;

                    // Создание нового объекта заказа
                    Orders newOrder = new Orders
                    {
                        UserID = MainWindow.userId,
                        OrderDate = DateTime.Now,
                        Status = "Новый", // Установите статус заказа
                        DeliveryAddress = address
                    };

                    // Добавление заказа в контекст базы данных
                    context.Orders.Add(newOrder);

                    // Создание объекта деталей заказа
                    OrderDetails orderDetail = new OrderDetails
                    {
                        OrderID = newOrder.OrderID,
                        ProductID = productId,
                        Quantity = quantity
                    };


                    // Добавление деталей заказа в контекст базы данных
                    context.OrderDetails.Add(orderDetail);

                    // Сохранение изменений в базе данных
                    context.SaveChanges();

                    MessageBox.Show("Заказ успешно сохранен!");

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

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var context = new FlowerDeliveryEntities1())
            {
                try
                {
                    // Получение количества товара
                    int quantity = Convert.ToInt32(QuantityTextBox.Text);

                    // Получение цены товара из базы данных
                    ComboBoxItem selectedItem = (ComboBoxItem)ProductComboBox.SelectedItem;
                    int productId = (int)selectedItem.Tag; // Получение идентификатора товара из Tag
                    var product = context.Products.FirstOrDefault(p => p.ProductID == productId);
                    decimal price = product?.Price ?? 0; // Получение цены товара, если такой товар найден, иначе устанавливаем цену равной 0

                    // Вычисление суммы и обновление текстового поля
                    decimal totalPrice = price * quantity;
                    TotalPriceTextBlock.Text = "Сумма: " + totalPrice.ToString("C"); // Форматирование суммы в виде валюты
                }
                catch (Exception ex)
                {
                    // В случае ошибки выводим сообщение об ошибке
                    MessageBox.Show("Ошибка при вычислении суммы: " + ex.Message);
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
