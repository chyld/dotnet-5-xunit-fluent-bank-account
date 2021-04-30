using System;
using Xunit;
using BankingService;
using FluentAssertions;

namespace BankingService.Tests
{
    public class UserTest
    {
        [Fact]
        public void ToString_WithUserObject_ReturnsFullName()
        {
            // Arrange
            User user = new User(){first="Bob", last="Smith"};
            // Act
            string fullName = user.ToString();
            // Assert
            fullName.Should().Be("Bob Smith");
        }
    }
}
