using _00.Data.Api.InitializeGame;
using _00.Data.Api.TicTacToe;
using System.Net.Http.Json;
using System.Text.Json;


namespace _02.Games.Core.Services._04.HttpClientTicTacToe;
public class HttpTicTacToe
{
    private readonly HttpClient _httpClient;

    public HttpTicTacToe(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<InitializeGameResponse> GetTicTacToeInitializeGame(InitializeGameRequest initializeGame)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/initialize", new TicTacToeInitializeGame(initializeGame));

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }

            TicTacToeInitializeGameResponse tictactoeResponse = await response.Content.ReadFromJsonAsync<TicTacToeInitializeGameResponse>();
            return new InitializeGameResponse(tictactoeResponse);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
}


