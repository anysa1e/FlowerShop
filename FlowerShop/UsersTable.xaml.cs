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
    /// Логика взаимодействия для UsersTable.xaml
    /// </summary>
    public partial class UsersTable : Page
    {
        public UsersTable()
        {
            InitializeComponent();

            using (var context = new FlowerDeliveryEntities1())
            {
                var users = context.Users.ToList();
                UsersDataGrid.ItemsSource = users; // dataGrid - это имя вашего элемента управления DataGrid в XAML
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
