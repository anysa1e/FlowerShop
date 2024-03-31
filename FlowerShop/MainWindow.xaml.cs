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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Page lastPage;
        public static int userId;

        public MainWindow()
        {
            InitializeComponent();

            // Создание экземпляра страницы
            StartPage startPage = new StartPage();

            // Открытие страницы в главном окне
            Content = startPage;
        }

        public List<Users> GetAllUsers()
        {
            using (var context = new FlowerDeliveryEntities1())
            {
                return context.Users.ToList();
            }
        }

        public void CreateUser(Users user)
        {
            using (var context = new FlowerDeliveryEntities1())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public Users GetUserById(int userId)
        {
            using (var context = new FlowerDeliveryEntities1())
            {
                return context.Users.Find(userId);
            }
        }

        public void UpdateUser(Users updatedUser)
        {
            using (var context = new FlowerDeliveryEntities1())
            {
                var existingUser = context.Users.Find(updatedUser.UserID);
                if (existingUser != null)
                {
                    context.Entry(existingUser).CurrentValues.SetValues(updatedUser);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteUser(int userId)
        {
            using (var context = new FlowerDeliveryEntities1())
            {
                var userToDelete = context.Users.Find(userId);
                if (userToDelete != null)
                {
                    context.Users.Remove(userToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
