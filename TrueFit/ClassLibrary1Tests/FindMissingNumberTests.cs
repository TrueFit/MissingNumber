using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindNumberClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNumberClassLibrary.Tests
{
    [TestClass()]
    public class FindMissingNumberTests
    {
        [TestMethod()]
        public void BasicUsageTest()
        {
            FindMissingNumber find = new FindMissingNumber();
            string testArray = "9,8,6,5,4";
            int result = find.DetermineMissingNumber(testArray);
            Assert.AreEqual(result, 7);
        }

        [TestMethod()]
        public void OneNegativeTest()
        {
            FindMissingNumber find = new FindMissingNumber();
            string testArray = "-1,0,1,2,4";
            int result = find.DetermineMissingNumber(testArray);
            Assert.AreEqual(result, 3);
        }

        [TestMethod()]
        public void AllNegativeTests()
        {
            FindMissingNumber find = new FindMissingNumber();
            string testArray = "-1,-2,-4";
            int result = find.DetermineMissingNumber(testArray);
            Assert.AreEqual(result, -3);
        }

        [TestMethod()]
        public void BigNumberTests()
        {
            FindMissingNumber find = new FindMissingNumber();
            string testArray = "10000000,10000001,10000002,10000004";
            int result = find.DetermineMissingNumber(testArray);
            Assert.AreEqual(result, 10000003);
        }

        [TestMethod()]
        public void LettersTests()
        {
            FindMissingNumber find = new FindMissingNumber();
            string testArray = "1,2,a,3,4,6";
            int result = find.DetermineMissingNumber(testArray);
            Assert.AreEqual(result, 5);
        }
    }
}