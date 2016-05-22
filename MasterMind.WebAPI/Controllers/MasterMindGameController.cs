using MasterMind.Entity;
using MasterMind.Handlers;
using MasterMind.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MasterMind.WebAPI.Controllers
{

    [RoutePrefix("api/MasterMindGame")]
    public class MasterMindGameController : ApiController
    {
        public static MasterMindGameHandler MasterMindGameHandler { get; set; }

        public MasterMindGameController()
        {
            if (MasterMindGameHandler == null)
            {
                MasterMindGameHandler = new MasterMindGameHandler();
            }
        }

        // GET: api/MasterMindGame
        public HttpResponseMessage Get()
        {
            List<GameSummaryModel> result = new List<GameSummaryModel>();
            if (MasterMindGameHandler!= null && MasterMindGameHandler.GamePool != null && MasterMindGameHandler.GamePool.Games != null)
            { 
                foreach(var game in MasterMindGameHandler.GamePool.Games)
                {
                    result.Add(new GameSummaryModel() {
                        GameName = game.GameName,
                        UserQt = game.Users.Count,
                        GameStatus = (int)game.Status

                    });
                }
    
            }
            
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        
        [HttpGet]
        [Route("CreateGame")]
        /// <summary>
        /// Create a new Game.
        /// </summary>
        public HttpResponseMessage CreateGame(string userName, int qtUsers)
        {
            User u = new User(userName);
            MasterMindGameHandler.CreateNewUserIfNotExists(u);
            string gameName = MasterMindGameHandler.GenerateGameName();
            MasterMindGameHandler.CreateNewGame(gameName,u, qtUsers);
            
            MasterMindGameHandler.StartGameIfTheGameIsFull(gameName);

            GameSummaryModel result = new GameSummaryModel( MasterMindGameHandler.GamePool.Games.First(g => g.GameName.Equals(gameName)) );

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("JoinGame")]
        public HttpResponseMessage JoinGame(string gameName, string userName)
        {
            User u = new User(userName);
            MasterMindGameHandler.CreateNewUserIfNotExists(u);
            
            MasterMindGameHandler.JoinGame(gameName, u);

            MasterMindGameHandler.StartGameIfTheGameIsFull(gameName);

            GameSummaryModel result = new GameSummaryModel(MasterMindGameHandler.GamePool.Games.First(g => g.GameName.Equals(gameName)));

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("GetGameInfo")]
        public HttpResponseMessage GetGameInfo(string gameName)
        {
            Game result = MasterMindGameHandler.GetGameInfo(gameName);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [HttpPost]
        [Route("UserGuess")]
        public HttpResponseMessage UserGuess([FromBody] UserGuessModel userGuess)
        {
            User u = new User(userGuess.UserName);

            EnumFeedback[] result = MasterMindGameHandler.UserGuess(userGuess.GameName, u, userGuess.GameColorsCodes);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ClearAll")]
        public HttpResponseMessage ClearAll(string Key)
        {
            if (Key.Equals("H@CK@TH0N2016")){

                MasterMindGameHandler = new MasterMindGameHandler();
            }

            return Request.CreateResponse(HttpStatusCode.OK, "All Clear!!");
        }

    }
}
