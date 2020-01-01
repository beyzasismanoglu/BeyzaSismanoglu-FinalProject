using BeyzaSismanoglu_FinalProject.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BeyzaSismanoglu_FinalProject.Service;

namespace BeyzaSismanoglu_FinalProject
{
    /// <summary>
    /// PasswordUpdate.xaml etkileşim mantığı
    /// </summary>
    public partial class PasswordUpdate : Window
    {
        private User loginUser;
        private PlastichaneDb db = new PlastichaneDb();
        public PasswordUpdate(User user)
        {
            loginUser = user;
            InitializeComponent();
        }

  

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UserService userService = new UserService();
            string temp1 = userService.hashPassword(txtOldPassword.Text);

            if (temp1 == loginUser.Password)
            {
                string temp2 = userService.hashPassword(txtNewPassword.Password);
                string temp3 = userService.hashPassword(txtNewPassword1.Password);

                if (temp2 == temp3)
                {
                    loginUser.Password = temp2;
                    db.  Users.Update(loginUser);
                    db.SaveChangesAsync();
                    MessageBox.Show("Şifreniz güncellendi!");
                }
                else MessageBox.Show("Hatalı giriş yaptınız.");


            }
            else MessageBox.Show("Eski şifrenizi hatalı girdiniz.");
        }
    }
}
