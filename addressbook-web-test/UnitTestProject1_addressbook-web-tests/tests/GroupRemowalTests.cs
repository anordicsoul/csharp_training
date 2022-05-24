using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemowalTests : AuthTestBase
    {
        

        [Test]
        public void GroupRemowalTest()
        {
            if (!app.Groups.AGroup(1))
            {
                app.Groups.Create(new GroupData("gr5"));
            } 

            app.Groups.Remove(1);
        }
    }
}
