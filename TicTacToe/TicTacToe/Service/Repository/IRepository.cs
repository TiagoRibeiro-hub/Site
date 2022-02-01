namespace TicTacToe.Service;
public interface IRepository
{
    Task<Response> RegisterPlayers(RegisterPlayersRequest registerPlayers);

}

