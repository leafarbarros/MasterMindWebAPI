using MasterMind.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterMind.WebAPI.Models
{
    public class GameSummaryModel
    {
        public string GameName { get; set; }

        public int UserQt { get; set; }

        public int GameStatus { get; set; }
        
        public int MaximumUsers { get; set; }

        public GameSummaryModel()
        {
            GameName = string.Empty;
            UserQt = 0;
            GameStatus = (int)EnumGameStatus.WaitingForPlayers;
        }

        public GameSummaryModel(Game game)
        {
            this.GameName = game.GameName;
            this.GameStatus = (int)game.Status;
            this.UserQt = game.Users.Count;
            this.MaximumUsers = game.NumberOfMaximumUsers;

        }
    }
}