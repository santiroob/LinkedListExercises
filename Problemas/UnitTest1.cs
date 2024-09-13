using Problemas;
using System.Collections.Generic;

namespace TestsTarea2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMergeSortedAsc()
        {

            DoublyLinkedList A = new DoublyLinkedList();
            DoublyLinkedList B = new DoublyLinkedList();

            A.InsertInOrder(0);
            A.InsertInOrder(2);
            A.InsertInOrder(6);
            A.InsertInOrder(10);
            A.InsertInOrder(25);

            B.InsertInOrder(3);
            B.InsertInOrder(7);
            B.InsertInOrder(11);
            B.InsertInOrder(40);
            B.InsertInOrder(50);

            Program p = new Program();

            p.MergeSorted(A, B, Program.SortDirection.Ascending);

            Assert.AreEqual(0, A.Head.Data);
            Assert.AreEqual(2, A.Head.Next.Data);
            Assert.AreEqual(40, A.Last.Previous.Data);
            Assert.AreEqual(50, A.Last.Data);

        }


        [TestMethod]

        public void TestMergeSortedDesc()
        {
            DoublyLinkedList A = new DoublyLinkedList();
            DoublyLinkedList B = new DoublyLinkedList();


            A.InsertInOrder(10);
            A.InsertInOrder(15);


            B.InsertInOrder(9);
            B.InsertInOrder(40);
            B.InsertInOrder(50);

            Program p = new Program();

            p.MergeSorted(A, B, Program.SortDirection.Descending);

            Assert.AreEqual(50, A.Head.Data);
            Assert.AreEqual(9, A.Last.Data);



        }

        [TestMethod]

        
        public void TestMergeSortedEmptyA()
        {
            // Crear lista A vacía y lista B con algunos valores
            DoublyLinkedList A = new DoublyLinkedList();
            DoublyLinkedList B = new DoublyLinkedList();

            B.InsertInOrder(9);
            B.InsertInOrder(40);
            B.InsertInOrder(50);

            // Llamar al método MergeSorted en modo descendente
            Program p = new Program();
            p.MergeSorted(A, B, Program.SortDirection.Descending);

            // Verificar que A tenga los valores de B en orden descendente
            Assert.AreEqual(50, A.Head.Data);  // El primer valor debe ser 50
            Assert.AreEqual(9, A.Last.Data);   // El último valor debe ser 9
        }

        [TestMethod]

        public void TestMergeSortedEmptyB()
        {
            DoublyLinkedList A = new DoublyLinkedList();
            DoublyLinkedList B = new DoublyLinkedList();


            A.InsertInOrder(10);
            A.InsertInOrder(15);

            Program p = new Program();

            p.MergeSorted(A, B, Program.SortDirection.Ascending);

            Assert.AreEqual(10, A.Head.Data);
            Assert.AreEqual(15, A.Middle.Data);
            Assert.AreEqual(15, A.Last.Data);



        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMergeSortedNull()
        {
            Program p = new Program();

            p.MergeSorted(null, new DoublyLinkedList(), Program.SortDirection.Ascending);
        }

        [TestMethod]

        public void TestInvertList()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.InsertLast(1);
            list.InsertLast(0);
            list.InsertLast(30);
            list.InsertLast(50);
            list.InsertLast(2);

            Program p = new Program();

            p.InvertList(list);

            Assert.AreEqual(2, list.Head.Data);
            Assert.AreEqual(30, list.Middle.Data);
            Assert.AreEqual(1, list.Last.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]

        public void TestInvertListNull()
        {


            Program p = new Program();

            p.InvertList(null);
        }

        [TestMethod]

        public void TestInvertListEmpty()
        {
            DoublyLinkedList list = new DoublyLinkedList();

            Program p = new Program();

            p.InvertList(list);

            Assert.AreEqual(0, list.Count);

        }

        [TestMethod]

        public void TestInvertListOneElement()
        {
            DoublyLinkedList list = new DoublyLinkedList();

            list.InsertLast(2);

            Program p = new Program();

            p.InvertList(list);

            Assert.AreEqual(2, list.Head.Data);
            Assert.AreEqual(2, list.Head.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]

        public void TestGetMiddleNull()
        {
            Program p = new Program();

            p.GetMiddle(null);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetMiddleEmpty()
        {
            DoublyLinkedList list = new DoublyLinkedList();

            Program p = new Program();

            p.GetMiddle(list);


        }

        [TestMethod]

        public void TestGetMiddleOneElement()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.InsertInOrder(1);

            Program p = new Program();

            Assert.AreEqual(1,p.GetMiddle(list));

        }

        [TestMethod]

        public void TestGetMiddleTwoElements()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.InsertInOrder(1);
            list.InsertInOrder(2);

            Program p = new Program();

            Assert.AreEqual(2, p.GetMiddle(list));

        }

        [TestMethod]

        public void TestGetMiddleThreeElements()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);


            Program p = new Program();

            Assert.AreEqual(2, p.GetMiddle(list));

        }

        public void TestGetMiddleFourElements()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.InsertInOrder(1);
            list.InsertInOrder(2);
            list.InsertInOrder(3);
            list.InsertInOrder(4);


            Program p = new Program();

            Assert.AreEqual(3, p.GetMiddle(list));

        }


    }
}