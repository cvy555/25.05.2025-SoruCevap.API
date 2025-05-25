using SoruCevap.API.Models;
using SoruCevap.Repositories;

namespace SoruCevap.API.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>
    {
        public AnswerRepository(AppDbContext context) : base(context)
        {
        }
    }
    
  }

