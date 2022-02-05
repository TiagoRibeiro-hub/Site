namespace TicTacToe.Service;
public class RepositoryFuncs
{
    public static Human PlayerInfo(string name, string email)
    {
        return new Human()
        {
            Name = name,
            Email = email,
        };
    }
}

