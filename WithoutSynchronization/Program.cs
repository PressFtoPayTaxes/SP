using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WithoutSynchronization
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();

            var threads = new Thread[5];
            for (int i = 0; i < 5; i++)
                threads[i] = new Thread(user.BankAccount.MakeOperation);

            foreach (var thread in threads)
                thread.Start();

            Console.ReadLine();
        }
    }
}
