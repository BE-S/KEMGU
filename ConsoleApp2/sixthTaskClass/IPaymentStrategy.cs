namespace ConsoleApp2.sixthTaskClass
{
    interface IPaymentStrategy
    {
        bool Pay(decimal amount);
        string GetName();
    }
}
