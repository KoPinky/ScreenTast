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

namespace CreateAuthorize
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        gr672_lmaEntities5 db = new gr672_lmaEntities5();
        public AuthorizationWindow()
        {
            InitializeComponent();
          
            
        }

        private void AutorizationClick(object sender, RoutedEventArgs e)
        {
            auth(login.Text, password.Password);
        }
        public bool auth(string Login, string Password)
        {
            if(string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return false;
            }
            
            {
                var user = db.Users
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == login.Text && u.Password == password.Password);
                if(user == null)
                {
                    MessageBox.Show("Пользователь с таким именем не найден!");
                    return false;
                }
                MessageBox.Show("Пользователь успешно найден");

                

                return true;


            }

        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow();
            rw.Show();
            this.Close();
        }
    }
}
