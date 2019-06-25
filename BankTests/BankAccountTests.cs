using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BankAccountNs.BankAccountNS;

namespace BankTests
{
	[TestClass]
	public class BankAccountTests
	{
		[TestMethod]
		public void Debit_WithValidAmout_UpdatesBalance()
		{
			// Arrange
			double beginningBalance = 11.99;
			double debitAmout = 4.55;
			double expected = 7.44;
			BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

			// Act
			account.Debit(debitAmout);

			// Assert 
			double actual = account.Balance;
			Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
		}


		[TestMethod]
		public void Debit_WhenAmoutIsLessThanZero_ShouldThrowArgumentOutOfRange()
		{
			// Arrange
			double begginningBalance = 11.99;
			double debitAmount = -100.00;
			BankAccount account = new BankAccount("Mr. Bryan Walton", begginningBalance);



			// Act and assert
			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
		}

		[TestMethod]
		public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
		{
			// Arrange 
			double beginningBalance = 10.00;
			double debitAmout = 10.40;
			BankAccount account = new BankAccount("Mr Bryan Walton", beginningBalance);

			// Act
			try
			{
				account.Debit(debitAmout);
			}
			catch(System.ArgumentOutOfRangeException e)
			{
				StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
				return;
			}

			Assert.Fail("The expected exception was not thrown.");

		}

	}
}
