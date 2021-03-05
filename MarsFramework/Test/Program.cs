using NUnit.Framework;
using MarsFramework.Pages;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test, Order(1)]
            public void addSkill()
            {
                test = extent.StartTest("ShareSkill Test");
                ShareSkill obj = new ShareSkill();
                obj.EnterShareSkill();
            }
            [Test, Order(2)]
            public void manageListings()
            {
                test = extent.StartTest("Managelisting Test");
                ManageListings Obj2 = new ManageListings();
                Obj2.Viewlistings();
                Obj2.EditListing();
                Obj2.DeleteListing();
            }



        }
    }
}