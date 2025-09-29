
namespace Banking;

public class AccountListener
{
    // Event handler for OverBalance event

    public void OnOverBalance(object sender, EventArgs e)
    {
        if (sender is Account account)
        {
            Console.WriteLine($"Alert: Account {account.AccountNumber} has exceeded the balance limit.");
            //logic for applying income tax
            decimal tax = 25000;
            account.Withdraw(tax);
            Console.WriteLine($"Income tax of {tax} has been deducted from account {account.AccountNumber}.");
       
        }
    }

    public void OnUnderBalance(object sender, EventArgs e)
    {
        if (sender is Account account)
        {


            Console.WriteLine($"Alert: Account {account.AccountNumber} has fallen below the minimum balance.");
            decimal penalty = 1000;
            account.Withdraw(penalty);
            Console.WriteLine($"Penalty of {penalty} has been deducted from account {account.AccountNumber}.");
        }
    }
}
