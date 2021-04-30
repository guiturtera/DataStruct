using NUnit.Framework;
using Non_linear_data_struct;

namespace Test_Non_linear_data_struct
{
    public class Binary_Tree_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Insert_Test()
        {
            BinarySearchTree simple = new BinarySearchTree();
            simple.Insert(2);
            Assert.AreEqual(2, simple.root.Value);
            Assert.AreEqual(null, simple.root.Right);
            Assert.AreEqual(null, simple.root.Left);
            simple.Insert(5);
            Assert.AreEqual(2, simple.root.Value);
            Assert.AreEqual(5, simple.root.Right.Value);
            Assert.AreEqual(null, simple.root.Left);
            simple.Insert(6);
            Assert.AreEqual(2, simple.root.Value);
            Assert.AreEqual(6, simple.root.Right.Right.Value);
            Assert.AreEqual(null, simple.root.Left);
            simple.Insert(4);
            Assert.AreEqual(2, simple.root.Value);
            Assert.AreEqual(4, simple.root.Right.Left.Value);
            Assert.AreEqual(null, simple.root.Left);
            simple.Insert(1);
            Assert.AreEqual(2, simple.root.Value);
            Assert.AreEqual(4, simple.root.Right.Left.Value);
            Assert.AreEqual(1, simple.root.Left.Value);
            simple.Insert(-1);
            Assert.AreEqual(2, simple.root.Value);
            Assert.AreEqual(4, simple.root.Right.Left.Value);
            Assert.AreEqual(-1, simple.root.Left.Left.Value);
            simple.Insert(0);
            Assert.AreEqual(2, simple.root.Value);
            Assert.AreEqual(4, simple.root.Right.Left.Value);
            Assert.AreEqual(0, simple.root.Left.Left.Right.Value);
            simple.Insert(3);
            Assert.AreEqual(2, simple.root.Value);
            Assert.AreEqual(5, simple.root.Right.Value);
            Assert.AreEqual(3, simple.root.Right.Left.Left.Value);
        }
    }
}