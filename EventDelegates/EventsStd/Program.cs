namespace EventsStd
{
    public class LowBalanceEventArgs : EventArgs
    {
        public double Amount { get; set; }
        public DateTime TxTime {  get; set; }
        // ...
    }
    // pre-defined
    // delegate void EventHandler(object sender, EventArgs e);
    public class Account
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Balance { get; set; }
        private event EventHandler _lowBalance;
        public event EventHandler LowBalance
        {
            add
            {
                _lowBalance += value;
            }
            remove
            {
                _lowBalance -= value;
            }
        }

        public void Deposit(double amount)
        {
            Balance = Balance + amount;
        }
        public void Withdraw(double amount)
        {
            if (Balance < amount)
            {
                if (_lowBalance != null)
                {
                    LowBalanceEventArgs e = new LowBalanceEventArgs() { Amount = amount, TxTime = DateTime.Now };
                    _lowBalance(this, e); // raise event
                }
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
        public static void SendSMS(object sender, EventArgs e)
        {
            Account account = (Account)sender;
            LowBalanceEventArgs evt = (LowBalanceEventArgs)e;
            Console.WriteLine($"SMS --> HDFC Account {account.Id} Low Balance while withdrawing amount Rs. {evt.Amount}/- on {evt.TxTime}");
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
    internal class Program
    {
        static void Main(string[] args)
        {
            HdfcBank hdfc = new HdfcBank();
            hdfc.TestTransaction();
        }
    }
}
