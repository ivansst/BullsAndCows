namespace BullsAndCows.Repository.Interfaces
{
    public interface IUserRepository
    {
        string GetIdByEmail(string username);
    }
}
