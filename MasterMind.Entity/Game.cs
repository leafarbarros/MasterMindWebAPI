using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMind.Entity
{
    public class Game : GameEngine
    {
        public string GameName { get; set; }

        public EnumGameStatus Status { get; set; }

        public IList<User> Users { get; set; }

        public GameColor[] CorrectAnswer { get; set; }
       
        public IList<Guess> Guesses { get; set; }

        public int UserTurnIndex { get; set; }

        public int Turn { get; set; }
        
        public Game(string gameName, User firstPlayer) : base()
        {
            this.GameName = gameName;
            this.Users = new List<User>();
            this.Users.Add(firstPlayer);
            this.Status = EnumGameStatus.WaitingForPlayers;
            this.Guesses = new List<Guess>();
            this.UserTurnIndex = 0;
            this.Turn = 1;
        }

        public Game(string gameName, User firstPlayer, int QtUsers) : base(QtUsers)
        {
            this.GameName = gameName;
            this.Users = new List<User>();
            this.Users.Add(firstPlayer);
            this.Status = EnumGameStatus.WaitingForPlayers;
            this.Guesses = new List<Guess>();
            this.UserTurnIndex = 0;
            this.Turn = 1;
        }
        
        public Game(string gameName, User firstPlayer, GameColor[] possibleColors)
            : base(possibleColors)
        {
            this.GameName = gameName;
            this.Users = new List<User>();
            this.Users.Add(firstPlayer);
            this.Status = EnumGameStatus.WaitingForPlayers;
            this.Guesses = new List<Guess>();
            this.UserTurnIndex = 0;
            this.Turn = 1;
        }

        public Game(string gameName, User firstPlayer, int numberOfCorrectColors, GameColor[] possibleColors)
            : base(numberOfCorrectColors, possibleColors)
        {
            this.GameName = gameName;
            this.Users = new List<User>();
            this.Users.Add(firstPlayer);
            this.Status = EnumGameStatus.WaitingForPlayers;
            this.Guesses = new List<Guess>();
            this.UserTurnIndex = 0;
            this.Turn = 1;
        }

       

    }
}
