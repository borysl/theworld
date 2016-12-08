using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace TheWorld.Models
{
    public class WorldRepository : IWorldRepository
    {
        private readonly WorldContext _context;
        private readonly ILogger<IWorldRepository> _logger;

        public WorldRepository(WorldContext context, ILogger<WorldRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            _logger.LogInformation("Getting all trips from the database.");
            return _context.Trips.ToList();
        }

        public IEnumerable<Trip> GetTripsByUsername(string userName)
        {
            return _context.Trips.Include(_ => _.Stops).Where(t => t.UserName == userName);
        }

        public void AddTrip(Trip newTrip)
        {
            _context.Trips.Add(newTrip);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
