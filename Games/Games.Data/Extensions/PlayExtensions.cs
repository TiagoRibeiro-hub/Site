

namespace Games.Data.Extensions;

public static class PlayExtensions
{
    public static PlayResponse SetPlayResponse(this PlayRequest x)
    {
        return new PlayResponse
            (
                getGameType: x.GetGameType,
                idGame: x.IdGame,
                playerName: x.PlayerName,
                gameState: null,
                gameResult: null,
                vsComputer: x.VsComputer,
                possibleMoves: x.PossibleMoves
            );
    }
}