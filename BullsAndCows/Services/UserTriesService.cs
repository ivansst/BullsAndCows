using BullsAndCows.Models;
using BullsAndCows.Repository.Interfaces;
using BullsAndCows.Repository.Models;
using BullsAndCows.Services.Interfaces;
using System.Collections.Generic;

namespace BullsAndCows.Services
{
    public class UserTriesService : IUserTriesService
    {
        private readonly IUserTriesRepository _userTriesRepository;

        public UserTriesService(IUserTriesRepository userTriesRepository)
        {
            _userTriesRepository = userTriesRepository;
        }

        public IEnumerable<UserTries> GetAll()
        {
            var result = _userTriesRepository.GetAll();

            return result;
        }
    }
}
