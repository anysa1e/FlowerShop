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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowerShop
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void ViewOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра новой страницы
            OrdersTable newPage = new OrdersTable();

            // Получение родительского окна текущей страницы
            Window parentWindow = Window.GetWindow(this);

            //сохранение предыдущей страницы
            MainWindow.lastPage = this;
            

            // Закрытие текущей страницы
            parentWindow.Content = null;

            // Открытие новой страницы
            parentWindow.Content = newPage;
        }

        private void ViewUsersButton_Click(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра новой страницы
            UsersTable newPage = new UsersTable();

            // Получение родительского окна текущей страницы
            Window parentWindow = Window.GetWindow(this);

            //сохранение предыдущей страницы
            MainWindow.lastPage = this;

            // Закрытие текущей страницы
            parentWindow.Content = null;

            // Открытие новой страницы
            parentWindow.Content = newPage;
        }
    }
}
