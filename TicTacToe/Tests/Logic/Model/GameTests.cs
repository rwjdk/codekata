using Logic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Logic.Model
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void CreateNewGame()
        {
            var game = Game.CreateNewGame(Player.HostingPlayer, 1234);
            Assert.AreEqual(Player.HostingPlayer, game.StartingPlayer);
            Assert.AreEqual(Player.HostingPlayer, game.NextPlayer);
            Assert.AreEqual(1234, game.Id);
            Assert.AreEqual(3, game.Board.GetLength(0));
            Assert.AreEqual(3, game.Board.GetLength(1));
        }

        [TestMethod]
        public void NoWinner1()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.None, Player.None, Player.None  },
                {Player.None, Player.None, Player.None  },
                {Player.None, Player.None, Player.None  }
            });

            Assert.AreEqual(Player.None, game.GetWinner());
        }

        [TestMethod]
        public void NoWinner2()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.HostingPlayer, Player.None, Player.None  },
                {Player.None, Player.None, Player.None  },
                {Player.None, Player.None, Player.None  }
            });

            Assert.AreEqual(Player.None, game.GetWinner());
        }

        [TestMethod]
        public void NoWinner3()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.None, Player.None, Player.None  },
                {Player.None, Player.HostingPlayer, Player.None  },
                {Player.None, Player.None, Player.None  }
            });

            Assert.AreEqual(Player.None, game.GetWinner());
        }

        [TestMethod]
        public void NoWinner4()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.None, Player.None, Player.None  },
                {Player.None, Player.None, Player.None  },
                {Player.None, Player.None, Player.HostingPlayer }
            });

            Assert.AreEqual(Player.None, game.GetWinner());
        }

        [TestMethod]
        public void NoWinner5()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.HostingPlayer, Player.JoiningPlayer, Player.HostingPlayer  },
                {Player.None, Player.None, Player.None  },
                {Player.None, Player.None, Player.None }
            });

            Assert.AreEqual(Player.None, game.GetWinner());
        }

        [TestMethod]
        public void NoWinner6()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.None, Player.JoiningPlayer, Player.None  },
                {Player.None, Player.HostingPlayer, Player.None  },
                {Player.None, Player.JoiningPlayer, Player.None }
            });

            Assert.AreEqual(Player.None, game.GetWinner());
        }

        [TestMethod]
        public void WinnerRow1()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.HostingPlayer, Player.HostingPlayer, Player.HostingPlayer  },
                {Player.None, Player.None, Player.None  },
                {Player.None, Player.None, Player.HostingPlayer }
            });

            Assert.AreEqual(Player.HostingPlayer, game.GetWinner());
        }

        [TestMethod]
        public void WinnerRow2()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.None, Player.None, Player.None  },
                {Player.HostingPlayer, Player.HostingPlayer, Player.HostingPlayer  },
                {Player.None, Player.None, Player.HostingPlayer }
            });
            Assert.AreEqual(Player.HostingPlayer, game.GetWinner());
        }

        [TestMethod]
        public void WinnerRow3()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.None, Player.None, Player.None  },
                {Player.None, Player.None, Player.HostingPlayer },
                {Player.HostingPlayer, Player.HostingPlayer, Player.HostingPlayer  },
            });
            Assert.AreEqual(Player.HostingPlayer, game.GetWinner());
        }

        [TestMethod]
        public void WinnerCol1()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.JoiningPlayer, Player.None, Player.None  },
                {Player.JoiningPlayer, Player.None, Player.None  },
                {Player.JoiningPlayer, Player.None, Player.None }
            });

            Assert.AreEqual(Player.JoiningPlayer, game.GetWinner());
        }

        [TestMethod]
        public void WinnerCol2()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.None, Player.JoiningPlayer, Player.None  },
                {Player.None, Player.JoiningPlayer, Player.None  },
                {Player.None, Player.JoiningPlayer, Player.None }
            });
            Assert.AreEqual(Player.JoiningPlayer, game.GetWinner());
        }

        [TestMethod]
        public void WinnerCol3()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.None, Player.None, Player.JoiningPlayer  },
                {Player.None, Player.None, Player.JoiningPlayer },
                {Player.None, Player.None, Player.JoiningPlayer  },
            });
            Assert.AreEqual(Player.JoiningPlayer, game.GetWinner());
        }

        [TestMethod]
        public void WinnerCross1()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.HostingPlayer, Player.None, Player.None  },
                {Player.None, Player.HostingPlayer, Player.None },
                {Player.None, Player.None, Player.HostingPlayer  },
            });
            Assert.AreEqual(Player.HostingPlayer, game.GetWinner());
        }

        [TestMethod]
        public void WinnerCross2()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.None, Player.None, Player.JoiningPlayer  },
                {Player.None, Player.JoiningPlayer, Player.None },
                {Player.JoiningPlayer, Player.None, Player.None  },
            });
            Assert.AreEqual(Player.JoiningPlayer, game.GetWinner());
        }

        [TestMethod]
        public void MovesLeft()
        {
            var game = new Game(Player.None, Player.None, 0, new[,]
            {
                {Player.None, Player.None, Player.None  },
                {Player.None, Player.None, Player.None },
                {Player.None, Player.None, Player.None  },
            });

            Player player = Player.HostingPlayer;
            for (int row = 0; row < game.Board.GetLength(0); row++)
            {
                for (int column = 0; column < game.Board.GetLength(1); column++)
                {
                    Assert.AreEqual(false, game.NoMoreMovesLeft());

                    if (player == Player.HostingPlayer)
                    {
                        game.Board[row, column] = Player.HostingPlayer;
                        player = Player.JoiningPlayer;
                    }
                    else
                    {
                        game.Board[row, column] = Player.JoiningPlayer;
                        player = Player.HostingPlayer;
                    }
                }
            }
            Assert.AreEqual(true, game.NoMoreMovesLeft());
        }
    }
}