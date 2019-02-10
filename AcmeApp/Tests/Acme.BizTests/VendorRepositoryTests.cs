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
            expected.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });

            //Act
            var actual = repository.Retrieve();
            //Assert
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void RetrieveWithIteratorTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>(){
                new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" },
                new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" }
            };
            //Act
            var vendorIterator = repository.RetrieveWithIterator();
            foreach (var item in vendorIterator)
            {
                Console.WriteLine(item);
            }
            var actual = vendorIterator.ToList();
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveAllTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                new Vendor()
                {
                    VendorId = 22, CompanyName = "Amalgamated Toys", Email = "a@abc.com"
                },
                new Vendor()
                {
                    VendorId = 35, CompanyName = "Car Toys", Email = "car@xyz.com"
                },
                new Vendor()
                {
                    VendorId = 28, CompanyName = "Toy Blocks Inc", Email = "blocks@abc.com"
                },
                new Vendor()
                {
                    VendorId = 42, CompanyName = "Toys for Fun", Email = "fun@xyz.com"
                }
            };
            //Act
            var vendors = repository.RetrieveAll();
            //var vendorQuery = from v in vendors
            //                  where v.CompanyName.ToLower().Contains("toy")
            //                  orderby v.CompanyName
            //                  select v;
            //var vendorQuery = vendors.Where(FilterContains)
            //                        .OrderBy(OrderCompaniesByName);
            var vendorQuery = vendors.Where(v => v.CompanyName.ToLower().Contains("toy"))
                                .OrderBy(v => v.CompanyName);
            //Assert
            CollectionAssert.AreEqual(expected, vendorQuery.ToList());
        }
        //private bool FilterContains(Vendor v) => v.CompanyName.ToLower().Contains("toy");
        //private string OrderCompaniesByName(Vendor v) => v.CompanyName;
    }
}