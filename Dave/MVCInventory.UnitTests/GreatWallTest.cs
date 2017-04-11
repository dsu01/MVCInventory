using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCInventory.Testables;

namespace MVCInventory.UnitTests
{
    [TestClass]
    public class GreatWallTest
    {
        private Dictionary<Type, object> _mocks = new Dictionary<Type, object>();

        protected Mock<T> InitMock<T>() where T : class
        {
            var mock = new Mock<T>();
            _mocks[typeof(T)] = mock;

            return mock;
        }

        protected Mock<T> GetMock<T>() where T : class
        {
            return (Mock<T>)_mocks[typeof(T)];
        }

        [TestInitialize]
        public void InitDependencies()
        {
            var service = this.InitMock<IGreatWallService>();

            service.Setup(x => x.MyIntProperty).Returns(1);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var cut = new GreatWallClass(GetMock<IGreatWallService>().Object);

            var result = cut.GetMyIntProperty();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var service = GetMock<IGreatWallService>();

            var cut = new GreatWallClass(service.Object);

            cut.Setup();

            service.Verify(s => s.Init(), Times.Once);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var service = GetMock<IGreatWallService>();

            var cut = new GreatWallClass(service.Object);

            cut.Process();

            service.Verify(s => s.Process(10), Times.Once);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var service = GetMock<IGreatWallService>();

            var cut = new GreatWallClass(service.Object);

            cut.Process();

            service.Verify(s => s.Process(It.IsNotIn<int>(10)), Times.Never);
        }
    }
}
