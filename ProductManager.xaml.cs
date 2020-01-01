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
    /// ProductManager.xaml etkileşim mantığı
    /// </summary>
    public partial class ProductManager : Window
    {
        private User loginUser;
        public ProductManager(User user)
        {
            loginUser = user;
            InitializeComponent();
        }



        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            txtLogin.Text = "Merhaba, " + loginUser.RoleName + " " + loginUser.Username;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PasswordUpdate passwordUpdate = new PasswordUpdate(loginUser);
            passwordUpdate.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)        // https://youtu.be/66e074esd7s
        {
            var txtboxName = txtBoxName.Text;
            var txtboxStock = txtBoxStock.Text;
            var txtboxWaster = txtBoxWaster.Text;
            var txtboxPrice = txtBoxPrice.Text;

            using(PlastichaneDb db = new PlastichaneDb())
            {
                Product product = new Product()
                {
                    Product_Name=txtboxName,
                    Stock= Int32.Parse(txtboxStock),
                    Waster_product= Int32.Parse(txtboxWaster),
                    Price= Int32.Parse(txtboxPrice)

                };
                db.Products.Add(product);
                db.SaveChanges();
                MessageBox.Show("Ürün girişi başarıyla gerçekleşti!");
                txtBoxName.Text =" ";
                txtBoxStock.Text = " ";
                txtBoxWaster.Text = " ";
                txtBoxPrice.Text = " ";
               

            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Uygulamadan Çıkmak İstediğinize Emin misiniz?", "Onay", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
