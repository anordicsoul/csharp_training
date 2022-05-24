using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemowalTests : AuthTestBase
    {

        [Test]
        public void ContactRemowalTest()
        {
            if (!app.Contacts.AContact(2))
            {
                app.Contacts.Create(new ContactData("cont5"));
            }

            app.Contacts.Remove(2);
        }
    }
    }
