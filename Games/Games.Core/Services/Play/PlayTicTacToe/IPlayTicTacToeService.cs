namespace Games.Core.Services;
public interface IPlayTicTacToeService
{
    Dictionary<string, string> SetInitialPossibleMovesTicTacToe(int ticTacToeNrCol);
}
