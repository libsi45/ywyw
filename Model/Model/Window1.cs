using System;
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

        }

    
        private void Button_Click(object sender, RoutedEventArgs e, string username, string password, string query)
        {
            string connectionString = "Data Source=LAPTOP-R35ETDPP;Initial Catalog=Bd1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int result = (int)command.ExecuteScalar();

                if (result > 0)
                {
                    MessageBox.Show("Успешный вход");

                    // Открываете окно и работаете в нём
                }
                else
                {
                    MessageBox.Show("Ошибка входа");
                }
            }
        }
    }
}

