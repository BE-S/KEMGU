using System;
using System.Collections.Generic;

namespace ConsoleApp2.sixthTaskClass
{
    class Cart
    {
        private List<Book> _items;

        public Cart()
        {
            _items = new List<Book>();
        }

        public void Add(Book book)
        {
            _items.Add(book);
            Console.WriteLine("«{0}» добавлена в корзину", book.Title);
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                Console.WriteLine("«{0}» удалена из корзины", _items[index].Title);
                _items.RemoveAt(index);
            }
        }

        public void Show()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Корзина пуста");
                return;
            }

            Console.WriteLine("\n--- Корзина ---");
            for (int i = 0; i < _items.Count; ++i)
            {
                Console.WriteLine("{0}. {1}", i + 1, _items[i]);
            }
            Console.WriteLine("----------------");
            Console.WriteLine("Итого: {0:F2} ₽", getTotal());
        }

        public decimal getTotal()
        {
            decimal total = 0;
            foreach (Book book in _items)
            {
                total += book.Price;
            }
            return total;
        }

        public int Count()
        {
            return _items.Count;
        }

        public void Checkout(IPaymentStrategy payment)
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Корзина пуста. Добавьте книги перед оформлением.");
                return;
            }

            decimal total = getTotal();
            Console.WriteLine("\nОформление заказа на сумму {0:F2} ₽", total);
            Show();

            if (payment.Pay(total))
            {
                Console.WriteLine("Оплата прошла успешно! Спасибо за покупку!\n");
                _items.Clear();
            }
            else
            {
                Console.WriteLine("Ошибка оплаты. Попробуйте снова.");
            }
        }
    }
}
