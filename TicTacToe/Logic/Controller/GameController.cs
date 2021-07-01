using System;
using Logic.Extensions;
using Logic.Interface;
using Logic.Model;

namespace Logic.Controller
{
    public class GameController : IGameController
    {
        private readonly IGameIdGenerator _gameIdGenerator;
        private readonly IStartingPlayerController _startingPlayerController;
        private readonly IGameStateController _gameStateController;
        private readonly IWaitForOpponentController _waitForOpponentController;
        internal Game Game { get; private set; }
        internal PlayerViewModel Me { get; private set; }
        internal PlayerViewModel Opponent { get; private set; }
        public event Action<PlayerViewModel> WhoYouAreIdentified;
        public event Action<NextPlayersTurnEventArgs> NextPlayersTurn;
        public event Action<GameEndedEventArgs> GameEnded;

        public GameController(
            IGameIdGenerator gameIdGenerator,
            IStartingPlayerController startingPlayerController,
            IGameStateController gameStateController,
            IWaitForOpponentController waitForOpponentController)
        {
            _gameIdGenerator = gameIdGenerator;
            _startingPlayerController = startingPlayerController;
            _gameStateController = gameStateController;
            _waitForOpponentController = waitForOpponentController;
            _waitForOpponentController.MyTurn += MyTurn;
        }

        public int HostGame()
        {
            _gameStateController.InitializeHostGameLogic(); //Allow gamestate controller to be ready to host a new game
            var gameId = _gameIdGenerator.GetUniqueGameId(_gameStateController.GetUsedGameIds());
            var startingPlayer = _startingPlayerController.GetRandomStartingPlayer();
            Game = Game.CreateNewGame(startingPlayer, gameId);
            Me = new PlayerViewModel(Player.HostingPlayer, Game.StartingPlayer); //Create representation on who player (Me) are
            Opponent = new PlayerViewModel(Player.JoiningPlayer, Game.StartingPlayer); //Create representation on who opponent are
            _waitForOpponentController.Initialize(gameId, Me); //Tell waitForOpponentController who "Me" are and what the gameId are (so it know what game to look for and if it is 'Me's turn)
            _gameStateController.SaveGameState(Opponent.Player, Game);
            OnWhoYouAreIdentified(Me);
            OnNextPlayer();
            return Game.Id;
        }

        public void JoinGame(int gameId)
        {
            _gameStateController.InitializeJoinGameLogic();
            var game = _gameStateController.GetGame(gameId);
            Game = game ?? throw new NullReferenceException($"Game with id '{gameId}' was not found");
            Me = new PlayerViewModel(Player.JoiningPlayer, Game.StartingPlayer); //Create representation on who player (Me) are
            Opponent = new PlayerViewModel(Player.HostingPlayer, Game.StartingPlayer); //Create representation on who opponent are
            _waitForOpponentController.Initialize(gameId, Me); //Tell waitForOpponentController who "Me" are and what the gameId are (so it know what game to look for and if it is 'Me's turn)
            OnWhoYouAreIdentified(Me);
            OnNextPlayer();
        }

        public void MakeMove(int row, int column)
        {
            Game.Board[row, column] = Game.NextPlayer;
            Game.NextPlayer = Game.NextPlayer == Player.HostingPlayer ? Player.JoiningPlayer : Player.HostingPlayer;
            _gameStateController.SaveGameState(Game.NextPlayer, Game);
            DetermineCurrentGameStatus();
        }

        private void MyTurn(Game game)
        {
            if (game == null || Me.Player == Game.NextPlayer)
            {
                return;
            }
            Game = game;
            DetermineCurrentGameStatus();
        }

        private void DetermineCurrentGameStatus()
        {
            var winner = Game.GetWinner(); //Check if there is a winner
            if (winner != Player.None)
            {
                //There was a winner
                OnGameEnded(winner);
            }
            else if (Game.NoMoreMovesLeft()) //Check if there are anymore moves left
            {
                //Game end with no winner
                OnGameEnded(Player.None);
            }
            else
            {
                //Game is over so inform who is next player
                OnNextPlayer();
            }
        }

        private void OnWhoYouAreIdentified(PlayerViewModel playerViewModel)
        {
            WhoYouAreIdentified?.Invoke(playerViewModel);
        }

        public bool IsItMyTurn()
        {
            return Game.NextPlayer == Me.Player;
        }

        private void OnNextPlayer()
        {
            var nextPlayer = new PlayerViewModel(Game.NextPlayer, Game.StartingPlayer);
            var nextPlayersTurnEventArgs = new NextPlayersTurnEventArgs(nextPlayer, Game.Board.GetVisualBoard(Me, Opponent));
            NextPlayersTurn?.Invoke(nextPlayersTurnEventArgs);
        }

        private void OnGameEnded(Player winner)
        {
            GameEndedEventArgs eventArgs;
            if (winner == Player.None)
            {
                eventArgs = new GameEndedEventArgs(null, "Tie (No winner)", Game.Board.GetVisualBoard(Me, Opponent));
            }
            else if (winner == Me.Player)
            {
                eventArgs = new GameEndedEventArgs(Me, "You Won!", Game.Board.GetVisualBoard(Me, Opponent));
            }
            else
            {
                eventArgs = new GameEndedEventArgs(Opponent, "You Lost!", Game.Board.GetVisualBoard(Me, Opponent));
            }
            GameEnded?.Invoke(eventArgs);
        }
    }
}