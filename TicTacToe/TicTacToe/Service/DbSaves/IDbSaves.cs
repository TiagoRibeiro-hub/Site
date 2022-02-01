namespace TicTacToe.Service;
public interface IDbSaves
{
    Task InitializeGame(Human player1, Human? player2, Computer? computer);
}

