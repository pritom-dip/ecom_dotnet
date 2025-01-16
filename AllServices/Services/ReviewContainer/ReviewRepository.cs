using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.RepositoryContainer;
using DataAccess.Data;
using Models;

namespace AllServices.Services.ReviewContainer
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _reviewRepo;
        public ReviewRepository(ApplicationDbContext context): base(context)
        {
            _reviewRepo = context;
        }
    }
}