namespace WithSynchronization
{
    public  class User
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