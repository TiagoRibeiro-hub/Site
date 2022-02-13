namespace Games.Infrastructure.Game;
#nullable disable
public class Player
{
    public Player(string name)
    {
        Name = name;
    }

    public Player(string name, string turn)
    {
        Name = name;
        Turn = turn;
    }

    public Player(string name, string email, string turn, Moves moves)
    {
        Name = name;
        Email = email;
        Turn = turn;
        Moves = moves;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Turn { get; set; }
    public Moves Moves { get; set; }

}

