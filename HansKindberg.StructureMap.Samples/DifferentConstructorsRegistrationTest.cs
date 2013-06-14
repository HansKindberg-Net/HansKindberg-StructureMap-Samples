using System.Diagnostics.CodeAnalysis;
using HansKindberg.StructureMap.Samples.TestTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace HansKindberg.StructureMap.Samples
{
    [TestClass]
    public class DifferentConstructorsRegistrationTest
    {
        #region Methods

        private static void ClearStructureMapRegistrations()
        {
            ObjectFactory.Initialize(registry => { });
        }

        [TestMethod]
        public void RegistrationWithCtorForTheStringParameters_ShouldSucceed()
        {
            ObjectFactory.Initialize(registry =>
            {
                registry.SelectConstructor(() => new DifferentConstructors(default(string), default(string), default(string)));
                registry.For<IDifferentConstructors>()
                        .Use<DifferentConstructors>()
                        .Ctor<string>("firstString").Is("FirstValue")
                        .Ctor<string>("secondString").Is("SecondValue")
                        .Ctor<string>("thirdString").Is("ThirdValue");
            });
            IDifferentConstructors classWithDifferentConstructors = ObjectFactory.GetInstance<IDifferentConstructors>();
            Assert.AreEqual("FirstValue", classWithDifferentConstructors.FirstString);
            Assert.AreEqual("SecondValue", classWithDifferentConstructors.SecondString);
            Assert.AreEqual("ThirdValue", classWithDifferentConstructors.ThirdString);
            Assert.IsNull(classWithDifferentConstructors.FirstInterface);
            Assert.IsNull(classWithDifferentConstructors.SecondInterface);
        }

        [TestMethod]
        public void RegistrationWithoutCtor_ShouldThrowAException__________________()
        {
            ObjectFactory.Initialize(registry =>
            {
                registry.For<IFirstInterface>().Singleton().Use<FirstClass>();
                registry.For<ISecondInterface>().Singleton().Use<SecondClass>();
                registry.SelectConstructor(() => new DifferentConstructors(default(IFirstInterface)));
                registry.For<IDifferentConstructors>().Use<DifferentConstructors>()
                        .Ctor<IFirstInterface>("firstInterface").Is((structureMap) => structureMap.GetInstance<IFirstInterface>());
            });

            IFirstInterface firstInterface = ObjectFactory.GetInstance<IFirstInterface>();
            IDifferentConstructors classWithDifferentConstructors = ObjectFactory.GetInstance<IDifferentConstructors>();
            Assert.AreEqual(firstInterface, classWithDifferentConstructors.FirstInterface);
            Assert.IsNotNull(classWithDifferentConstructors.SecondInterface);
            Assert.IsNull(classWithDifferentConstructors.FirstString);
            Assert.IsNull(classWithDifferentConstructors.SecondString);
            Assert.IsNull(classWithDifferentConstructors.ThirdString);
        }

        //[TestMethod]
        //public void RegistrationWithoutCtor_ShouldThrowAException__________________()
        //{
        //    ObjectFactory.Initialize(registry =>
        //    {
        //        registry.For<IFirstInterface>().Singleton().Use<FirstClass>();
        //        registry.For<ISecondInterface>().Singleton().Use<SecondClass>();
        //        //registry.SelectConstructor((() => new ClassWithDifferentConstructors((IFirstInterface)null, (ISecondInterface)null)));
        //        registry.SelectConstructor((() => new ClassWithDifferentConstructors((IFirstInterface)null)));
        //        registry.For<IDifferentConstructors>().Use<ClassWithDifferentConstructors>()
        //            .Ctor<IFirstInterface>("firstInterface").Is((structureMap) => structureMap.GetInstance<IFirstInterface>());
        //        //.Ctor<ISecondInterface>("secondInterface").Is((structureMap) => structureMap.GetInstance<ISecondInterface>());
        //    });
        //    IFirstInterface firstInterface = ObjectFactory.GetInstance<IFirstInterface>();
        //    IDifferentConstructors classWithDifferentConstructors = ObjectFactory.GetInstance<IDifferentConstructors>();
        //    Assert.AreEqual(firstInterface, classWithDifferentConstructors.FirstInterface);
        //    Assert.IsNotNull(classWithDifferentConstructors.SecondInterface);
        //    Assert.IsNull(classWithDifferentConstructors.FirstString);
        //    Assert.IsNull(classWithDifferentConstructors.SecondString);
        //    Assert.IsNull(classWithDifferentConstructors.ThirdString);
        //}
        [TestMethod]
        [SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "classWithDifferentConstructors")]
        public void RegistrationWithoutCtor_ShouldThrowAStructureMapExceptionBecauseStructureMapWillUseTheConstructorWithTheMostParameters()
        {
            ObjectFactory.Initialize(registry => registry.For<IDifferentConstructors>().Use<DifferentConstructors>());
            IDifferentConstructors classWithDifferentConstructors = ObjectFactory.GetInstance<IDifferentConstructors>();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            // We clear StructureMap on each test-method.
            ClearStructureMapRegistrations();
        }

        #endregion
    }
}