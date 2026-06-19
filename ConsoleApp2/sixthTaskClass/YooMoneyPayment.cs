using System;

namespace ConsoleApp2.sixthTaskClass
{
    class YooMoneyPayment : IPaymentStrategy
    {
        private string _account;

        public YooMoneyPayment()
        {
            Console.Write("Номер кошелька Ю.Деньги: ");
            _account = Console.ReadLine();
        }

        public string GetName()
        {
            return "Ю.Деньги (" + _account + ")";
        }

        public bool Pay(decimal amount)
        {
            Console.WriteLine("Оплата {0:F2} ₽ через {1}", amount, GetName());
            Console.WriteLine("Подтвердите перевод в приложении Ю.Деньги...");
            return true;
        }
    }
}
