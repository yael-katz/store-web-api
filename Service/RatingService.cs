using Entities;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RatingService : IRatingService
    {
        private IRatingRepository ratingRepository;
        private readonly ILogger<RatingService> _logger;

        public RatingService(IRatingRepository ratingRepository, ILogger<RatingService> logger)
        {
            this.ratingRepository = ratingRepository;
            _logger = logger;
        }

        public async Task<Rating> Add(Rating rating)
        {
            _logger.LogInformation("Adding a new rating...");

            try
            {
                // Add rating logic
                var result = await ratingRepository.Add(rating);
                _logger.LogInformation("Rating added successfully.");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding rating");
                throw;
            }
        }

    }
}
