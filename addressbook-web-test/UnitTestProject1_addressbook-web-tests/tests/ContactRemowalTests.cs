using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemowalTests : TestBase
    {

        [Test]
        public void ContactRemowalTest()
        {
            app.Contacts.Remove(2);
        }
    }
    }
