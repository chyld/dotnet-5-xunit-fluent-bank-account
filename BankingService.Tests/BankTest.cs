using System;
using Xunit;
using BankingService;
using FluentAssertions;

namespace BankingService.Tests
{
    public class BankTest
    {
        [Fact]
        public void Constructor_WithNoArguments_AfterInitContainsNoAccounts()
        {
            // Arrange
            Bank bank = new Bank();
            // Act
            // Assert
            bank.Accounts.Should().HaveCount(0);
        }

        [Fact]
        public void AddAccount_WithIdFirstLast_AddsNewAccount()
        {
            // Arrange
            Bank bank = new Bank();
            // Act
            bank.AddAccount("AB-1", "Sara", "Jones");
            // Assert
            bank.Accounts.Should().HaveCount(1);
        }
    }
}
