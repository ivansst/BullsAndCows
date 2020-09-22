using BullsAndCows.Models;

namespace BullsAndCows.Services.Interfaces
{
    public interface IGameService
    {
        GameModel PlayGame(GameModel model, string playerEmail);

        int GenerateComputerSecret();
    }
}
