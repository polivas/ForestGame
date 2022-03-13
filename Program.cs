using System;

namespace ForestGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new ForestGame())
                game.Run();
        }
    }
}
