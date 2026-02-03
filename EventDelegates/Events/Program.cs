namespace Events
{
    public delegate void BalanceHandler(int accId, double amount);
    public class Account
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Balance { get; set; }
        public event BalanceHandler LowBalance;

        public void Deposit(double amount)
        {
            Balance = Balance + amount;
        }
        public void Withdraw(double amount)
        {
            if(Balance < amount)
            {
                if(LowBalance != null)
                    LowBalance(Id, amount); // raise event
            }
            else
                Balance = Balance - amount;
        }
        public override string ToString()
        {
            return $"Account => Id={Id}, Type={Type}, Balance={Balance}";
        }
    }

    class HdfcBank
    {
        public static void SendSMS(int accId, double amount)
        {
            Console.WriteLine($"SMS --> HDFC Account {accId} Low Balance while withdrawing amount Rs. {amount}/-");
        }
        public void TestTransaction()
        {
            Account acc = new Account() { Id = 1, Type = "Saving", Balance = 1000.0 };
            acc.LowBalance += SendSMS;
            Console.WriteLine("acc --> " + acc);
            acc.Deposit(500);
            Console.WriteLine("acc --> " + acc);
            acc.Withdraw(2000);
            Console.WriteLine("acc --> " + acc);
        }
    }
    class CitiBank
    {
        public static void SendSMS(int accId, double amount)
        {
            Console.WriteLine($"SMS --> Citi Account {accId} Low Balance while withdrawing amount Rs. {amount}/-");
        }
        public static void SendEmail(int accId, double amount)
        {
            Console.WriteLine($"Email --> Citi Account {accId} Low Balance while withdrawing amount Rs. {amount}/-");
        }
        public void TestTransaction()
        {
            Account acc = new Account() { Id = 1, Type = "Saving", Balance = 1000.0 };
            acc.LowBalance += SendEmail;
            acc.LowBalance += SendSMS;
            Console.WriteLine("acc --> " + acc);
            acc.Deposit(500);
            Console.WriteLine("acc --> " + acc);
            acc.Withdraw(2000);
            Console.WriteLine("acc --> " + acc);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //HdfcBank hdfc = new HdfcBank();
            //hdfc.TestTransaction();
            CitiBank citi = new CitiBank();
            citi.TestTransaction();
        }
    }
}
