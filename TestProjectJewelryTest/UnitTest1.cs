using Project_partB_Sorokina_program;

namespace TestProjectJewelryTest
{
    [TestClass]
    public class PreciousStoneTests
    {
        [TestMethod]
        public void GetName_ShouldReturnCorrectName()
        {
            // Arrange
            var stone = new PreciousStone("Diamond", 1.0, 1000m, "Clear", 10);

            // Act
            var name = stone.GetName();

            // Assert
            Assert.AreEqual("Diamond", name);
        }


        [TestMethod]
        public void GetWeight_ShouldReturnCorrectWeight()
        {
            // Arrange
            var preciousStone = new PreciousStone("Diamond", 1.0, 1000m, "Clear", 10);

            // Act
            var weight = preciousStone.GetWeight();

            // Assert
            Assert.AreEqual(1.0, weight);
        }

        [TestMethod]
        public void GetValue_ShouldReturnCorrectValue()
        {
            // Arrange
            var preciousStone = new PreciousStone("Diamond", 1.0, 1000m, "Clear", 10);

            // Act
            var value = preciousStone.GetValue();

            // Assert
            Assert.AreEqual(1000m, value);
        }

        [TestMethod]
        public void GetColor_ShouldReturnCorrectColor()
        {
            // Arrange
            var preciousStone = new PreciousStone("Diamond", 1.0, 1000m, "Clear", 10);

            // Act
            var color = preciousStone.GetColor();

            // Assert
            Assert.AreEqual("Clear", color);
        }

        [TestMethod]
        public void GetDetails_ShouldReturnCorrectDetails()
        {
            // Arrange
            var preciousStone = new PreciousStone("Diamond", 1.0, 1000m, "Clear", 10);
            var expectedDetails = "Name: Diamond, Weight: 1.0 ct, Price: $1000, Color: Clear, Clarity: 10";

            // Act
            var details = preciousStone.GetDetails();

            // Assert
            Assert.AreEqual(expectedDetails, details);
        }


    }

    [TestClass]
    public class NecklaceTests
    {

        [TestMethod]
        public void RemoveStone_ShouldRemoveStone()
        {
            // Arrange
            var necklace = new Necklace();
            var stone = new SemiPreciousStone("name1", 9, 9, "green", 9);
            necklace.AddStone(stone);

            // Act
            necklace.RemoveStone(stone);

            // Assert
            // Перевіряємо, що камінь був видалений
            Assert.IsFalse(necklace.Contains(stone));
        }


        [TestMethod]
        public void AddStone_ShouldAddStone()
        {
            // Arrange
            var necklace = new Necklace();
            var stone = new PreciousStone("name1", 9, 9, "green", 9);

            // Act
            necklace.AddStone(stone);

            // Assert
            // Перевіряємо, що камінь був доданий
            Assert.IsTrue(necklace.Contains(stone));
        }



        [TestMethod]
        public void GetTotalValue_ShouldReturnCorrectTotalValue()
        {
            // Arrange
            var necklace = new Necklace();
            var stone1 = new SemiPreciousStone("name1", 9, 9, "green", 9);
            var stone2 = new PreciousStone("name2", 9, 9, "green", 9);
            necklace.AddStone(stone1);
            necklace.AddStone(stone2);
            decimal expectedTotalValue = stone1.GetValue() + stone2.GetValue(); // Очікувана загальна вартість

            // Act
            var totalValue = necklace.GetTotalValue();

            // Assert
            Assert.AreEqual(expectedTotalValue, totalValue); // Перевіряємо, чи загальна вартість вірна
        }


        [TestMethod]
        public void DeleteStone_ShouldRemoveStoneFromNecklace()
        {
            // Arrange
            var necklace = new Necklace();
            var stone = new PreciousStone("name1", 9, 9, "green", 9);
            necklace.AddStone(stone);

            // Act
            Necklace.DeleteStone(necklace, stone);

            // Assert
            Assert.IsFalse(necklace.Contains(stone)); // Перевіряємо, що камінь був видалений з намиста
        }

        [TestMethod]
        public void FindStonesByColor_ShouldReturnStonesOfSpecifiedColor()
        {
            // Arrange
            var necklace = new Necklace();
            var stone1 = new SemiPreciousStone("name1", 9, 9, "green", 9);
            var stone2 = new PreciousStone("name2", 9, 9, "green", 9);
            necklace.AddStone(stone1);
            necklace.AddStone(stone2);

            // Act
            var foundStones = Necklace.FindStonesByColor(necklace, "Синій");

            // Assert
            // Перевіряємо, що повернені камені мають заданий колір 
            Assert.IsTrue(foundStones.Any(stone => stone.GetColor() == "Синій"));
        }


        [TestMethod]
        public void GetTotalWeight_ShouldReturnCorrectTotalWeight()
        {
            // Arrange
            var necklace = new Necklace();
            var stone1 = new SemiPreciousStone("name1", 9, 9, "green", 9);
            var stone2 = new PreciousStone("name2", 9, 9, "green", 9);
            necklace.AddStone(stone1);
            necklace.AddStone(stone2);
            double expectedTotalWeight = 9.0 + 9.0;

            // Act
            var totalWeight = necklace.GetTotalWeight();

            // Assert
            Assert.AreEqual(expectedTotalWeight, totalWeight); // Перевіряємо, чи загальна вага вірна
        }



        [TestMethod]
        public void SortByValue_ShouldSortStonesByValue()
        {
            // Arrange
            var necklace = new Necklace();
            var stone1 = new SemiPreciousStone("name1", 9, 9, "green", 9);
            var stone2 = new PreciousStone("name2", 5, 5, "blue", 15);
            necklace.AddStone(stone1);
            necklace.AddStone(stone2);

            // Act
            necklace.SortByValue();

            // Assert
            var sortedStones = necklace.GetStones();
            Assert.AreEqual(stone2, sortedStones[0]);
            Assert.AreEqual(stone1, sortedStones[1]);
        }




        [TestMethod]
        public void ToString_ShouldReturnCorrectStringRepresentation()
        {
            // Arrange
            var necklace = new Necklace();
            var stone = new SemiPreciousStone("name1", 9, 9, "green", 9);
            necklace.AddStone(stone);

            // Act
            var result = necklace.ToString();

            // Assert
            string expectedString = $"Necklace with stones:\n{stone}\n";

            Assert.AreEqual(expectedString, result);
        }



    }

    [TestClass]
    public class SemiPreciousStoneTests
    {
        [TestMethod]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            string expectedName = "Amethyst";
            double expectedCaratWeight = 2.0;
            decimal expectedPrice = 150m;
            string expectedColor = "Purple";
            int expectedHardness = 7;

            // Act
            SemiPreciousStone semiPreciousStone = new SemiPreciousStone(expectedName, expectedCaratWeight, expectedPrice, expectedColor, expectedHardness);

            // Assert
            Assert.AreEqual(expectedName, semiPreciousStone.Name);
            Assert.AreEqual(expectedCaratWeight, semiPreciousStone.CaratWeight);
            Assert.AreEqual(expectedPrice, semiPreciousStone.Price);
            Assert.AreEqual(expectedColor, semiPreciousStone.Color);
            Assert.AreEqual(expectedHardness, semiPreciousStone.Hardness);
        }

        [TestMethod]
        public void GetName_ShouldReturnCorrectName()
        {
            // Arrange
            SemiPreciousStone stone = new SemiPreciousStone("Amethyst", 2.0, 150m, "Purple", 7);

            // Act
            string name = stone.GetName();

            // Assert
            Assert.AreEqual("Amethyst", name);
        }

        [TestMethod]
        public void GetWeight_ShouldReturnCorrectWeight()
        {
            // Arrange
            SemiPreciousStone stone = new SemiPreciousStone("Amethyst", 2.0, 150m, "Purple", 7);

            // Act
            double weight = stone.GetWeight();

            // Assert
            Assert.AreEqual(2.0, weight);
        }

        [TestMethod]
        public void GetValue_ShouldReturnCorrectValue()
        {
            // Arrange
            SemiPreciousStone stone = new SemiPreciousStone("Amethyst", 2.0, 150m, "Purple", 7);

            // Act
            decimal value = stone.GetValue();

            // Assert
            Assert.AreEqual(150m, value);
        }

        [TestMethod]
        public void GetColor_ShouldReturnCorrectColor()
        {
            // Arrange
            SemiPreciousStone stone = new SemiPreciousStone("Amethyst", 2.0, 150m, "Purple", 7);

            // Act
            string color = stone.GetColor();

            // Assert
            Assert.AreEqual("Purple", color);
        }

        [TestMethod]
        public void GetDetails_ShouldReturnCorrectDetails()
        {
            // Arrange
            SemiPreciousStone stone = new SemiPreciousStone("Amethyst", 2.0, 150m, "Purple", 7);

            // Act
            string details = stone.GetDetails();

            // Assert
            string expectedDetails = $"Name: Amethyst, Weight: 2ct, Price: $150, Color: Purple, Hardness: 7";
            Assert.AreEqual(expectedDetails, details);
        }
    }

}