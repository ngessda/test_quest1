using NUnit.Framework.Internal.Execution;
using System.Reflection;
using Test_quest1;


namespace NUnit_Test_Quest
{
    public class Test_quest
    {
        [Test]
        public void Generate()
        {
            // Arrange
            var pallet = new Pallet(1, 100, 100, 100, 100);
            var box = new Box(1, 50, 90, 60, new DateTime(2023, 1, 1));

            //Act

            pallet.AddBox(box);

            //Assert

            Assert.IsTrue(pallet.Height > box.Height && pallet.Depth > box.Depth && pallet.Width > box.Width);
        }

        [Test]
        public void SortPalletsByDateAndWeight()
        {

            // Arrange
            var pallet1 = new Pallet(new DateTime(2022, 12, 31), 100, 10);
            var pallet2 = new Pallet(new DateTime(2023, 6, 30), 150, 15);
            var pallet3 = new Pallet(new DateTime(2023, 12, 31), 120, 12);
            var pallet4 = new Pallet(new DateTime(2022, 12, 31), 80, 8);
            var pallets = new List<Pallet> { pallet1, pallet2, pallet3, pallet4 };

            //Act

            var sortedPallets = PalletsHelper.SortPalletsByDateAndWeight(pallets);

            //Assert


            Assert.AreEqual(pallet4, sortedPallets[0]);
            Assert.AreEqual(pallet1, sortedPallets[1]);
            Assert.AreEqual(pallet2, sortedPallets[2]);
            Assert.AreEqual(pallet3, sortedPallets[3]);

        }

        [Test]
        public void SortPalletsByDateAndVolume()
        {
            // Arrange
            var pallet1 = new Pallet ( new DateTime(2022, 12, 31), 100, 10 );
            var pallet2 = new Pallet ( new DateTime(2023, 6, 30), 150, 15 );
            var pallet3 = new Pallet ( new DateTime(2023, 12, 31), 120, 12 );
            var pallet4 = new Pallet ( new DateTime(2022, 12, 31), 80, 8 );
            var pallets = new List<Pallet> { pallet1, pallet2, pallet3, pallet4 };

            // Act
            var sortedPallets = PalletsHelper.SortPalletsByDateAndVolume(pallets);

            // Assert
            Assert.AreEqual(pallet4, sortedPallets[0]);
            Assert.AreEqual(pallet1, sortedPallets[1]);
            Assert.AreEqual(pallet2, sortedPallets[2]);
            Assert.AreEqual(pallet3, sortedPallets[3]);
        }
    }
}