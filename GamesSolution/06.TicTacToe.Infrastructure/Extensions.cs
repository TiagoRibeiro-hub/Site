using _00.Data._Entities;

namespace _06.TicTacToe.Infrastructure;
public static class Extensions
{
    public static GameEntity SetGameEntity(this InitializeGameRequestRecord x)
    {
        return new GameEntity
            (
                player1_Name: x.PlayerName_1,
                player2_Name: x.PlayerName_2,
                isComputer: x.IsComputer,
                difficulty: x.Difficulty,
                startFirst: x.StartFirst
            );
    }
}
