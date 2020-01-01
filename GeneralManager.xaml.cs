using BeyzaSismanoglu_FinalProject.Data;
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


namespace BeyzaSismanoglu_FinalProject
{
    /// <summary>
    /// GeneralManager.xaml etkileşim mantığı
    /// </summary>
    public partial class GeneralManager : Window
    {
        private User loginUser;
        public GeneralManager(User user)
        {
            loginUser = user;
            InitializeComponent();
            using(PlastichaneDb db=new PlastichaneDb())                 //data grid'in içine databasedeki ürünleri çekmek için bunu kullandım. https://www.youtube.com/watch?v=66e074esd7s&list=PLLwnctd8nNtyX6JJSha6PTpV0K_zV5Dve
            {
                Report.ItemsSource = db.Products.ToList();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PasswordUpdate passwordUpdate = new PasswordUpdate(loginUser);
            passwordUpdate.Show();
            this.Close();
        }


        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Uygulamadan Çıkmak İstediğinize Emin misiniz?", "Onay", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Window_Loaded_2(object sender, RoutedEventArgs e)
        {
            txtLogin.Text = "Merhaba, " + loginUser.RoleName + " " + loginUser.Username;
        }

        private void btnBack_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
