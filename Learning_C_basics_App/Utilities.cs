using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_C_basics_App
{
    public static partial class Program
    {
        static int[,] GetRandomArray(int rows, int columns)
        {
            Random random = new Random();
            var result = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = random.Next(100);
                }
            }

            return result;
        }

        static List<GameInfo> GetGamesInfo()
        {
            return new List<GameInfo>()
            {
                new GameInfo()
                {
                    TypeOfGame = GameType.RPG,
                    Games = new List<Game>()
                    {
                        new Game() { Name = "Fallout 4" },
                        new Game() { Name = "Gothic 2" },
                        new Game() { Name = "The Elder Scrolls 3: Morrowind" }
                    }
                },
                new GameInfo()
                {
                    TypeOfGame = GameType.Strategy,
                    Games = new List<Game>()
                    {
                        new Game() { Name = "Civilization VI" },
                        new Game() { Name = "Rome: Total War" },
                        new Game() { Name = "Starcraft II" }
                    }
                },
                new GameInfo()
                {
                    TypeOfGame = GameType.Shooter,
                    Games = new List<Game>()
                    {
                        new Game() { Name = "Counter-Strike: Global Offensive" },
                        new Game() { Name = "Battlefield 4" },
                        new Game() { Name = "Doom" }
                    }
                }
            };
        }

        enum GameType
        {
            RPG,
            Strategy,
            Shooter
        }

        class Game
        {
            public string Name { get; set; }
        }

        class GameInfo
        {
            public GameType TypeOfGame { get; set; }

            public List<Game> Games { get; set; } = new List<Game>();
        }
    }
}
