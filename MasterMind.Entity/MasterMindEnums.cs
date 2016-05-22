using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMind.Entity
{
    public enum EnumFeedback
    {
        NotFound = 0,
        FoundButNotCorrect = 1,
        Correct = 2,

    }

    public enum EnumGameStatus
    {
        WaitingForPlayers = 1,
        InProgress = 2,
        Finished = 3
    }

}
