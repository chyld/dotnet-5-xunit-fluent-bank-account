using System;

namespace BankingService
{
    public struct User
    {
        public string first;
        public string last;

        public override string ToString() => $"{first} {last}";
    }
}
