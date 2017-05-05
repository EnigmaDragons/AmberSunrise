using Microsoft.Xna.Framework;
using MonoDragons.Core.Entities;
using MonoDragons.Core.PhysicsEngine;

namespace AmberSunrise
{
    public static class Tile
    {
        public static int Length => 96;
        public static Size2 Size => new Size2(Length, Length);

        public static Vector2 Position(int tileX, int tileY)
        {
            return new Vector2(tileX * Length, tileY * Length);
        }

        public static void CreateSpriteTile(string sprite, int xPos, int yPos, int zIndex)
        {
            Entity.Create()
                .Add(new Spatial2(new Transform2(Position(xPos, yPos), Rotation2.Default, Size, 1.0f, zIndex)))
                .Add(new Sprite("Map/", sprite));
        }
    }
}
