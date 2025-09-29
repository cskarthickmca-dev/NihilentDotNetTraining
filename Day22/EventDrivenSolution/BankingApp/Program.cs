using Banking;


Account account = new Account("123456", 200000);
AccountListener listener = new AccountListener();
account.OverBalance += listener.OnOverBalance;  //attach event handler
account.UnderBalance += listener.OnUnderBalance; //attach event handler

account.Deposit(70000); // This should trigger the OverBalance event
Console.WriteLine($"Current Balance: {account.Balance}");

