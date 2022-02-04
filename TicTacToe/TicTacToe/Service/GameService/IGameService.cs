namespace TicTacToe.Service;
public interface IGameService
{
    Task<int> InitializeGame(Human player1, Human player2, Computer computer);
    Task TableScoreInitializeVsHuman(Human player);
    Task TableScoreInitializeVsComputer(Human player, string difficulty);
}

