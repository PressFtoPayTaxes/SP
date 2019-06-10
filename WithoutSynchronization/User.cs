using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutSynchronization
{
    public class User
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public BankAccount BankAccount { get; set; }

        public User()
        {
            BankAccount = new BankAccount();
        }
    }
}
