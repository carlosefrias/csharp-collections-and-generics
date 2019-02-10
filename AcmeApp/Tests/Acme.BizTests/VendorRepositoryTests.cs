using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetriveValueTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = 42;

            //Act
            var actual = repository.RetriveValue<int>("Select ...", 42);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void RetriveValueStringTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = "Test";

            //Act
            var actual = repository.RetriveValue<string>("Select ...", "Test");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void RetriveValueObjectTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            //Act
            var actual = repository.RetriveValue("Select ...", vendor);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();
            expected.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
            expected.Add(new Vendor() { VendorId = 1, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" });

            //Act
            var actual = repository.Retrieve();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}