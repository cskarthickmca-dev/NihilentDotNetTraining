

namespace  Banking;

public delegate void AccountEventHandler(object sender, EventArgs e);

public class Account
{
    public string AccountNumber { get; }
    public decimal Balance { get; private set; }

    //define events
    public event AccountEventHandler? OverBalance;
    public event AccountEventHandler? UnderBalance;
    public Account(string accountNumber, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        decimal calculatedAmount = Balance + amount;
        if (calculatedAmount > 250000)
        {
            // raise an event here for OverBalance
            OverBalance?.Invoke(this, EventArgs.Empty);
        }

        Balance = calculatedAmount;
    }

    public void Withdraw(decimal amount)
    {
        decimal calculatedAmount = Balance - amount;
        if (calculatedAmount < 10000)
        {
            UnderBalance?.Invoke(this, EventArgs.Empty);
        }
        Balance = calculatedAmount;
    }
}