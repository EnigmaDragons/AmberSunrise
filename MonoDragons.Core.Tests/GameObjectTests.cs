using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonoDragons.Core.Entities;

namespace MonoDragons.Core.Tests
{
    [TestClass]
    public class GameObjectTests
    {
        private GameObjects _objs;
        private GameObject _obj;

        [TestInitialize]
        public void Init()
        {
            _objs = new GameObjects();
            _obj = _objs.Create();
        }

        [TestMethod]
        public void GameObject_Create_GameObjectReturned()
        {
            Assert.IsNotNull(_obj);
        }

        [TestMethod]
        public void GameObject_HashCode_MatchesId()
        {
            Assert.AreEqual(_obj.Id, _obj.GetHashCode());
        }

        [TestMethod]
        public void GameObject_TwoObjects_DifferentIds()
        {
            Assert.AreNotEqual(_obj.Id, _objs.Create().Id);
        }

        [TestMethod]
        public void GameObject_AddComponent_HasComponent()
        {
            var component = new FakeComponent();
            _obj.Add(component);

            var result = _obj.Get<FakeComponent>();

            Assert.AreEqual(component, result.Value);
        }

        [TestMethod]
        public void GameObject_AddSameTypeOfComponentTwice_Throws()
        {
            _obj.Add(new FakeComponent());

            ExceptionAssert.Throws(() => _obj.Add(new FakeComponent()));
        }

        private class FakeComponent
        {
        }
    }
}
