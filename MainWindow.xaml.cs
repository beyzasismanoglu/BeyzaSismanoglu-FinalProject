﻿using System;
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
using BeyzaSismanoglu_FinalProject.Service;

namespace BeyzaSismanoglu_FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Giris_Click(object sender, RoutedEventArgs e)
        {
            UserService userService = new UserService();
            var loginUser = userService.Login(txtUsername.Text, txtPassword.Password);

                if (txtUsername.Text == "barbaros" && loginUser != null)
                {
                    ProductManager productManager = new ProductManager(loginUser);
                    productManager.Show();
                    this.Close();
                }
                else if(txtUsername.Text == "msismanoglu" && loginUser != null)
                {
                    GeneralManager generalManager = new GeneralManager(loginUser);
                    generalManager.Show();
                    this.Close();
                }
                else if(loginUser==null)
                {
                    MessageBox.Show("Hatalı giris");
                }
        }
        
        }
    }
