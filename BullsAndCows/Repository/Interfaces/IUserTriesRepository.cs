using BullsAndCows.Repository.Models;
using System.Collections.Generic;

namespace BullsAndCows.Repository.Interfaces
{
    public interface IUserTriesRepository
    {
        IEnumerable<UserTries> GetAll();

        void Insert(string userId, int tries);
    }
}
