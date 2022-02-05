namespace TicTacToe.Service;
public class RepositoryFuncs
{
    public static Human PlayerInfo(string name, string email, bool startFirst)
    {
        return new Human()
        {
            StartFirst = startFirst,
            Name = name,
            Email = email,
        };
    }
}

