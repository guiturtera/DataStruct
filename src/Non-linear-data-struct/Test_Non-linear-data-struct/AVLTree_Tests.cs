using NUnit.Framework;
using Non_linear_data_struct;
using System.Collections.Generic;

namespace Test_Non_linear_data_struct
{
    public class AVLTree_Tests
    {
        AVLSearchTree test;
        [SetUp]
        public void Setup()
        {
            test = new AVLSearchTree();
        }

        [Test]
        public void Insert_Test()
        {
            // 63, 9, 19, 27, 18, 108, 99, 81.
            test.Insert(63);
            test.Insert(9);
            test.Insert(19);
            test.Insert(27);
            test.Insert(18);
            test.Insert(108);
            test.Insert(99);
            test.Insert(81);
            List<int> list = new List<int>() { 9, 18, 19, 27, 63, 81, 99, 108 };
            Assert.AreEqual(list, test.InOrderTransversal());
        }

    }
}