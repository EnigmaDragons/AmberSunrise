using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonoDragons.Core.Entities;

namespace MonoDragons.Core.Tests
{
    [TestClass]
    public class EntitySystemTests
    {
        private GameObjects _objs;
        private EntitySystem _sys;

        [TestInitialize]
        public void Init()
        {
            _objs = new GameObjects();
            _sys = new EntitySystem(_objs);
        }

        [TestMethod]
        public void EntitySystem_OneEntity_SystemsCalled()
        {
            _objs.Create();
            var spy = new Spy();
            _sys.Register(spy);

            _sys.Update(TimeSpan.FromMilliseconds(1));

            Assert.IsTrue(spy.WasUpdated);
        }

        [TestMethod]
        public void EntitySystem_OneEntity_RendererCalled()
        {
            _objs.Create();
            var renderer = new Renderer();
            _sys.Register(renderer);

            _sys.Draw();

            Assert.IsTrue(renderer.Drew);
        }

        private class Spy : ISystem
        {
            public bool WasUpdated { get; private set; }

            public void Update(IEntities entities, TimeSpan delta)
            {
                WasUpdated = true;
            }
        }

        private class Renderer : IRenderer
        {
            public bool Drew { get; private set; }

            public void Draw(IEntities entities)
            {
                Drew = true;
            }
        }
    }
}
