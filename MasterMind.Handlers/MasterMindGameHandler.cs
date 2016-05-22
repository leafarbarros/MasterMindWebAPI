using MasterMind.Entity;
using MasterMind.Handlers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers
{
    public class MasterMindGameHandler
    {
        public static GamePool GamePool { get; set; }

        public MasterMindGameHandler()
        {

            GamePool = new GamePool();
        }

        public Game GetGameInfo(string gameName)
        {
            if (!GamePool.Games.Any())
            {
                throw new ThereIsNoGameException();
            }

            Game game = GamePool.Games.FirstOrDefault(g => g.GameName.Equals(gameName));

            if (game != null)
            {
                return game;
            }
            else
            {
                throw new GameNotExistsException();
            }
        }

        public void CreateNewUserIfNotExists(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.UserName))
            {
                throw new ArgumentNullException("The user need a name");
            }

            if (!GamePool.LoggedUsers.Any(u => u.UserName.Equals(user.UserName)))
            {
                GamePool.LoggedUsers.Add(user);
            }
        }

        public void CreateNewGame(string gameName, User firstPlayer, int QtUsers)
        {
            
            if (QtUsers <= 0 || firstPlayer == null || string.IsNullOrEmpty(firstPlayer.UserName))
            {
                throw new ArgumentNullException("To create a new game, we need at least the first player");
            }

            ValidateUserToJoinTheGame(firstPlayer);
            
            Game newGame = new Game(gameName, firstPlayer, QtUsers);
            GamePool.Games.Add(newGame);
        }

        public string GenerateGameName()
        {
            return "G" + (GamePool.Games.Count + 1);
        }

        private void ValidateUserToJoinTheGame(User firstPlayer)
        {
            if (!GamePool.LoggedUsers.Any())
            {
                throw new ThereIsNoUserException();
            }

            if (!GamePool.LoggedUsers.Any(luser => luser.UserName.Equals(firstPlayer.UserName)))
            {
                throw new PlayerNotExistsException();
            }

            if (GamePool.Games.Any(game => game.Status != EnumGameStatus.Finished &&
                                           game.Users.Any(user => user.UserName.Equals(firstPlayer.UserName))
                                 ))
            {
                throw new PlayerAlreadyInAGameException();
            }
        }

        public void JoinGame(string gameName, User anotherPlayer)
        {
            if (!GamePool.Games.Any())
            {
                throw new ThereIsNoGameException();
            }

            Game gameToJoin = GamePool.Games.FirstOrDefault(g => g.GameName.Equals(gameName));
            if (gameToJoin == null){
                throw new GameNotExistsException();
            }

            ValidateUserToJoinTheGame(anotherPlayer);

            if (gameToJoin.Users.Count < gameToJoin.NumberOfMaximumUsers)
            {
                gameToJoin.Users.Add(anotherPlayer);
            }
            else
            {
                throw new GameIsFullException();
            }

        }

        public void StartGameIfTheGameIsFull(string gameName)
        {
            if (!GamePool.Games.Any())
            {
                throw new ThereIsNoGameException();
            }

            Game gameToStart = GamePool.Games.FirstOrDefault(g => g.GameName.Equals(gameName));
            if (gameToStart == null)
            {
                throw new GameNotExistsException();
            }

            if(gameToStart.Users.Count == gameToStart.NumberOfMaximumUsers && gameToStart.Status == EnumGameStatus.WaitingForPlayers)
            {
                this.GenerateCorrectAnswer(gameToStart);
                gameToStart.UserTurnIndex = 0;
                gameToStart.Status = EnumGameStatus.InProgress;
            }

        }

        private void GenerateCorrectAnswer(Game gameToStart)
        {
            GameColor[] combination = new GameColor[gameToStart.NumberOfCorrectColors];
            
            Random rnd = new Random();
            int randomColorIndex = 0;
            for (int i = 0 ; i < gameToStart.NumberOfCorrectColors; i++){
                randomColorIndex = rnd.Next(gameToStart.PossibleColors.Length);
                combination[i] = new GameColor( gameToStart.PossibleColors[randomColorIndex].ColorCode, gameToStart.PossibleColors[randomColorIndex].ColorName);
            }

            gameToStart.CorrectAnswer = combination;
        }

        public EnumFeedback[]  UserGuess(string gameName, User user, string[] gameColorsCodes)
        {
            Game game = ValidateUserGuess(gameName, user, gameColorsCodes);
            game.Turn += 1;

            GameColor[] colorsGuess = MapGameColorsGuessFromGameColorsCodes(gameColorsCodes, game);
            Guess userGuess = new Guess(user, colorsGuess);
            userGuess.FillFeedbackFromCorrectAnwser(game.CorrectAnswer);
            game.Guesses.Add(userGuess);

            if (userGuess.Feedback.All(f => f == EnumFeedback.Correct) || game.Turn == game.QuantityOfMaximumTurns)
            {
                game.Status = EnumGameStatus.Finished;
            }
            else
            {
                game.UserTurnIndex = (game.UserTurnIndex + 1) % game.NumberOfMaximumUsers;

            }
            
            return userGuess.Feedback;

        }

        private static GameColor[] MapGameColorsGuessFromGameColorsCodes(string[] gameColorsCodes, Game game)
        {
            GameColor[] colorsGuess = new GameColor[gameColorsCodes.Length];
            for (int i = 0; i < colorsGuess.Length; i++)
            {
                GameColor possibleColor = game.PossibleColors.First(pc => pc.ColorCode.Equals(gameColorsCodes[i]));
                colorsGuess[i] = new GameColor(possibleColor.ColorCode, possibleColor.ColorName);
            }

            return colorsGuess;
        }

        private Game ValidateUserGuess(string gameName, User user, string[] gameColorsCodes)
        {
            if (string.IsNullOrEmpty(gameName) || user == null || string.IsNullOrEmpty(user.UserName) || gameColorsCodes == null)
            {
                throw new ArgumentNullException();
            }

            if (!GamePool.LoggedUsers.Any())
            {
                throw new ThereIsNoUserException();
            }

            if (!GamePool.LoggedUsers.Any(luser => luser.UserName.Equals(user.UserName)))
            {
                throw new PlayerNotExistsException();
            }

            Game game = GetGameInfo(gameName);

            if (game.Status != EnumGameStatus.InProgress)
            {
                throw new ThisGameIsNotInProgressException();
            }

            if (!game.Users[game.UserTurnIndex].UserName.Equals(user.UserName))
            {
                throw new ThisIsNotYourTurnException();
            }

            if (gameColorsCodes.Any(gc => !game.PossibleColors.Select(pc => pc.ColorCode).Contains(gc)))
            {
                throw new ThisColorIsNotAllowed();
            }

            if (gameColorsCodes.Length != game.NumberOfCorrectColors)
            {
                throw new ThisGuessHasDifferentQtOfColors();
            }

            if (game.Turn >= game.QuantityOfMaximumTurns)
            {
                throw new ThisGameIsOverException();
            }

            return game;
        }
    }
}
