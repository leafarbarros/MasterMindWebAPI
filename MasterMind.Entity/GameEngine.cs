using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMind.Entity
{
    public class GameEngine
    {

        private int _quantityOfMaximumTurns{ get; set; }
        public int QuantityOfMaximumTurns
        {
            get
            {
                return _quantityOfMaximumTurns;
            }
        }

        private int _numberOfCorrectColors { get; set; }
        public int NumberOfCorrectColors
        {
            get
            {
                return _numberOfCorrectColors;
            }
        }

        private int _numberOfMaximumUsers { get; set; }
        public int NumberOfMaximumUsers
        {
            get
            {
                return _numberOfMaximumUsers;
            }
        }

        private GameColor[] _possibleColors { get; set; }
        public GameColor[] PossibleColors
        {
            get
            {
                return _possibleColors;
            }
        }

        // default constructor
        public GameEngine()
        {
            _numberOfCorrectColors = 8;
            _numberOfMaximumUsers = 2;
            _quantityOfMaximumTurns = 10;
            DefaultPossibleColors();
        }


        public GameEngine(int numberOfMaximumUsers)
        {
            _numberOfCorrectColors = 8;
            _numberOfMaximumUsers = numberOfMaximumUsers;
            _quantityOfMaximumTurns = 10;
            DefaultPossibleColors();
        }
        

        public GameEngine(int numberOfCorrectColors, GameColor[] possibleColors)
        {
            this._numberOfCorrectColors = numberOfCorrectColors;
            _numberOfMaximumUsers = 2;
            _quantityOfMaximumTurns = 10;
            this._possibleColors = possibleColors;
        }

        public GameEngine(GameColor[] possibleColors)
        {
            this._numberOfCorrectColors = 8;
            _numberOfMaximumUsers = 2;
            _quantityOfMaximumTurns = 10;
            this._possibleColors = possibleColors;
        }

        private void DefaultPossibleColors()
        {
            this._possibleColors = new GameColor[8];
            this._possibleColors[0] = new GameColor("1", "Red");
            this._possibleColors[1] = new GameColor("2", "Green");
            this._possibleColors[2] = new GameColor("3", "Blue");
            this._possibleColors[3] = new GameColor("4", "Yellow");
            this._possibleColors[4] = new GameColor("5", "White");
            this._possibleColors[5] = new GameColor("6", "Black");
            this._possibleColors[6] = new GameColor("7", "Orange");
            this._possibleColors[7] = new GameColor("8", "Brown");
        }

    }
}
