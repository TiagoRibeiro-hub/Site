namespace Games.Infrastructure.Game;
#nullable disable
public class Player
{
    public Player()
    {

    }
    public Player(string name)
    {
        Name = name;
    }

    public Player(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public Player(string name, string email, string turn)
    {
        Name = name;
        Email = email;
        Turn = turn;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Turn { get; set; }

}
