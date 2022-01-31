namespace TicTacToe;
#nullable disable
public class Winner
{
    public string Name { get; set; }
    public bool HaveWinner { get; set; }
    public async Task<bool> HaveWinnerMethod(List<int> ListMovesPlayer)
    {
        var resDiagonal = Diagonal(ListMovesPlayer);
        var resVertical = Vertical(ListMovesPlayer);
        var resHorizontal = Horizontal(ListMovesPlayer);

        if (await resDiagonal) return true;
        if (await resVertical) return true;
        if (await resHorizontal) return true;
        
        return false;
    }
    public Task<bool> Diagonal(List<int> moves)
    {
        if ((moves.Contains(1) && moves.Contains(5) && moves.Contains(9)) ||
            (moves.Contains(3) && moves.Contains(5) && moves.Contains(7)))
        {
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
    public Task<bool> Vertical(List<int> moves)
    {
        if ((moves.Contains(1) && moves.Contains(4) && moves.Contains(7)) ||
            (moves.Contains(2) && moves.Contains(5) && moves.Contains(8)) ||
            (moves.Contains(3) && moves.Contains(6) && moves.Contains(9)))
        {
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
    public Task<bool> Horizontal(List<int> moves)
    {
        if ((moves.Contains(1) && moves.Contains(2) && moves.Contains(3)) ||
            (moves.Contains(4) && moves.Contains(5) && moves.Contains(6)) ||
            (moves.Contains(7) && moves.Contains(8) && moves.Contains(9)))
        {
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
