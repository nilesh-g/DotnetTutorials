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
        items[0] = new CartItem { Name = "Pizza", Quantity = 4 };
        items[1] = new CartItem { Name = "Burger", Quantity = 4 };
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

// 2. Strategy Design Pattern using Delegate
delegate double DiscountStrategy(double total);

class DiscountLogic
{
    public static double ApplyFlatDiscount(double total)
    {
        // apply discount
        double discount = 0.0;
        if (total > 1000.0)
            discount = total * 0.10;
        Console.WriteLine("Flat Discount: " + discount);
        return discount;
    }

    public static double ApplyNoDiscount(double total)
    {
        // apply discount
        Console.WriteLine("No Discount: " + 0.0);
        return 0.0;
    }

    public static double ApplyFestivalDiscount(double total)
    {
        // apply discount
        double discount = 0.0;
        discount = total * 0.15;
        Console.WriteLine("Festival Discount: " + discount);
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

// 1. Factory Design Pattern
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
class AllNotificationService : ISMSNotificationService, IPushNotificationService, IEmailNotificationService
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
    private DiscountStrategy discountLogic = null;
    private IPaymentProcessor paymentProcessor = null;
    private ISMSNotificationService notificationService = new SMSNotificationService();

    private CartItem[] items = new CartItem[2];

    public FoodOrderService(IPaymentProcessor processor, DiscountStrategy discountStrategy)
    {
        paymentProcessor = processor;
        discountLogic = discountStrategy;
    }

    public void PlaceOrder()
    {
        items = itemSelector.SelectItems();
        double total = priceCalculator.CalculatePrice(items);
        double discount = 0.0;
        if (discountLogic != null)
            discount = discountLogic(total);
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
        FoodOrderService service = new FoodOrderService(processor, DiscountLogic.ApplyFlatDiscount);
        service.PlaceOrder();
    }
}
