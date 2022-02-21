namespace Games.Data.Api;

public class InitializeGameResponse
{
    public InitializeGameResponse()
    {

    }
    public InitializeGameResponse(int idGame, bool startGame)
    {
        IdGame = idGame;
        StartGame = startGame;
    }

    public int IdGame { get; set; }
    public bool StartGame { get; set; }
}

