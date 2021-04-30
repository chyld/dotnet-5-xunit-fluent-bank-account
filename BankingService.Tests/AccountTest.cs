using System;
using Xunit;
using BankingService;
using FluentAssertions;

namespace BankingService.Tests
{
    public class AccountTest
    {
        [Fact]
        public void Constructor_WithIdFirstLast_InitializesAccount()
        {
            // Arrange
            Account account = new Account("CX-3", "Monica", "Barns");
            // Act
            // Assert
            account.Balance.Should().Be(0);
            account.Id.Should().Be("CX-3");
            account.Owner.ToString().Should().Be("Monica Barns");
        }

        [Theory]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(30)]
        public void Deposit_PositiveAmount_IncreasesBalance(int value)
        {
            // Arrange
            Account account = new Account("CX-3", "Monica", "Barns");
            // Act
            account.Deposit(value);
            // Assert
            account.Balance.Should().Be(value);
            account.Transactions[0].Should().Be($"Deposit: ${value}");
        }

        [Fact]
        public void Deposit_NegativeAmount_ThrowsException()
        {
            // Arrange
            Account account = new Account("CX-3", "Monica", "Barns");
            // Act
            Action action = () => account.Deposit(-10);
            // Assert
            action.Should().Throw<ApplicationException>()
            .WithMessage("Cannot deposit negative amounts");
            account.Transactions.Should().HaveCount(0);
        }

        [Fact]
        public void Withdrawal_NegativeAmount_ThrowsException()
        {
            // Arrange
            Account account = new Account("CX-3", "Monica", "Barns");
            // Act
            Action action = () => account.Withdrawal(-10);
            // Assert
            action.Should().Throw<ApplicationException>()
            .WithMessage("Cannot withdrawal negative amounts");
            account.Transactions.Should().HaveCount(0);
        }

        [Fact]
        public void Withdrawal_NotEnoughFunds_ThrowsException()
        {
            // Arrange
            Account account = new Account("CX-3", "Monica", "Barns");
            account.Deposit(100);
            // Act
            Action action = () => account.Withdrawal(101);
            // Assert
            action.Should().Throw<ApplicationException>()
            .WithMessage("Not enough funds in account");
            account.Transactions.Should().HaveCount(1);
            account.Balance.Should().Be(100);
        }

        [Fact]
        public void Withdrawal_PositiveAmount_DecreasesBalance()
        {
            // Arrange
            Account account = new Account("CX-3", "Monica", "Barns");
            account.Deposit(100);
            // Act
            account.Withdrawal(30);
            // Assert
            account.Balance.Should().Be(70);
            account.Transactions.Should().HaveCount(2);
        }
    }
}
