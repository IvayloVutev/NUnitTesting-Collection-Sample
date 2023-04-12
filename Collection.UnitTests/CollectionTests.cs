using Collection;
using NUnit.Framework.Constraints;

namespace Collection.UnitTests
{
    public class CollectionTests
    {


        [Test]
        public void Test_Collection_EmptyConstructor()
        {

            var coll = new Collection<int>();
            var actual = coll.ToString();
            var expected = "[]";

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {

            var coll = new Collection<int>(5);
            var actual = coll.ToString();
            var expected = "[5]";

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {

            var coll = new Collection<int>(5, 6, 7);
            var actual = coll.ToString();
            var expected = "[5, 6, 7]";

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test_Collection_Add()
        {

            var coll = new Collection<string>("Pesho", "Gosho");
            coll.Add("Miro");
            var actual = coll.ToString();
            var expected = "[Pesho, Gosho, Miro]";

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            // Arrange
            var coll = new Collection<int>();

            // Act
            coll.AddRange(1, 2, 3);

            // Assert
            Assert.That(coll.Count, Is.EqualTo(3));

        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var nums = new Collection<int>(1, 2, 3, 4);
            int oldCapacity = nums.Capacity;
            var num = 2000;
            nums.Add(num);
            string expectedNums = "[1, 2, 3, 4, 2000]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Misho");

            // Act
            var actual = coll[0].ToString();

            var expected = "Pesho";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Misho");
            
            Assert.That(() => { var name = coll[-1]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { var name = coll[3]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Misho");

            // Act
            coll[0] = "Miro";
            coll[1] = "Ivo";
            var actual = coll.ToString();

            var expected = "[Miro, Ivo, Misho]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Misho");

            // Act
            coll.InsertAt(0, "Rado");
            var actual = coll.ToString();

            var expected = "[Rado, Pesho, Gosho, Misho]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Misho");

            // Act
            coll.InsertAt(coll.Count, "Rado");
            var actual = coll.ToString();

            var expected = "[Pesho, Gosho, Misho, Rado]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Misho","Rado");

            // Act
            coll.InsertAt(coll.Count/2, "Viktor");
            var actual = coll.ToString();

            var expected = "[Pesho, Gosho, Viktor, Misho, Rado]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            var nums = new Collection<int>(1, 2, 3, 4);
            int oldCapacity = nums.Capacity;
            var num = 2000;
            nums.InsertAt(0, num);
            string expectedNums = "[2000, 1, 2, 3, 4]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Misho", "Rado");

            // Act
            coll.Exchange(coll.Count / 2, 1);
            var actual = coll.ToString();

            var expected = "[Pesho, Misho, Gosho, Rado]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Misho", "Rado");

            // Act
            coll.Exchange(0, coll.Count-1);
            var actual = coll.ToString();

            var expected = "[Rado, Gosho, Misho, Pesho]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Misho", "Rado");

            // Act
            coll.RemoveAt(0);
            var actual = coll.ToString();

            var expected = "[Gosho, Misho, Rado]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Misho", "Rado");

            // Act
            coll.RemoveAt(coll.Count-1);
            var actual = coll.ToString();

            var expected = "[Pesho, Gosho, Misho]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }
        
        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Martin", "Misho", "Rado");

            // Act
            coll.RemoveAt(coll.Count/2);
            var actual = coll.ToString();

            var expected = "[Pesho, Gosho, Misho, Rado]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_RemoveAll()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Martin", "Misho", "Rado");

            // Act
            coll.Clear();
            var actual = coll.ToString();

            var expected = "[]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho", "Martin", "Misho", "Rado");

            Assert.That(coll.Capacity, Is.GreaterThan(coll.Count));

        }

        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            // Arrange
            var coll = new Collection<string>();

            // Act
           
            var actual = coll.ToString();

            var expected = "[]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_ToStringSingle()
        {
            // Arrange
            var coll = new Collection<string>("Pesho");

            // Act

            var actual = coll.ToString();

            var expected = "[Pesho]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_ToStringMultiple()
        {
            // Arrange
            var coll = new Collection<string>("Pesho", "Gosho");

            // Act

            var actual = coll.ToString();

            var expected = "[Pesho, Gosho]";

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("Teddy", "Gerry");
            var nums = new Collection<int>(10, 20);
            var dates = new Collection<DateTime>();
            var nested = new Collection<object>(names, nums, dates);
            string nestedToString = nested.ToString();
            Assert.That(nestedToString,
              Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));
        }

        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }

    }
}