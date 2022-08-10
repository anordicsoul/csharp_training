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


            GroupData group = GroupData.GetAll().FirstOrDefault(gr => gr.GetContacts().Count() > 0);
            if (group == null)
            {
                group = GroupData.GetAll()[0];
                app.Contacts.AddContactToGroup(ContactData.GetAll().First(), group);
            }
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Intersect(oldList).First();




            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            ContactData toBeRemoved = oldList[0];
            newList.Sort();
            oldList.Sort();
            Assert.AreNotEqual(oldList, newList);
        }
    }
}
