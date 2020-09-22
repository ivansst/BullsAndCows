using BullsAndCows.Models;
using BullsAndCows.Repository.Models;
using System.Collections;
using System.Collections.Generic;

namespace BullsAndCows.Services.Interfaces
{
    public interface IUserTriesService
    {
        IEnumerable<UserTries> GetAll();
    }
}
