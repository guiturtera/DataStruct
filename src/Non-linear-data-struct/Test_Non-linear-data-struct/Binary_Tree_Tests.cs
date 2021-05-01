using NUnit.Framework;
using Non_linear_data_struct;
using System.Collections.Generic;

namespace Test_Non_linear_data_struct
{
    public class Binary_Tree_Tests
    {
        BinarySearchTree test;
        [SetUp]
        public void Setup()
        {
            test = new BinarySearchTree();
            test.Insert(1);
            test.Insert(2);
            test.Insert(4);
            test.Insert(0);
            test.Insert(-5);
            test.Insert(10);
            test.Insert(6);
            test.Insert(5);
            test.Insert(3);
        }

        [Test]
        public void Insert_Test()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(2);
            Assert.AreEqual(2, tree.root.Value);
            Assert.AreEqual(null, tree.root.Right);
            Assert.AreEqual(null, tree.root.Left);
            tree.Insert(5);
            Assert.AreEqual(2, tree.root.Value);
            Assert.AreEqual(5, tree.root.Right.Value);
            Assert.AreEqual(null, tree.root.Left);
            tree.Insert(6);
            Assert.AreEqual(2, tree.root.Value);
            Assert.AreEqual(6, tree.root.Right.Right.Value);
            Assert.AreEqual(null, tree.root.Left);
            tree.Insert(4);
            Assert.AreEqual(2, tree.root.Value);
            Assert.AreEqual(4, tree.root.Right.Left.Value);
            Assert.AreEqual(null, tree.root.Left);
            tree.Insert(1);
            Assert.AreEqual(2, tree.root.Value);
            Assert.AreEqual(4, tree.root.Right.Left.Value);
            Assert.AreEqual(1, tree.root.Left.Value);
            tree.Insert(-1);
            Assert.AreEqual(2, tree.root.Value);
            Assert.AreEqual(4, tree.root.Right.Left.Value);
            Assert.AreEqual(-1, tree.root.Left.Left.Value);
            tree.Insert(0);
            Assert.AreEqual(2, tree.root.Value);
            Assert.AreEqual(4, tree.root.Right.Left.Value);
            Assert.AreEqual(0, tree.root.Left.Left.Right.Value);
            tree.Insert(3);
            Assert.AreEqual(2, tree.root.Value);
            Assert.AreEqual(5, tree.root.Right.Value);
            Assert.AreEqual(3, tree.root.Right.Left.Left.Value);
        }

        [Test]
        public void Contains_Test()
        {
            Assert.AreEqual(false, test.Contains(50));
            Assert.AreEqual(false, test.Contains(-50));
            Assert.AreEqual(true, test.Contains(1));
            Assert.AreEqual(true, test.Contains(2));
            Assert.AreEqual(true, test.Contains(3));
            Assert.AreEqual(true, test.Contains(0));
            Assert.AreEqual(true, test.Contains(-5));
            Assert.AreEqual(true, test.Contains(10));
            Assert.AreEqual(true, test.Contains(6));
            Assert.AreEqual(true, test.Contains(5));
            Assert.AreEqual(false, test.Contains(20));
            Assert.AreEqual(false, test.Contains(-20));
        }

        [Test]
        public void Delete_Test() 
        {
            AssertDeletedNode(2, true);
            AssertDeletedNode(5, true);
            AssertDeletedNode(200, false);
            AssertDeletedNode(1, true);
            AssertDeletedNode(2, false);
            AssertDeletedNode(10, true);
            AssertDeletedNode(6, true);
            AssertDeletedNode(0, true);
            AssertDeletedNode(3, true);
            AssertDeletedNode(-5, true);
            AssertDeletedNode(0, false);
            AssertDeletedNode(4, true);
            Assert.AreEqual(true, test.root == null);
        }

        [Test]
        public void Height_Test()
        {
            Assert.AreEqual(6, test.Height());
        }

        private void AssertDeletedNode(int value, bool exists) 
        {
            Assert.AreEqual(exists, test.Contains(value));
            Assert.AreEqual(exists, test.Delete(value));
            Assert.AreEqual(false, test.Contains(value));
        }

        [Test]
        public void FindLowerNode_Test() 
        {
            Assert.AreEqual(-5, test.FindLowerNode().Value);
        }

        [Test]
        public void FindHigherNode_Test()
        {
            Assert.AreEqual(10, test.FindHigherNode().Value);
        }

        [Test]
        public void PreOrderTransversal_Test()
        {
            List<int> listPreOrder = new List<int>() { 1, 0, -5, 2, 4, 3, 10, 6, 5 };
            List<int> result = test.PreOrderTransversal();
            Assert.AreEqual(listPreOrder, result);
        }

        [Test]
        public void InOrderTransversal_Test()
        {
            List<int> listInOrder = new List<int>() { -5, 0, 1, 2, 3, 4, 5, 6, 10 };
            List<int> result = test.InOrderTransversal();
            Assert.AreEqual(listInOrder, result);
        }

        [Test]
        public void PostOrderTransversal_Test() 
        {
            List<int> listPostOrder = new List<int>() { -5, 0, 3, 5, 6, 10, 4, 2, 1 };
            List<int> result = test.PostOrderTransversal();
            Assert.AreEqual(listPostOrder, result);
        }

    }
}