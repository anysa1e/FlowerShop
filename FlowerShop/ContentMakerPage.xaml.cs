using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
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
    /// Логика взаимодействия для ContentMakerPage.xaml
    /// </summary>
    public partial class ContentMakerPage : Page
    {
        public ContentMakerPage()
        {
            InitializeComponent();
        }

        private void ViewProductsButton_Click(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра новой страницы
            ProductTablePage newPage = new ProductTablePage();

            // Получение родительского окна текущей страницы
            Window parentWindow = Window.GetWindow(this);

            //сохранение предыдущей страницы
            MainWindow.lastPage = this;

            // Закрытие текущей страницы
            parentWindow.Content = null;

            // Открытие новой страницы
            parentWindow.Content = newPage;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра новой страницы
            AddProductPage newPage = new AddProductPage();

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
