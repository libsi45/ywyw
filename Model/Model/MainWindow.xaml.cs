using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Model
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            dataGrid.ItemsSource = records;
        }

        private void LoadData()
        {
            string connectionString = "Data Source=LAPTOP-R35ETDPP;Initial Catalog=Bd1;Integrated Security=True";
            string sqlQuery = "SELECT * FROM оборудование";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
        private ObservableCollection<Record> records = new ObservableCollection<Record>();

      
       
     

   
        private void AddButton_Click_1(object sender, RoutedEventArgs e)
        {
            records.Add(new Record());
        }

        private void DeleteButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                records.Remove(dataGrid.SelectedItem as Record);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение данных
        }
    }

    public class Record : INotifyPropertyChanged
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }