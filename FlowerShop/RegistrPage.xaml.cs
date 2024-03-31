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
    /// Логика взаимодействия для RegistrPage.xaml
    /// </summary>
    public partial class RegistrPage : Page
    {
        public RegistrPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FlowerDeliveryEntities1())
            {
                // Получение введенных данных о пользователе
                string username = UsernameTextBox.Text;
                string email = EmailTextBox.Text;
                string password = PasswordBox.Password;
                string confirmPassword = ConfirmPasswordBox.Password;

                // Проверка наличия всех данных
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля для регистрации.");
                    return;
                }

                // Проверка совпадения паролей
                if (password != confirmPassword)
                {
                    MessageBox.Show("Пароли не совпадают. Пожалуйста, введите одинаковые пароли.");
                    return;
                }

                try
                {
                    // Создание нового пользователя
                    Users newUser = new Users
                    {
                        Username = username,
                        Password = password,
                        Email = email,
                        Role = "покупатель" // Установите роль в зависимости от вашей логики приложения
                    };

                    // Добавление нового пользователя в контекст базы данных
                    context.Users.Add(newUser);

                    // Сохранение изменений в базе данных
                    context.SaveChanges();

                    MessageBox.Show("Регистрация успешно завершена!");

                    // Создание экземпляра новой страницы
                    StartPage newPage = new StartPage();

                    // Получение родительского окна текущей страницы
                    Window parentWindow = Window.GetWindow(this);

                    // Закрытие текущей страницы
                    parentWindow.Content = null;

                    // Открытие новой страницы
                    parentWindow.Content = newPage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при регистрации пользователя: " + ex.Message);
                }
            }  
        }
    }
}
