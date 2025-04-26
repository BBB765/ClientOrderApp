using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ClientOrderApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Order> Orders { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Clients = new ObservableCollection<Client>();
            Orders = new ObservableCollection<Order>();

            this.DataContext = this;
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ClientNameTextBox.Text)) string.IsNullOrEmpty(ClientPhoneTextBox.Text);
            {
            }

            var client = new Client
            {
                Id = Clients.Count + 1,
                Name = ClientNameTextBox.Text,
                Email = ClientEmailTextBox.Text,
                Phone = ClientPhoneTextBox.Text
            };

            Clients.Add(client);

            ClientNameTextBox.Clear();
            ClientEmailTextBox.Clear();
            ClientPhoneTextBox.Clear();
        }

        private void EditClient_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsListView.SelectedItem != null)
            {
                var selectedClient = (Client)ClientsListView.SelectedItem;
                selectedClient.Name = ClientNameTextBox.Text;
                selectedClient.Email = ClientEmailTextBox.Text;
                selectedClient.Phone = ClientPhoneTextBox.Text;
                ClientsListView.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите клиента для редактирования.");
            }
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsListView.SelectedItem != null)
            {
                Clients.Remove((Client)ClientsListView.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления.");
            }
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (Orders.Count == 0) string.IsNullOrEmpty(OrderAmountTextBox.Text);
            {
            }
            var order = new Order
            {
                Id = Orders.Count + 1,
                ClientId = Clients.Count > 0 ? Clients[0].Id : 1,  
                Product = OrderProductTextBox.Text,
                OrderDate = DateTime.Now,
                Amount = double.TryParse(OrderAmountTextBox.Text, out double amount) ? amount : 0
            };

            Orders.Add(order);

            OrderProductTextBox.Clear();
            OrderAmountTextBox.Clear();
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersListView.SelectedItem != null)
            {
                var selectedOrder = (Order)OrdersListView.SelectedItem;
                selectedOrder.Product = OrderProductTextBox.Text;
                selectedOrder.Amount = double.TryParse(OrderAmountTextBox.Text, out double amount) ? amount : 0;
                OrdersListView.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите заказ для редактирования.");
            }
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersListView.SelectedItem != null)
            {
                Orders.Remove((Order)OrdersListView.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите заказ для удаления.");
            }
        }
    }
}
