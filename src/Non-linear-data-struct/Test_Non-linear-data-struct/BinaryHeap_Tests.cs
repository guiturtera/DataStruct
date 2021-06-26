using System;
using System.Collections.Generic;
using System.Text;
using Non_linear_data_struct;
using NUnit.Framework;

namespace Test_Non_linear_data_struct
{
    [TestFixture]
    class BinaryHeapTests
    {
        [Test]
        public void Insert_Test()
        {
            int expectedCount = 8;

            List<int> expectedData = new List<int> { 72, 54, 63, 27, 36, 45, 61, 18 };
            //45, 36, 54, 27, 63, 72, 61, and 18.
            BinaryHeap maxheap = new BinaryHeap(HeapType.Max);
            maxheap.Insert(45).Insert(36).Insert(54).Insert(27).Insert(63).Insert(72).Insert(61).Insert(18);
            Assert.AreEqual(expectedData, maxheap.data);
            Assert.AreEqual(expectedCount, maxheap.Count);

            expectedData = new List<int> { 18, 27, 54, 36, 63, 72, 61, 45 };
            BinaryHeap minheap = new BinaryHeap(HeapType.Min);
            minheap.Insert(45).Insert(36).Insert(54).Insert(27).Insert(63).Insert(72).Insert(61).Insert(18);
            Assert.AreEqual(expectedData, minheap.data);
            Assert.AreEqual(expectedCount, minheap.Count);
        }

        [Test]
        public void Delete_Test()
        {
            int expectedCount = 7;

            List<int> expectedData = new List<int> { 45, 29, 36, 27, 11, 18, 21 };
            //45, 36, 54, 27, 63, 72, 61, and 18.
            BinaryHeap maxheap = new BinaryHeap(HeapType.Max);
            maxheap.data = new List<int> { 54, 45, 36, 27, 29, 18, 21, 11 };
            maxheap.Delete();

            Assert.AreEqual(expectedData, maxheap.data);
            Assert.AreEqual(expectedCount, maxheap.Count);
        }

        [Test]
        public void SwitchValues()
        {
            BinaryHeap heap = new BinaryHeap(HeapType.Min);
            heap.data = new List<int> { 1, 2, 3, 4 };
            List<int> expected = new List<int> { 3, 4, 1, 2 };
            heap.SwitchValues(0, 2);
            heap.SwitchValues(1, 3);
            Assert.AreEqual(expected, heap.data);
        }
    }
}
