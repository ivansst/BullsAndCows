using BullsAndCows.Repository;
using BullsAndCows.Repository.Models;
using System.Collections.Generic;

namespace BullsAndCows.Models
{
    public class UserTriesModel
    {
        public IEnumerable<UserTries> UserTries { get; set; }
    }
}
