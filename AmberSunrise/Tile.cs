using Microsoft.Xna.Framework;
using MonoDragons.Core.Entities;
using MonoDragons.Core.PhysicsEngine;

namespace AmberSunrise
{
    public static class Tile
    {
        public static int Height => 96;
        public static Size2 Size => new Size2(96, 96);

        public static Vector2 Position(int tileX, int tileY)
        {
            return new Vector2(tileX * 96, tileY * 96);
        }

        public static void CreateSpriteTile(string sprite, int xPos, int yPos, int zIndex)
        {
            Entity.Create()
                .Add(new Spatial2(new Transform2(Position(xPos, yPos), Rotation2.Default, Size, 1.0f, zIndex)))
                .Add(new Sprite("Map/", sprite));
        }

        public static void CreateBlockingTile(string sprite, int xPos, int yPos, int zIndex)
        {
            var t = new Transform2(Position(xPos, yPos), Rotation2.Default, Size, 1.0f, zIndex);
            Entity.Create()
                .Add(new Spatial2(t))
                .Add(new BoxCollider(t))
                .Add(new Sprite("Map/", sprite));
        }
    }
}
