using Bank;

namespace BankAccountTests
{
    public class BankAccountTests
    {

        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
            this.bankAccount = new BankAccount(1000);
        }

        [Test]

        public void Test_Amount_Validinput()
        {

            var initAmount = new decimal(1000);
            var expectedAmount = new decimal(1000);
            bankAccount = new BankAccount(initAmount);

            var actual = bankAccount.Amount;

            Assert.AreEqual(expectedAmount, actual);

        }

        [Test]

        public void Test_GetAmount_PositiveValueZero()

        {
            var initAmount = new decimal(0);
            var expectedAmount = new decimal(0);

            bankAccount = new BankAccount(initAmount);

            var actual = bankAccount.Amount;

            Assert.That(actual, Is.EqualTo(expectedAmount));


        }

        [Test]

        public void Test_GetAmount_NegativeValue()

        {
            decimal initAmount = -500;
            string message = "Amount cannot be negative!";

            Assert.That(() => new BankAccount(initAmount),
            Throws.ArgumentException.With.Message.EqualTo(message));

        }

        [Test]

        public void Test_Deposit_PositiveValue()

        {
            decimal initAmount = 1000;
            decimal depositAmount = 500;
            decimal expectedAmount = 1500;

            bankAccount = new BankAccount(initAmount);

            bankAccount.Deposit(depositAmount);

            Assert.That(bankAccount.Amount, Is.EqualTo(expectedAmount));
        }

        [Test]

        public void Test_Deposit_NegativeValue()

        {
            decimal initAmount = 1000;
            decimal depositAmount = -500;

            string message = "Deposit cannot be negative or zero!";

            Assert.That(() => new BankAccount(initAmount).Deposit(depositAmount),
            Throws.ArgumentException.With.Message.EqualTo(message));
        }

        [Test]

        public void Test_Deposit_ZeroValue()

        {
            decimal initAmount = 1000;
            decimal depositAmount = 0;

            string message = "Deposit cannot be negative or zero!";

            Assert.That(() => new BankAccount(initAmount).Deposit(depositAmount),
            Throws.ArgumentException.With.Message.EqualTo(message));
        }

        [Test]

        public void Test_Withdraw_PositiveValue()

        {
            decimal initAmount = 1000;
            decimal depositAmount = 500;
            decimal withdrawAmount = 900;
            decimal expectedAmount = 582;

            bankAccount = new BankAccount(initAmount);

            bankAccount.Deposit(depositAmount);

            bankAccount.Withdraw(withdrawAmount);

            Assert.That(bankAccount.Amount, Is.EqualTo(expectedAmount));

        }

        [Test]

        public void Test_Withdraw_NegativeValue()

        {
            decimal initAmount = 1000;
            decimal depositAmount = 500;
            decimal withdrawAmount = -900;
            string message = "Withdrawal cannot be negative or zero!";

            bankAccount = new BankAccount(initAmount);

            bankAccount.Deposit(depositAmount);

            Assert.That(() => bankAccount.Withdraw(withdrawAmount),
            Throws.ArgumentException.With.Message.EqualTo(message));
        }

        [Test]

        public void Test_Withdraw_ZeroValue()

        {
            decimal initAmount = 1000;
            decimal depositAmount = 500;
            decimal withdrawAmount = 0;
            string message = "Withdrawal cannot be negative or zero!";

            bankAccount = new BankAccount(initAmount);

            bankAccount.Deposit(depositAmount);

            Assert.That(() => bankAccount.Withdraw(withdrawAmount),
            Throws.ArgumentException.With.Message.EqualTo(message));
        }

        [Test]

        public void Test_Withdraw_ExceedValue()

        {
            decimal initAmount = 1000;
            decimal depositAmount = 500;
            decimal withdrawAmount = 2000;
            string message = "Withdrawal exceeds account balance!";

            bankAccount = new BankAccount(initAmount);

            bankAccount.Deposit(depositAmount);

            Assert.That(() => bankAccount.Withdraw(withdrawAmount),
            Throws.ArgumentException.With.Message.EqualTo(message));
        }
    }
}