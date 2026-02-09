/*
// God class

class FoodOrderService
{
    class CartItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
    
    public void PlaceOrder()
    {
        // select items
        CartItem[] items = new CartItem[2];
        items[0] = new CartItem { Name = "Pizza", Quantity = 1 };
        items[1] = new CartItem { Name = "Burger", Quantity = 2 };
        Console.WriteLine("Items Selected: " + items.Length);

        // calculate price
        double total = 0.0;
        foreach (CartItem item in items)
        {
            if (item.Name == "Pizza")
                total += item.Quantity * 200.0;
            else if (item.Name == "Burger")
                total += item.Quantity * 100.0;
        }
        Console.WriteLine("Total Price: " + total);

        // apply discount
        double discount = 0.0;
        if (total > 1000.0)
            discount = total * 0.10;
        Console.WriteLine("Discount: " + discount);

        // calculate bill
        double amount = total - discount;
        Console.WriteLine("Final Bill: " + amount);

        // process payment
        string mode = "CARD";
        if (mode == "CARD")
            Console.WriteLine($"Payment of Rs. {amount} received by Card.");
        else if (mode == "UPI")
            Console.WriteLine($"Payment of Rs. {amount} received by UPI.");

        // send notification
        Console.WriteLine("Sending SMS: Order Placed!");
    }
};
internal class Program
{
    static void Main(string[] args)
    {
        FoodOrderService service = new FoodOrderService();
        service.PlaceOrder();
    }
}
*/

/*
// God class - Logic decomposed into Functions, Encapsulation
class FoodOrderService
{
    class CartItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
    private CartItem[] items = new CartItem[2];

    public void PlaceOrder()
    {
        items = SelectItems();
        double total = CalculatePrice(items);
        double discount = ApplyDiscount(total);
        // calculate bill
        double amount = total - discount;
        Console.WriteLine("Final Bill: " + amount);
        ProcessPayment(amount);
        SendNotification();
    }

    private void SendNotification()
    {
        // send notification
        Console.WriteLine("Sending SMS: Order Placed!");
    }

    private void ProcessPayment(double amount)
    {
        // process payment
        string mode = "CARD";
        if (mode == "CARD")
            Console.WriteLine($"Payment of Rs. {amount} received by Card.");
        else if (mode == "UPI")
            Console.WriteLine($"Payment of Rs. {amount} received by UPI.");
    }

    private double ApplyDiscount(double total)
    {
        // apply discount
        double discount = 0.0;
        if (total > 1000.0)
            discount = total * 0.10;
        Console.WriteLine("Discount: " + discount);
        return discount;
    }

    private double CalculatePrice(CartItem[] items)
    {
        // calculate price
        double total = 0.0;
        foreach (CartItem item in items)
        {
            if (item.Name == "Pizza")
                total += item.Quantity * 200.0;
            else if (item.Name == "Burger")
                total += item.Quantity * 100.0;
        }
        Console.WriteLine("Total Price: " + total);
        return total;
    }

    private CartItem[] SelectItems()
    {
        // select items
        CartItem[] items = new CartItem[2];
        items[0] = new CartItem { Name = "Pizza", Quantity = 1 };
        items[1] = new CartItem { Name = "Burger", Quantity = 2 };
        Console.WriteLine("Items Selected: " + items.Length);
        return items;
    }
};
internal class Program
{
    static void Main(string[] args)
    {
        FoodOrderService service = new FoodOrderService();
        service.PlaceOrder();
    }
}
*/

/*
// SRP - Single Responsibility Principle
class CartItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}

class ItemSelector
{
    public CartItem[] SelectItems()
    {
        // select items
        CartItem[] items = new CartItem[2];
        items[0] = new CartItem { Name = "Pizza", Quantity = 1 };
        items[1] = new CartItem { Name = "Burger", Quantity = 2 };
        Console.WriteLine("Items Selected: " + items.Length);
        return items;
    }
}

class PriceCalculator
{
    public double CalculatePrice(CartItem[] items)
    {
        // calculate price
        double total = 0.0;
        foreach (CartItem item in items)
        {
            if (item.Name == "Pizza")
                total += item.Quantity * 200.0;
            else if (item.Name == "Burger")
                total += item.Quantity * 100.0;
        }
        Console.WriteLine("Total Price: " + total);
        return total;
    }
}

class DiscountLogic
{
    public double ApplyDiscount(double total)
    {
        // apply discount
        double discount = 0.0;
        if (total > 1000.0)
            discount = total * 0.10;
        Console.WriteLine("Discount: " + discount);
        return discount;
    }
}

class PaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        string mode = "CARD";
        if (mode == "CARD")
            Console.WriteLine($"Payment of Rs. {amount} received by Card.");
        else if (mode == "UPI")
            Console.WriteLine($"Payment of Rs. {amount} received by UPI.");
    }
}

class NotificationService
{
    public void SendNotification()
    {
        // send notification
        Console.WriteLine("Sending SMS: Order Placed!");
    }
}
class FoodOrderService
{
    private ItemSelector itemSelector = new ItemSelector();
    private PriceCalculator priceCalculator = new PriceCalculator();
    private DiscountLogic discountLogic = new DiscountLogic();
    private PaymentProcessor paymentProcessor = new PaymentProcessor();
    private NotificationService notificationService = new NotificationService();

    private CartItem[] items = new CartItem[2];

    public void PlaceOrder()
    {
        items = itemSelector.SelectItems();
        double total = priceCalculator.CalculatePrice(items);
        double discount = discountLogic.ApplyDiscount(total);
        // calculate bill
        double amount = total - discount;
        Console.WriteLine("Final Bill: " + amount);
        paymentProcessor.ProcessPayment(amount);
        notificationService.SendNotification();
    }
};
internal class Program
{
    static void Main(string[] args)
    {
        FoodOrderService service = new FoodOrderService();
        service.PlaceOrder();
    }
}
*/

/*
// DIP Violated (Dependency Inversion Principle)
class CartItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}

class ItemSelector
{
    public CartItem[] SelectItems()
    {
        // select items
        CartItem[] items = new CartItem[2];
        items[0] = new CartItem { Name = "Pizza", Quantity = 1 };
        items[1] = new CartItem { Name = "Burger", Quantity = 2 };
        Console.WriteLine("Items Selected: " + items.Length);
        return items;
    }
}

class PriceCalculator
{
    public double CalculatePrice(CartItem[] items)
    {
        // calculate price
        double total = 0.0;
        foreach (CartItem item in items)
        {
            if (item.Name == "Pizza")
                total += item.Quantity * 200.0;
            else if (item.Name == "Burger")
                total += item.Quantity * 100.0;
        }
        Console.WriteLine("Total Price: " + total);
        return total;
    }
}

class DiscountLogic
{
    public double ApplyDiscount(double total)
    {
        // apply discount
        double discount = 0.0;
        if (total > 1000.0)
            discount = total * 0.10;
        Console.WriteLine("Discount: " + discount);
        return discount;
    }
}

class CardPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by Card.");
    }
}

class UPIPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by UPI.");
    }
}

class NotificationService
{
    public void SendNotification()
    {
        // send notification
        Console.WriteLine("Sending SMS: Order Placed!");
    }
}
class FoodOrderService
{
    private ItemSelector itemSelector = new ItemSelector();
    private PriceCalculator priceCalculator = new PriceCalculator();
    private DiscountLogic discountLogic = new DiscountLogic();
    private CardPaymentProcessor cardPaymentProcessor = new CardPaymentProcessor();
    private UPIPaymentProcessor upiPaymentProcessor = new UPIPaymentProcessor();
    private NotificationService notificationService = new NotificationService();

    private CartItem[] items = new CartItem[2];

    public void PlaceOrder()
    {
        items = itemSelector.SelectItems();
        double total = priceCalculator.CalculatePrice(items);
        double discount = discountLogic.ApplyDiscount(total);
        // calculate bill
        double amount = total - discount;
        Console.WriteLine("Final Bill: " + amount);
        string mode = "CARD";
        if(mode == "CARD")
            cardPaymentProcessor.ProcessPayment(amount);
        else
            upiPaymentProcessor.ProcessPayment(amount);
        notificationService.SendNotification();
    }
};
internal class Program
{
    static void Main(string[] args)
    {
        FoodOrderService service = new FoodOrderService();
        service.PlaceOrder();
    }
}
*/

/*
// DIP + OCP (Open Closed Principle)
class CartItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}

class ItemSelector
{
    public CartItem[] SelectItems()
    {
        // select items
        CartItem[] items = new CartItem[2];
        items[0] = new CartItem { Name = "Pizza", Quantity = 1 };
        items[1] = new CartItem { Name = "Burger", Quantity = 2 };
        Console.WriteLine("Items Selected: " + items.Length);
        return items;
    }
}

class PriceCalculator
{
    public double CalculatePrice(CartItem[] items)
    {
        // calculate price
        double total = 0.0;
        foreach (CartItem item in items)
        {
            if (item.Name == "Pizza")
                total += item.Quantity * 200.0;
            else if (item.Name == "Burger")
                total += item.Quantity * 100.0;
        }
        Console.WriteLine("Total Price: " + total);
        return total;
    }
}

class DiscountLogic
{
    public double ApplyDiscount(double total)
    {
        // apply discount
        double discount = 0.0;
        if (total > 1000.0)
            discount = total * 0.10;
        Console.WriteLine("Discount: " + discount);
        return discount;
    }
}

interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}

class CardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by Card.");
    }
}

class UPIPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by UPI.");
    }
}

class NotificationService
{
    public void SendNotification()
    {
        // send notification
        Console.WriteLine("Sending SMS: Order Placed!");
    }
}
class FoodOrderService
{
    private ItemSelector itemSelector = new ItemSelector();
    private PriceCalculator priceCalculator = new PriceCalculator();
    private DiscountLogic discountLogic = new DiscountLogic();
    private IPaymentProcessor paymentProcessor = null;
    private NotificationService notificationService = new NotificationService();

    private CartItem[] items = new CartItem[2];

    public FoodOrderService(IPaymentProcessor processor)
    {
        paymentProcessor = processor;
    }

    public void PlaceOrder()
    {
        items = itemSelector.SelectItems();
        double total = priceCalculator.CalculatePrice(items);
        double discount = discountLogic.ApplyDiscount(total);
        // calculate bill
        double amount = total - discount;
        Console.WriteLine("Final Bill: " + amount);
        paymentProcessor.ProcessPayment(amount);
        notificationService.SendNotification();
    }
};
internal class Program
{
    static void Main(string[] args)
    {
        IPaymentProcessor processor = null;
        string mode = "UPI";
        if (mode == "CARD")
            processor = new CardPaymentProcessor();
        else
            processor = new CardPaymentProcessor();
        FoodOrderService service = new FoodOrderService(processor);
        service.PlaceOrder();
    }
}
*/

/*
// Better DIP & OCP, but LSP Violated (Liskov Substitution Principle)
class CartItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}

class ItemSelector
{
    public CartItem[] SelectItems()
    {
        // select items
        CartItem[] items = new CartItem[2];
        items[0] = new CartItem { Name = "Pizza", Quantity = 2 };
        items[1] = new CartItem { Name = "Burger", Quantity = 2 };
        Console.WriteLine("Items Selected: " + items.Length);
        return items;
    }
}

class PriceCalculator
{
    public double CalculatePrice(CartItem[] items)
    {
        // calculate price
        double total = 0.0;
        foreach (CartItem item in items)
        {
            if (item.Name == "Pizza")
                total += item.Quantity * 200.0;
            else if (item.Name == "Burger")
                total += item.Quantity * 100.0;
        }
        Console.WriteLine("Total Price: " + total);
        return total;
    }
}

class DiscountLogic
{
    public double ApplyDiscount(double total)
    {
        // apply discount
        double discount = 0.0;
        if (total > 1000.0)
            discount = total * 0.10;
        Console.WriteLine("Discount: " + discount);
        return discount;
    }
}

interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}

class CardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by Card.");
    }
}

class CashPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        if (amount > 500.0)
            throw new NotSupportedException();
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by Cash.");
    }
}

class UPIPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by UPI.");
    }
}

class PaymentProcessorProvider
{
    public static IPaymentProcessor Create(string mode)
    {
        if (mode == "CARD")
            return new CardPaymentProcessor();
        else if (mode == "UPI")
            return new UPIPaymentProcessor();
        else if (mode == "CASH")
            return new CashPaymentProcessor();
        return null;
    }
}

class NotificationService
{
    public void SendNotification()
    {
        // send notification
        Console.WriteLine("Sending SMS: Order Placed!");
    }
}
class FoodOrderService
{
    private ItemSelector itemSelector = new ItemSelector();
    private PriceCalculator priceCalculator = new PriceCalculator();
    private DiscountLogic discountLogic = new DiscountLogic();
    private IPaymentProcessor paymentProcessor = null;
    private NotificationService notificationService = new NotificationService();

    private CartItem[] items = new CartItem[2];

    public FoodOrderService(IPaymentProcessor processor)
    {
        paymentProcessor = processor;
    }

    public void PlaceOrder()
    {
        items = itemSelector.SelectItems();
        double total = priceCalculator.CalculatePrice(items);
        double discount = discountLogic.ApplyDiscount(total);
        // calculate bill
        double amount = total - discount;
        Console.WriteLine("Final Bill: " + amount);
        paymentProcessor.ProcessPayment(amount);
        notificationService.SendNotification();
    }
};

internal class Program
{
    static void Main(string[] args)
    {
        string mode = "CASH";
        IPaymentProcessor processor = PaymentProcessorProvider.Create(mode);
        FoodOrderService service = new FoodOrderService(processor);
        service.PlaceOrder();
    }
}
*/

/*
// LSP Satisfied
class CartItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}

class ItemSelector
{
    public CartItem[] SelectItems()
    {
        // select items
        CartItem[] items = new CartItem[2];
        items[0] = new CartItem { Name = "Pizza", Quantity = 2 };
        items[1] = new CartItem { Name = "Burger", Quantity = 2 };
        Console.WriteLine("Items Selected: " + items.Length);
        return items;
    }
}

class PriceCalculator
{
    public double CalculatePrice(CartItem[] items)
    {
        // calculate price
        double total = 0.0;
        foreach (CartItem item in items)
        {
            if (item.Name == "Pizza")
                total += item.Quantity * 200.0;
            else if (item.Name == "Burger")
                total += item.Quantity * 100.0;
        }
        Console.WriteLine("Total Price: " + total);
        return total;
    }
}

class DiscountLogic
{
    public double ApplyDiscount(double total)
    {
        // apply discount
        double discount = 0.0;
        if (total > 1000.0)
            discount = total * 0.10;
        Console.WriteLine("Discount: " + discount);
        return discount;
    }
}

interface IPaymentProcessor
{
    bool CanPay(double amount)
    {
        return true;
    }
    void ProcessPayment(double amount);
}

class CardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by Card.");
    }
}

class UPIPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by UPI.");
    }
}

class CashPaymentProcessor : IPaymentProcessor
{
    public bool CanPay(double amount)
    {
        return amount <= 500.0;
    }
    public void ProcessPayment(double amount)
    {
        if (amount > 500.0)
            throw new NotSupportedException();
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by Cash.");
    }
}

class PaymentProcessorProvider
{
    public static IPaymentProcessor Create(string mode)
    {
        if (mode == "CARD")
            return new CardPaymentProcessor();
        else if (mode == "UPI")
            return new UPIPaymentProcessor();
        else if (mode == "CASH")
            return new CashPaymentProcessor();
        return null;
    }
}

class NotificationService
{ 
    public void Send()
    {
        Console.WriteLine("Sending SMS: Order Placed!");
    }
}

class FoodOrderService
{
    private ItemSelector itemSelector = new ItemSelector();
    private PriceCalculator priceCalculator = new PriceCalculator();
    private DiscountLogic discountLogic = new DiscountLogic();
    private IPaymentProcessor paymentProcessor = null;
    private NotificationService notificationService = new NotificationService();

    private CartItem[] items = new CartItem[2];

    public FoodOrderService(IPaymentProcessor processor)
    {
        paymentProcessor = processor;
    }

    public void PlaceOrder()
    {
        items = itemSelector.SelectItems();
        double total = priceCalculator.CalculatePrice(items);
        double discount = discountLogic.ApplyDiscount(total);
        // calculate bill
        double amount = total - discount;
        Console.WriteLine("Final Bill: " + amount);
        if (paymentProcessor.CanPay(amount))
        {
            paymentProcessor.ProcessPayment(amount);
            notificationService.Send();
        }
        else
            Console.WriteLine("This payment cannot be done.");
    }
};
internal class Program
{
    static void Main(string[] args)
    {
        string mode = "UPI";
        IPaymentProcessor processor = PaymentProcessorProvider.Create(mode);
        FoodOrderService service = new FoodOrderService(processor);
        service.PlaceOrder();
    }
}
*/

/*
// ISP Violated (Interface Segregation Priciple)
class CartItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}

class ItemSelector
{
    public CartItem[] SelectItems()
    {
        // select items
        CartItem[] items = new CartItem[2];
        items[0] = new CartItem { Name = "Pizza", Quantity = 2 };
        items[1] = new CartItem { Name = "Burger", Quantity = 2 };
        Console.WriteLine("Items Selected: " + items.Length);
        return items;
    }
}

class PriceCalculator
{
    public double CalculatePrice(CartItem[] items)
    {
        // calculate price
        double total = 0.0;
        foreach (CartItem item in items)
        {
            if (item.Name == "Pizza")
                total += item.Quantity * 200.0;
            else if (item.Name == "Burger")
                total += item.Quantity * 100.0;
        }
        Console.WriteLine("Total Price: " + total);
        return total;
    }
}

class DiscountLogic
{
    public double ApplyDiscount(double total)
    {
        // apply discount
        double discount = 0.0;
        if (total > 1000.0)
            discount = total * 0.10;
        Console.WriteLine("Discount: " + discount);
        return discount;
    }
}

interface IPaymentProcessor
{
    bool CanPay(double amount)
    {
        return true;
    }
    void ProcessPayment(double amount);
}

class CardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by Card.");
    }
}

class UPIPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by UPI.");
    }
}

class CashPaymentProcessor : IPaymentProcessor
{
    public bool CanPay(double amount)
    {
        return amount <= 500.0;
    }
    public void ProcessPayment(double amount)
    {
        if (amount > 500.0)
            throw new NotSupportedException();
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by Cash.");
    }
}

class PaymentProcessorProvider
{
    public static IPaymentProcessor Create(string mode)
    {
        if (mode == "CARD")
            return new CardPaymentProcessor();
        else if (mode == "UPI")
            return new UPIPaymentProcessor();
        else if (mode == "CASH")
            return new CashPaymentProcessor();
        return null;
    }
}

interface INotificationService
{
    void SendSMS();
    void SendEmail();
    void SendPush();
}
class AllNotificationService : INotificationService
{
    public void SendSMS()
    {
        Console.WriteLine("Sending SMS: Order Placed!");
    }
    public void SendEmail()
    {
        Console.WriteLine("Sending Email: Order Placed!");
    }
    public void SendPush()
    {
        Console.WriteLine("Sending Push: Order Placed!");
    }
}
class SMSNotificationService : INotificationService
{
    public void SendSMS()
    {
        Console.WriteLine("Sending SMS: Order Placed!!");
    }

    public void SendEmail()
    {
        throw new NotImplementedException();
    }

    public void SendPush()
    {
        throw new NotImplementedException();
    }
}

class FoodOrderService
{
    private ItemSelector itemSelector = new ItemSelector();
    private PriceCalculator priceCalculator = new PriceCalculator();
    private DiscountLogic discountLogic = new DiscountLogic();
    private IPaymentProcessor paymentProcessor = null;
    //private INotificationService notificationService = new AllNotificationService();
    private INotificationService notificationService = new SMSNotificationService();

    private CartItem[] items = new CartItem[2];

    public FoodOrderService(IPaymentProcessor processor)
    {
        paymentProcessor = processor;
    }

    public void PlaceOrder()
    {
        items = itemSelector.SelectItems();
        double total = priceCalculator.CalculatePrice(items);
        double discount = discountLogic.ApplyDiscount(total);
        // calculate bill
        double amount = total - discount;
        Console.WriteLine("Final Bill: " + amount);
        if (paymentProcessor.CanPay(amount))
        {
            paymentProcessor.ProcessPayment(amount);
            notificationService.SendSMS();
            notificationService.SendEmail();
            notificationService.SendPush();
        }
        else
            Console.WriteLine("This payment cannot be done.");
    }
};
internal class Program
{
    static void Main(string[] args)
    {
        string mode = "UPI";
        IPaymentProcessor processor = PaymentProcessorProvider.Create(mode);
        FoodOrderService service = new FoodOrderService(processor);
        service.PlaceOrder();
    }
}
*/

/*
// ISP
class CartItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}

class ItemSelector
{
    public CartItem[] SelectItems()
    {
        // select items
        CartItem[] items = new CartItem[2];
        items[0] = new CartItem { Name = "Pizza", Quantity = 2 };
        items[1] = new CartItem { Name = "Burger", Quantity = 2 };
        Console.WriteLine("Items Selected: " + items.Length);
        return items;
    }
}

class PriceCalculator
{
    public double CalculatePrice(CartItem[] items)
    {
        // calculate price
        double total = 0.0;
        foreach (CartItem item in items)
        {
            if (item.Name == "Pizza")
                total += item.Quantity * 200.0;
            else if (item.Name == "Burger")
                total += item.Quantity * 100.0;
        }
        Console.WriteLine("Total Price: " + total);
        return total;
    }
}

class DiscountLogic
{
    public double ApplyDiscount(double total)
    {
        // apply discount
        double discount = 0.0;
        if (total > 1000.0)
            discount = total * 0.10;
        Console.WriteLine("Discount: " + discount);
        return discount;
    }
}

interface IPaymentProcessor
{
    bool CanPay(double amount)
    {
        return true;
    }
    void ProcessPayment(double amount);
}

class CardPaymentProcessor:IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by Card.");
    }
}

class UPIPaymentProcessor:IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by UPI.");
    }
}

class CashPaymentProcessor : IPaymentProcessor
{
    public bool CanPay(double amount)
    {
        return amount <= 500.0;
    }
    public void ProcessPayment(double amount)
    {
        if (amount > 500.0)
            throw new NotSupportedException();
        // process payment
        Console.WriteLine($"Payment of Rs. {amount} received by Cash.");
    }
}

class PaymentProcessorProvider
{
    public static IPaymentProcessor Create(string mode)
    {
        if (mode == "CARD")
            return new CardPaymentProcessor();
        else if (mode == "UPI")
            return new UPIPaymentProcessor();
        else if (mode == "CASH")
            return new CashPaymentProcessor();
        return null;
    }
}

interface ISMSNotificationService
{
    void Send();
}
interface IEmailNotificationService
{
    void Send();
}
interface IPushNotificationService
{
    void Send();
}
class AllNotificationService :ISMSNotificationService, IPushNotificationService, IEmailNotificationService
{
    public void Send()
    {
        Console.WriteLine("Sending SMS: Order Placed!");
        Console.WriteLine("Sending Email: Order Placed!");
        Console.WriteLine("Sending Push: Order Placed!");
    }
}
class SMSNotificationService : ISMSNotificationService
{
    public void Send()
    {
        Console.WriteLine("Sending SMS: Order Placed!!");
    }
}

class FoodOrderService
{
    private ItemSelector itemSelector = new ItemSelector();
    private PriceCalculator priceCalculator = new PriceCalculator();
    private DiscountLogic discountLogic = new DiscountLogic();
    private IPaymentProcessor paymentProcessor = null;
    private ISMSNotificationService notificationService = new SMSNotificationService();

    private CartItem[] items = new CartItem[2];
    
    public FoodOrderService(IPaymentProcessor processor)
    {
        paymentProcessor = processor; 
    }

    public void PlaceOrder()
    {
        items = itemSelector.SelectItems();
        double total = priceCalculator.CalculatePrice(items);
        double discount = discountLogic.ApplyDiscount(total);
        // calculate bill
        double amount = total - discount;
        Console.WriteLine("Final Bill: " + amount);
        if (paymentProcessor.CanPay(amount))
        {
            paymentProcessor.ProcessPayment(amount);
            notificationService.Send();
        }
        else
            Console.WriteLine("This payment cannot be done.");
    }
};
internal class Program
{
    static void Main(string[] args)
    {
        string mode = "UPI";
        IPaymentProcessor processor = PaymentProcessorProvider.Create(mode);
        FoodOrderService service = new FoodOrderService(processor);
        service.PlaceOrder();
    }
}
*/