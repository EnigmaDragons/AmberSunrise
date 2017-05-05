using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Entities;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Render;

namespace AmberSunrise.Scenes
{
    public class Map1 : IScene
    {
        public void Init()
        {
            Entity.Create()
                .Add(new ScreenBackgroundColor { Color = Color.Black });
            for (var x = 0; x < 960; x += 96)
                for (var y = 0; y < 960; y += 96)
                    Entity.Create()
                        .Add(new Spatial2(new Transform2(new Vector2(x, y), new Size2(96, 96))))
                        .Add(new Sprite("Map/tile1"));

        }

        public void Update(TimeSpan delta) { }
        public void Draw() { }
    }
}
