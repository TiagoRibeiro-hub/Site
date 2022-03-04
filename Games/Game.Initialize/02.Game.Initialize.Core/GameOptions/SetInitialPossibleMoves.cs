using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Game.Initialize.Core.GameOptions;
public class SetInitialPossibleMoves
{
    internal Dictionary<string, string> SetInitialPossibleMovesTicTacToe(int TicTacToeNumberColumns)
    {
        int max = TicTacToeNumberColumns * TicTacToeNumberColumns + 1;
        Dictionary<string, string> result = new();
        for (int i = 1; i < max; i++)
        {
            result.Add(i.ToString(), i.ToString());
        }
        return result;
    }
}

