namespace Banking;

public class Account
{
   
    public decimal Balance { get; set; }

    public event AccountOperation underBalance;
    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
           decimal tempAmount= Balance- amount;
           if (tempAmount < 10000)
           {
               underBalance(); 
           }
           Balance = tempAmount;
        }
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

}