using System;
using System.Threading;

namespace WithoutSynchronization
{
    public class BankAccount
    {
        public int Money { get; set; }

        public BankAccount()
        {
            Money = 50000;
        }

        public void MakeOperation()
        {
            var currentThread = Thread.CurrentThread;
            Console.WriteLine($"Поток {currentThread.ManagedThreadId} начал работу");

            int passedSeconds = 0;
            while (passedSeconds < 60)
            {
                Random random = new Random();
                Thread.Sleep(5000);
                int randomNumber = random.Next(-10000, 10000);
                Money += randomNumber;
                Console.WriteLine($"На счет перечислилось {randomNumber}\nТекущий счёт: {Money}");
                passedSeconds += 5;
            }

            Console.WriteLine($"Поток {currentThread.ManagedThreadId} Завершил работу");
        }
    }
}