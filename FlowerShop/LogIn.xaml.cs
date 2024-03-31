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
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение введенного логина и пароля
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            using (var context = new FlowerDeliveryEntities1())
            {
                try
                {
                    // Поиск пользователя в базе данных с введенным логином и паролем
                    var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                    if (user != null)
                    {
                        if (user.Role == "покупатель")
                        {
                            //Создание экземпляра новой страницы
                            ClientPage newPage = new ClientPage();

                            // Получение родительского окна текущей страницы
                            Window parentWindow = Window.GetWindow(this);

                            //сохранение предыдущей страницы
                            MainWindow.lastPage = this;

                            // Закрытие текущей страницы
                            parentWindow.Content = null;

                            // Открытие новой страницы
                            parentWindow.Content = newPage;

                            MainWindow.userId = user.UserID;
                        }
                        else if(user.Role == "администратор")
                        {
                            //Создание экземпляра новой страницы
                            AdminPage newPage = new AdminPage();

                            // Получение родительского окна текущей страницы
                            Window parentWindow = Window.GetWindow(this);

                            //сохранение предыдущей страницы
                            MainWindow.lastPage = this;

                            // Закрытие текущей страницы
                            parentWindow.Content = null;

                            // Открытие новой страницы
                            parentWindow.Content = newPage;

                            MainWindow.userId = user.UserID;
                        }
                        else if(user.Role == "менеджерконтента")
                        {
                            // Создание экземпляра новой страницы
                            ContentMakerPage newPage = new ContentMakerPage();

                            // Получение родительского окна текущей страницы
                            Window parentWindow = Window.GetWindow(this);

                            //сохранение предыдущей страницы
                            MainWindow.lastPage = this;

                            // Закрытие текущей страницы
                            parentWindow.Content = null;

                            // Открытие новой страницы
                            parentWindow.Content = newPage;

                            MainWindow.userId = user.UserID;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль. Попробуйте снова.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
                }
            }
        }
    }
    
}
