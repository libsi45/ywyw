﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Model
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-R35ETDPP;Initial Catalog=Bd1;Integrated Security=True"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string username = textBox.Text;
                string password = passwordBox.Password;

                string query = "SELECT COUNT(*) FROM Accaunt WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int result = (int)command.ExecuteScalar();

                    if (result > 0)
                    {
                        MessageBox.Show("Успешный вход"); 
                    }
                    else
                    {
                        MessageBox.Show("Ошибка входа"); 
                    }
                }
            }
        }
    }
}