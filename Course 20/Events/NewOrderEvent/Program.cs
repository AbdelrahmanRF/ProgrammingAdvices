using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOrderEvent
{
    public class OrderEventArgs : EventArgs
    {
        public int OrderID { get; }
        public float OrderTotalPrice { get; }
        public string ClientEmail { get; }

        public OrderEventArgs (int OrderID, float OrderTotalPrice, string ClientEmail)
        {
            this.OrderID = OrderID;
            this.OrderTotalPrice = OrderTotalPrice;
            this.ClientEmail = ClientEmail;
        }
    }

    public class Order
    {
        public event EventHandler<OrderEventArgs> OnOrderCreated;

        public void CreateOrder(int OrderID, float OrderTotalPrice, string ClientEmail)
        {
            Console.WriteLine("Order Created Successfully");

            if (OnOrderCreated != null)
            {
                OnOrderCreated(this, new OrderEventArgs(OrderID, OrderTotalPrice, ClientEmail));
            }
        }
    }

    public class EmailService
    {
        public void Subscribe(Order order)
        {
            order.OnOrderCreated += HandelNewOrder;
        }

        public void UnSubscribe(Order order)
        {
            order.OnOrderCreated -= HandelNewOrder;
        }

        private void HandelNewOrder(object sender, OrderEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine($"-------------Email Service------------");
            Console.WriteLine($"Email Service Object Received a new order event");
            Console.WriteLine($"Order ID: {e.OrderID}");
            Console.WriteLine($"Order Price: {e.OrderTotalPrice}");
            Console.WriteLine($"Email: {e.ClientEmail}");
            Console.WriteLine($"\nSend an email");
            Console.WriteLine($"--------------------------------------");
            Console.WriteLine();
        }
    }

    public class SMSService
    {
        public void Subscribe(Order order)
        {
            order.OnOrderCreated += HandelNewOrder;
        }

        public void UnSubscribe(Order order)
        {
            order.OnOrderCreated -= HandelNewOrder;
        }

        private void HandelNewOrder(object sender, OrderEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine($"-------------SMS Service------------");
            Console.WriteLine($"SMS Service Object Received a new order event");
            Console.WriteLine($"Order ID: {e.OrderID}");
            Console.WriteLine($"Order Price: {e.OrderTotalPrice}");
            Console.WriteLine($"Email: {e.ClientEmail}");
            Console.WriteLine($"\nSend SMS");
            Console.WriteLine($"--------------------------------------");
            Console.WriteLine();
        }
    }

    public class ShippingService
    {
        public void Subscribe(Order order)
        {
            order.OnOrderCreated += HandelNewOrder;
        }

        public void UnSubscribe(Order order)
        {
            order.OnOrderCreated -= HandelNewOrder;
        }

        private void HandelNewOrder(object sender, OrderEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine($"-------------Shipping Service------------");
            Console.WriteLine($"Shipping Service Object Received a new order event");
            Console.WriteLine($"Order ID: {e.OrderID}");
            Console.WriteLine($"Order Price: {e.OrderTotalPrice}");
            Console.WriteLine($"Email: {e.ClientEmail}");
            Console.WriteLine($"\nShipping Order");
            Console.WriteLine($"--------------------------------------");
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();

            EmailService emailService = new EmailService();
            SMSService smsService = new SMSService();
            ShippingService shippingService = new ShippingService();

            emailService.Subscribe(order);
            smsService.Subscribe(order);
            shippingService.Subscribe(order);

            order.CreateOrder(1, 25.5f, "Waleed@gmail.com");

        }
    }
}
