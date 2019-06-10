using System;
using System.Threading;

namespace WithSynchronization
{
    public class BankAccount
    {
        public int Money { get; set; }

        public BankAccount()
        {
            Money = 50000;
        }

        private object lockObject = new object();
        public void MakeOperation()
        {
            var currentThread = Thread.CurrentThread;
            Console.WriteLine($"Поток {currentThread.ManagedThreadId} начал работу");

            lock (lockObject)
            {
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
            }

            Console.WriteLine($"Поток {currentThread.ManagedThreadId} Завершил работу");
        }
    }
}