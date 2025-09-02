
namespace Banking.Handlers;


public static class AccountListener
{
    public static   void BlockAccount()
    {
        Console.WriteLine($"Account blocked");
    }

    public static  void SendEmail()
    {
        Console.WriteLine("Email sent regarding account");
    }

}