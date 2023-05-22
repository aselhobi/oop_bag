using MyBag;
namespace BagTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInsert()
        {
            Bag bag1 = new Bag();
            bag1.insertElement(1); 
            bag1.insertElement(2);
            bag1.insertElement(2);

            Assert.AreEqual(2,bag1.Elements.Count);
            Assert.AreEqual(2,bag1.returnFreq(2)); 
            
            Bag bag2 = new Bag();   
            Assert.AreEqual (0,bag2.Elements.Count); 

            List<int> list = new List<int>() { 1,2,3,4,5 };
            Bag bag3 = new Bag(list);
            Assert.AreEqual(5,bag3.Elements.Count);

            List<int> list2 = new List<int>() { 0, 0,0};
            Bag bag4 = new Bag(list2);
            Assert.AreEqual(1, bag4.Elements.Count);
            Assert.AreEqual(3, bag4.returnFreq(0));


        }
        [TestMethod]

        public void TestRemove()
        {
            
            List<int> list = new List<int>() { 1, 2, 2, 5, 3, 4, 5 };
            Bag bag1 = new Bag(list);
            bag1.removeElement(1);
            Assert.AreEqual(4, bag1.Elements.Count);
            bag1.removeElement(2);
            Assert.AreEqual(1, bag1.returnFreq(2));

            Bag bag2 = new Bag();
            try
            {
                bag2.removeElement(1);
                Assert.Fail();
            }
            catch ( Exception c ){
            Assert.IsTrue( c is Bag.EmptyBagException);
            }
           
            try
            {
                bag1.removeElement(10);
                Assert.Fail();
            }
            catch (Exception c)
            {
                Assert.IsTrue(c is Bag.IncorrectInputException);
            }

        }

        [TestMethod]
        public void TestReturnFreq()
        {
            List<int> list = new List<int>() { 1, 2, 2, 5, 3, 4, 5 };
            Bag bag1 = new Bag(list);
            Assert.AreEqual(2, bag1.returnFreq(2));
            Bag bag2 = new Bag();

            try
            {
                bag1.returnFreq(10);
                Assert.Fail();
            }
            catch (Exception c)
            {
                Assert.IsTrue(c is Bag.IncorrectInputException);
            }
            try
            {
                bag2.returnFreq(1);
                Assert.Fail();
            }
            catch (Exception c)
            {
                Assert.IsTrue(c is Bag.EmptyBagException);

            }
        }

        [TestMethod]
        public void TestMaxElem()
        {
            List<int> list = new List<int>() { 1, 2, 2, 5, 3, 4, 5 };
            Bag bag1 = new Bag(list);
            Assert.AreEqual(5, bag1.maxElem());

            bag1.removeElement(5);
            bag1.removeElement(5);

            Assert.AreEqual(4, bag1.maxElem());

            Bag bag2 = new Bag();
            try
            {
                bag2.maxElem();
                Assert.Fail();
            }
            catch(Exception c) {
                Assert.IsTrue(c is Bag.EmptyBagException);
            }

        }
        [TestMethod]
        public void TestGetIndex()
        {
            List<int> list = new List<int>() { 1, 2, 2, 5, 3, 4, 5 };
            Bag bag1 = new Bag(list);
            Assert.AreEqual(0, bag1.getIndex(1));
        }

        [TestMethod]
        public void TestContains()
        {
            List<int> list = new List<int>() { 1, 2, 2, 5, 3, 4, 5 };
            Bag bag1 = new Bag(list);

            Assert.AreEqual(true, bag1.Contains(1));
            Assert.AreEqual(false, bag1.Contains(7));
        }





    }
}