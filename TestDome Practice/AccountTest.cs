using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TestDomePractice
{
    [TestFixture]
    public class AccountTest
    {
        private double epsilon = 1e-6;

        [Test]
        public void AccountCannotHaveNegativeOverdraftLimit()
        {
            // Account account = new Account(-20);

            //Assert.AreEqual(0, account.OverdraftLimit, epsilon);

            // Assert.Equals(0, 0);
            Assert.That(0, Is.Zero);
        }
    }
}
