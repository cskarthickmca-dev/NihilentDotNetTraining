
using Banking;
using Banking.Handlers;

Account acct123 = new Account();
acct123.underBalance += AccountListener.BlockAccount;
acct123.underBalance += AccountListener.SendEmail;

acct123.Balance = 70000;
acct123.Withdraw(62000);

