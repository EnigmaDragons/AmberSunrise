using System;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
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
            for (var x = 0; x < 10; x++)
                for (var y = 0; y < 10; y++)
                    Tile.CreateSpriteTile("tile1", x, y, 0);

            // @todo #1 Make Boxes Blocking
            Enumerable.Range(0, 10).ForEach(x => 
                Tile.CreateSpriteTile("box", Rng.Int(10), Rng.Int(10), 1));

            // @todo #1 Add character direction sprites
            // @todo #1 Add repeating sprite animation
            Entity.Create()
                .Add(new Spatial2(480, 480, Tile.Size))
                .Add(new Sprite("Character/", "fd1"));
        }

        public void Update(TimeSpan delta) { }
        public void Draw() { }
    }
}
