using System;
using System.Collections.Generic;
using AmberSunrise.Scenes;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.EngimaDragons;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Render;

namespace AmberSunrise
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MainGame("Amber Sunrise", "Map1", new Display(640, 640, false, 0.66666f), CreateSceneFactory(), CreateController()))
                game.Run();
        }

        private static IController CreateController()
        {
            return new KeyboardController(new Map<Keys, Control>());
        }

        private static SceneFactory CreateSceneFactory()
        {
            return new SceneFactory(
                new Dictionary<string, Func<IScene>>
                {
                    { "Logo", () => new LogoScene() },
                    { "Map1", () => new Map1() },
                });
        }
    }
#endif
}
