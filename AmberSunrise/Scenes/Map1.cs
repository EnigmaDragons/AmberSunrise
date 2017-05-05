using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Entities;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Render;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Characters;

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
            var player = Entity.Create()
                .Add(new Sprite("Map/tile1"))
                .Add(new Spatial2(new Transform2(new Vector2(96, 96), new Size2(192, 192))))
                .Add(new Motion2(new Velocity2() { Direction = Rotation2.Right, Speed = 0f }))
                .Add(e => new Controls(new Map<Control, Action> { { Control.A, () => e.With<Motion2>(x => x.Velocity.Speed = 1f) } }));
                //.Add(new Controllable((x) => player.Get<Motion2>().Value.Velocity.Direction = x.ToRotation()));
            
            Input.OnDirection(x => player.Get<Motion2>().Value.Velocity.Direction = x.ToRotation());

        }

        public void Update(TimeSpan delta) { }
        public void Draw() { }
    }
}
