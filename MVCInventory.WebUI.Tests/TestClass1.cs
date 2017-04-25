using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCInventory.Domain;
namespace MVCInventory.WebUI.Tests
{
    [TestClass]
    public class TestClass1
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
            return (Mock<T>) _mocks[typeof(T)];
        }

        [TestInitialize]
        public void InitDependencies()
        {
            var service = this.InitMock<IWangService>();
            service.Setup(x => x.MyIntProperty).Returns(1);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var testTargetClass = new ForTestClass(GetMock<IWangService>().Object);
            var testres = testTargetClass.GetMyIntProperty();
            Assert.IsTrue(testres == 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var service = GetMock<IWangService>();
            var testTargetClass = new ForTestClass(service.Object);
            testTargetClass.Setup();
            service.Verify(s => s.Init(), Times.Once);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var service = GetMock<IWangService>();
            var testTargetClass = new ForTestClass(service.Object);
            testTargetClass.SetupTwice();
            service.Verify(s => s.Init(), Times.AtLeastOnce);
        }
        [TestMethod]
        public void TestMethod4()
        {
            var service = GetMock<IWangService>();
            var testTargetClass = new ForTestClass(service.Object);
            testTargetClass.Process();
            service.Verify(s => s.Process(It.IsNotIn<int>(10)), Times.Never);
        }

    }
}
