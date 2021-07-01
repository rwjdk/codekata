using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Test.Control
{
    [TestClass]
    public class NumberOfSetsControllerTests
    {
        private INumberOfSetsController _numberOfSetsController;

        [TestInitialize]
        public void Initialize()
        {
            _numberOfSetsController = DependencyInjection.Resolve<INumberOfSetsController>();
        }

        [TestMethod]
        public void TestValidValues()
        {
            Assert.AreEqual(3, _numberOfSetsController.ValidNumberOfSets.Count);
            Assert.AreEqual(1, _numberOfSetsController.ValidNumberOfSets[0]);
            Assert.AreEqual(3, _numberOfSetsController.ValidNumberOfSets[1]);
            Assert.AreEqual(5, _numberOfSetsController.ValidNumberOfSets[2]);
        }

        [TestMethod]
        public void TestValidInputs()
        {

            _numberOfSetsController.NumberOfSets = 1;
            Assert.AreEqual(1, _numberOfSetsController.NumberOfSets);

            _numberOfSetsController.NumberOfSets = 3;
            Assert.AreEqual(3, _numberOfSetsController.NumberOfSets);

            _numberOfSetsController.NumberOfSets = 5;
            Assert.AreEqual(5, _numberOfSetsController.NumberOfSets);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfSetsException))]
        public void TestInvalidValidIntergerInput2()
        {
            _numberOfSetsController.NumberOfSets = 2;
            Assert.AreEqual(0, _numberOfSetsController.NumberOfSets);
        }
        
        [TestMethod]
        public void TestNotUsedControllerIsMarkedAsNotDefined()
        {
            Assert.AreEqual(true, _numberOfSetsController.IsNotDefined());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfSetsException))]
        public void TestInvalidValidIntergerInput0()
        {
            _numberOfSetsController.NumberOfSets = 0;
            Assert.AreEqual(0, _numberOfSetsController.NumberOfSets);
            Assert.AreEqual(true, _numberOfSetsController.IsNotDefined());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfSetsException))]
        public void TestInvalidValidIntergerInputMinus1()
        {
            _numberOfSetsController.NumberOfSets = -1;
            Assert.AreEqual(0, _numberOfSetsController.NumberOfSets);
        }
    }
}