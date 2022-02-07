using TicTacToe.Data;

namespace TicTacToe.Services;

public static class GameServiceFuncs
{

    internal static GameModel PlayersNameProp(Game player1, Game player2)
    {
        GameModel gameModel = new()
        {
            Player1_Name = player1.Player.Name,
        };
        if (player1.IsComputer)
        {
            gameModel.Player2_Name = Computer.Name;
            gameModel.IsComputer = true;
        }
        else
        {
            gameModel.Player2_Name = player2.Player.Name;
        }

        return gameModel;
    }
    internal static void StartsFirstProp(Game player1, Game player2, GameModel gameModel)
    {
        if (!player1.Player.StartFirst)
        {
            if (player1.IsComputer)
            {
                gameModel.StartFirst = Computer.Name;
            }
            else
            {
                gameModel.StartFirst = player2.Player.Name;
            }
        }
        else
        {
            gameModel.StartFirst = player1.Player.Name;
        }
    }
    internal static void DifficultyProp(Game player1, GameModel gameModel)
    {
        if (player1.Easy)
        {
            gameModel.Difficulty = Difficulty.Easy.ToString().ToUpper();
        }
        if (player1.Intermediate)
        {
            gameModel.Difficulty = Difficulty.Intermediate.ToString().ToUpper();
        }
        if (player1.Hard)
        {
            gameModel.Difficulty = Difficulty.Hard.ToString().ToUpper();
        }
    }
    internal static Moves AddMovesInit(string player)
    {
        return new Moves()
        {
            PlayerName = player,
        };
    }
}

