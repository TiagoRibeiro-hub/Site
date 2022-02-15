namespace Games.Infrastructure.Game;

public class StartFirst
{
    public StartFirst(string turn, string player1, string player2)
    {
        Turn = turn;
        Player1 = player1;
        Player2 = player2;
    }

    public string Turn { get; set; }
    public string Player1 { get; set; }
    public string Player2 { get; set; }

    internal string GetStartFirst()
    {
        return Turn.ToLower() == Games.Infrastructure.Enums.Turn.Player1.ToString().ToLower() ? Player1 : Player2;
    }


}