namespace TicTacToe.Service;
public interface IRepository
{
    Task RegisterPlayers(RegisterPlayersRequest registerPlayers);

}

