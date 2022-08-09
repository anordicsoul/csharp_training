using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]

        public void TestRemovingContactFromGroup()

        {
            if (GroupData.GetAll().Count() == 0)
            {
                app.Groups.Create(new GroupData("newGroup"));
            }

            if (ContactData.GetAll().Count == 0)
            {
                app.Contacts.Create(new ContactData("Tatsina", "Kulevich"));
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            if (oldList.Count() == 0)
            {
                ContactData contact = ContactData.GetAll().First();
                app.Contacts.AddContactToGroup(contact, group);
            }

            ContactData contactToRemove = group.GetContacts().First();

            app.Contacts.RemoveContactFromGroup(contactToRemove, group);

            List<ContactData> newList = group.GetContacts();

            oldList.Remove(contactToRemove);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

    }
}
