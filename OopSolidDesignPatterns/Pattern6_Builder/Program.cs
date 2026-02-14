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

// 2. Strategy Design Pattern using Delegates
delegate double DiscountStrategy(double total);

class DiscountLogic
{
    public static double ApplyFlatDiscount(double total)
    {
        // apply discount
        double discount = 0.0;
        if (total > 1000.0)
            discount = total * 0.10;
        Console.WriteLine("Discount: " + discount);
        return discount;
    }
    public static double ApplyNoDiscount(double total)
    {
        // apply discount
        Console.WriteLine("Discount: " + 0.0);
        return 0.0;
    }
    public static double ApplyFestivalDiscount(double total)
    {
        // apply discount
        double discount = 0.0;
        discount = total * 0.15;
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

// 3. Observer Design Pattern
interface IOrderListener
{
    void OnOrderPlaced(CartItem[] items, double amount);
}

class SmsNotifier : IOrderListener
{
    ISMSNotificationService notificationService = new SMSNotificationService();
    public void OnOrderPlaced(CartItem[] items, double amount)
    {
        notificationService.Send();
    }
}

class DashboardUpdater : IOrderListener
{
    public void OnOrderPlaced(CartItem[] items, double amount)
    {
        Console.WriteLine($"Order Placed. Total: {amount}, Items: {items.Length}");
    }
}

// 5. Decorator Design Pattern
interface IBill
{
    double GetAmount();
}

class BaseBill : IBill
{
    private ItemSelector itemSelector = null;
    private PriceCalculator priceCalculator = null;
    public BaseBill(ItemSelector itemSelector, PriceCalculator priceCalculator)
    {
        this.itemSelector = itemSelector;
        this.priceCalculator = priceCalculator;
    }
    public double GetAmount()
    {
        CartItem[] items = itemSelector.SelectItems();
        return priceCalculator.CalculatePrice(items);
    }
}

class DiscountDecorator : IBill
{
    private IBill bill = null;
    private DiscountStrategy discountStrategy = null;
    public DiscountDecorator(IBill bill, DiscountStrategy discountStrategy)
    {
        this.bill = bill;
        this.discountStrategy = discountStrategy;
    }
    public double GetAmount()
    {
        double amount = bill.GetAmount();
        return amount - discountStrategy(amount);
    }
}

class PackingChargesDecorator : IBill
{
    private IBill bill = null;
    private double packingCharges;
    public PackingChargesDecorator(IBill bill)
    {
        this.bill = bill;
        this.packingCharges = 50.0;
    }
    public double GetAmount()
    {
        double amount = bill.GetAmount();
        return amount + packingCharges;
    }
}

class TaxDecorator : IBill
{
    private IBill bill = null;
    private double tax;
    public TaxDecorator(IBill bill)
    {
        this.bill = bill;
        this.tax = 0.15;
    }
    public double GetAmount()
    {
        double amount = bill.GetAmount();
        return amount + (amount * tax);
    }
}

// 6. Builder Design Pattern
class BillGenerator
{
    private IBill bill = null;
    public BillGenerator(ItemSelector itemSelector, PriceCalculator priceCalculator)
    {
        this.bill = new BaseBill(itemSelector, priceCalculator);
    }
    public BillGenerator WithDiscount(DiscountStrategy discountStrategy)
    {
        this.bill = new DiscountDecorator(bill, discountStrategy);
        return this;
    }
    public BillGenerator WithPackingCharges()
    {
        this.bill = new PackingChargesDecorator(bill);
        return this;
    }
    public BillGenerator WithTax()
    {
        this.bill = new TaxDecorator(bill);
        return this;
    }
    public IBill GetBill()
    {
        return bill;
    }
    public double GetAmount()
    {
        return bill.GetAmount();
    }
}

abstract class OrderProcessor
{
    protected ItemSelector itemSelector = new ItemSelector();
    protected PriceCalculator priceCalculator = new PriceCalculator();
    protected DiscountStrategy discountLogic = null;
    protected IPaymentProcessor paymentProcessor = null;
    protected List<IOrderListener> listeners = new List<IOrderListener>();

    protected CartItem[] items = new CartItem[2];

    public OrderProcessor(IPaymentProcessor processor, DiscountStrategy discountStrategy)
    {
        paymentProcessor = processor;
        discountLogic = discountStrategy;
    }

    public void AddListener(IOrderListener listener)
    {
        listeners.Add(listener);
    }
    public void NotifyListeners(CartItem[] items, double amount)
    {
        foreach (IOrderListener listener in listeners)
            listener.OnOrderPlaced(items, amount);
    }

    public virtual double CalculateBill()
    {
        IBill bill = new BillGenerator(itemSelector, priceCalculator)
            .WithDiscount(discountLogic)
            .WithTax()
            .GetBill();
        return bill.GetAmount();
    }
    // 4. Template Method Design Pattern
    public void PlaceOrder()
    {
        items = itemSelector.SelectItems();
        double amount = CalculateBill();
        if (paymentProcessor.CanPay(amount))
        {
            paymentProcessor.ProcessPayment(amount);
            NotifyListeners(items, amount);
        }
        else
            Console.WriteLine("This payment cannot be done.");
    }
    public abstract void DisplayDetails();
};

class DeliveryOrderService : OrderProcessor
{
    public string Address { get; set; }

    public DeliveryOrderService(IPaymentProcessor processor, DiscountStrategy discountStrategy, string address)
        : base(processor, discountStrategy)
    {
        Address = address;
    }

    public override double CalculateBill()
    {
        IBill bill = new BillGenerator(itemSelector, priceCalculator)
                 .WithDiscount(discountLogic)
                 .WithPackingCharges()
                 .WithTax()
                 .GetBill();
        return bill.GetAmount();
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Delivery Order");
        foreach (CartItem item in items)
            Console.WriteLine(item.Name + " x " + item.Quantity);
        Console.WriteLine("Delivery Address: " + Address);
    }
}

class TakeAwayOrderService : OrderProcessor
{
    public string PickupTime { get; set; }

    public TakeAwayOrderService(IPaymentProcessor processor, DiscountStrategy discountStrategy, string pickupTime)
        : base(processor, discountStrategy)
    {
        PickupTime = pickupTime;
    }

    public override double CalculateBill()
    {
        IBill bill = new BillGenerator(itemSelector, priceCalculator)
                 .WithDiscount(discountLogic)
                 .WithPackingCharges()
                 .WithTax()
                 .GetBill();
        return bill.GetAmount();
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Take Away Order");
        foreach (CartItem item in items)
            Console.WriteLine(item.Name + " x " + item.Quantity);
        Console.WriteLine("Pickup Time: " + PickupTime);
    }
}

class DiningOrderService : OrderProcessor
{
    public string Table { get; set; }

    public DiningOrderService(IPaymentProcessor processor, DiscountStrategy discountStrategy, string table)
        : base(processor, discountStrategy)
    {
        Table = table;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Dining Order");
        foreach (CartItem item in items)
            Console.WriteLine(item.Name + " x " + item.Quantity);
        Console.WriteLine("Table: " + Table);
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        string mode = "UPI";
        IPaymentProcessor processor = PaymentProcessorProvider.Create(mode);
        OrderProcessor service = new DeliveryOrderService(processor, DiscountLogic.ApplyFestivalDiscount, "8:00 PM");
        //OrderProcessor service = new DiningOrderService(processor, DiscountLogic.ApplyFestivalDiscount, "Table 5");
        service.AddListener(new SmsNotifier());
        service.AddListener(new DashboardUpdater());
        service.PlaceOrder();
        Console.WriteLine("============================================================");
        service.DisplayDetails();
    }
}
