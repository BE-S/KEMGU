using System;

namespace ConsoleApp2.sixthTaskClass
{
    class CreditCardPayment : IPaymentStrategy
    {
        private string _cardNumber;
        private string _expiry;
        private string _cvv;

        public CreditCardPayment()
        {
            Console.Write("Номер карты: ");
            _cardNumber = Console.ReadLine();
            Console.Write("Срок действия (MM/YY): ");
            _expiry = Console.ReadLine();
            Console.Write("CVV: ");
            _cvv = Console.ReadLine();
        }

        public string GetName()
        {
            return "Кредитная карта ****" + _cardNumber.Substring(Math.Max(0, _cardNumber.Length - 4));
        }

        public bool Pay(decimal amount)
        {
            Console.WriteLine("Оплата {0:F2} ₽ через {1}", amount, GetName());
            Console.WriteLine("Обработка платежа...");
            return true;
        }
    }
}
