﻿using System;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Characters;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Entities;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Render;
using MonoDragons.Core.Inputs;

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

            Enumerable.Range(0, 10).ForEach(x =>
                Tile.CreateBlockingTile("box", Rng.Int(10), Rng.Int(10), 1));

            Entity.Create()
                .Add(new Spatial2(new Transform2(Tile.Position(3, 3), Rotation2.Default, Tile.Size, 1.0f, 1)))
                .Add(new Sprite("Enemy/", "mushroom1"));

            // @todo #1 Add character direction sprites
            // @todo #1 Add repeating sprite animation
            var t = new Transform2(new Vector2(480, 480), Tile.Size);
            var player = Entity.Create()
                .Add(new Sprite("Character/", "fd1"))
                .Add(new Spatial2(t))
                .Add(new Motion2(new Velocity2() { Direction = Rotation2.Right, Speed = 0f }))
                .Add(new BoxCollider(t))
                .Add(new Health(20))
                .Add(e => new Directable( d => e.With<Motion2>( x =>
                {
                    x.Velocity.Speed = d.HDir == HorizontalDirection.None && d.VDir == VerticalDirection.None ? 0f : 4f / 1000 * Tile.Length;
                    x.Velocity.Direction = d.ToRotation();
                })));

            Entity.Create()
                .Add(new Spatial2(new Transform2(new Vector2(0, 20), new Size2(1000, 50))))
                .Add(new TextDisplay { Color = Color.Black, Text = () => $"HP: {player.Get<Health>().HP}/{player.Get<Health>().Max}" });
        }

        public void Update(TimeSpan delta) { }
        public void Draw() { }
    }
}
