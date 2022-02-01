namespace TicTacToe.Service;
public interface IGameService
{
    Task InitializeGame(Human player1, Human player2, Computer computer, Guid guid);
    Task TableScoreInitializeVsHuman(Human player1, Human player2);
    Task TableScoreInitializeVsComputer(Human player1, Computer computer);
}

