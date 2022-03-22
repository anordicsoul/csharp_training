using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase 
    {
        
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("gr2");
            group.Header = "test";
            group.Footer = "test";

            app.Groups.Create(group);
            app.Out.Logout();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Navigator.GoToGroupsPage();
            app.Groups.Create(group);
            app.Out.Logout();
        }
    }
}
