using System;
using System.Collections.Generic;

namespace ConsoleApp2.sixthTaskClass
{
    class BookStore
    {
        private List<Book> _catalog;
        private Cart _cart;

        public BookStore()
        {
            _cart = new Cart();
            _catalog = new List<Book>
            {
                new Book("Война и мир", "Лев Толстой", 1500, "978-5-17-123456-1"),
                new Book("Преступление и наказание", "Фёдор Достоевский", 1200, "978-5-17-123456-2"),
                new Book("Мастер и Маргарита", "Михаил Булгаков", 1300, "978-5-17-123456-3"),
                new Book("Евгений Онегин", "Александр Пушкин", 900, "978-5-17-123456-4"),
                new Book("Мёртвые души", "Николай Гоголь", 1100, "978-5-17-123456-5"),
                new Book("Герой нашего времени", "Михаил Лермонтов", 950, "978-5-17-123456-6"),
                new Book("Тихий Дон", "Михаил Шолохов", 1600, "978-5-17-123456-7"),
                new Book("Анна Каренина", "Лев Толстой", 1400, "978-5-17-123456-8"),
                new Book("Идиот", "Фёдор Достоевский", 1250, "978-5-17-123456-9"),
                new Book("Собачье сердце", "Михаил Булгаков", 850, "978-5-17-123456-0")
            };
        }

        public void ShowCatalog()
        {
            Console.WriteLine("\n--- Каталог книг ---");
            for (int i = 0; i < _catalog.Count; ++i)
            {
                Console.WriteLine("{0,2}. {1}", i + 1, _catalog[i]);
            }
            Console.WriteLine("--------------------");
        }

        public void AddToCart()
        {
            ShowCatalog();
            Console.Write("Введите номер книги: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _catalog.Count)
            {
                _cart.Add(_catalog[index - 1]);
            }
            else
            {
                Console.WriteLine("Неверный номер");
            }
        }

        public void RemoveFromCart()
        {
            _cart.Show();
            if (_cart.Count() == 0) return;

            Console.Write("Введите номер позиции для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _cart.Count())
            {
                _cart.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine("Неверный номер");
            }
        }

        public void ShowCart()
        {
            _cart.Show();
        }

        public void Checkout()
        {
            _cart.Show();
            if (_cart.Count() == 0) return;

            Console.WriteLine("\nВыберите способ оплаты:");
            Console.WriteLine("1 - Кредитная карта");
            Console.WriteLine("2 - Ю.Деньги");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            IPaymentStrategy payment = null;

            switch (choice)
            {
                case "1":
                    payment = new CreditCardPayment();
                    break;
                case "2":
                    payment = new YooMoneyPayment();
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    return;
            }

            _cart.Checkout(payment);
        }

        public static void Run()
        {
            BookStore store = new BookStore();
            bool working = true;

            while (working)
            {
                Console.Clear();
                Console.WriteLine(
                    "--- Книжный интернет-магазин ---\n" +
                    "1 - Показать каталог\n" +
                    "2 - Добавить книгу в корзину\n" +
                    "3 - Корзина\n" +
                    "4 - Удалить из корзины\n" +
                    "5 - Оформить заказ\n" +
                    "0 - Выйти в главное меню"
                );
                Console.Write("\nВыберите действие: ");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        store.ShowCatalog();
                        break;
                    case "2":
                        store.AddToCart();
                        break;
                    case "3":
                        store.ShowCart();
                        break;
                    case "4":
                        store.RemoveFromCart();
                        break;
                    case "5":
                        store.Checkout();
                        break;
                    case "0":
                        working = false;
                        break;
                    default:
                        Console.WriteLine("Команда не распознана");
                        break;
                }

                if (working)
                {
                    Console.WriteLine("\nНажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
        }
    }
}
