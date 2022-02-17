namespace Games.Data.Api;
#nullable disable
public class RegisterVsComputer : Register
{
    public bool IsComputer { get; private set; } = true;
    public string Difficulty { get; set; }
}
