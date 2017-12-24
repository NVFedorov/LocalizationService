using LocalizationService.Tests.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizationService.Tests
{
    [TestFixture]
    public class LocalizationServiceTest
    {
        private LocalizationFactory factory;
        private CultureInfo ruCulture, enCulture, deCulture;

        [SetUp]
        public void TestSetUp()
        {
            this.factory = LocalizationFactory.GetInstance();
            this.factory.Register<DataSourceMock>();
            this.factory.Register(new DataBaseMock());
            this.ruCulture = new CultureInfo("ru-RU");
            this.enCulture = new CultureInfo("en-US");
            this.deCulture = new CultureInfo("de-DE");
        }

        [Test]
        public void TestGetString()
        {
            Assert.AreEqual("DataSourceMock_value1", this.factory.GetString("key1", this.enCulture));
            Assert.AreEqual("DataSourceMock_wert1", this.factory.GetString("key1", this.deCulture));
            Assert.AreEqual("DataSourceMock_значение4", this.factory.GetString("key4", this.ruCulture));
            
            Assert.AreEqual("DataBaseMock_value1", this.factory.GetString("DataBaseMock_key1", this.enCulture));
            Assert.AreEqual("DataBaseMock_значение1", this.factory.GetString("DataBaseMock_key1", this.ruCulture));

            Assert.AreEqual("DataBaseMock_wert1", this.factory.GetString("key1", this.deCulture));
            
            // значения немецкой локализации разные из-за последней использованной культуры
            Assert.AreEqual("DataSourceMock_значение1", this.factory.GetString("key1", this.ruCulture));
            Assert.AreNotEqual("DataBaseMock_wert1", this.factory.GetString("key1", this.deCulture));
        }
    }
}
