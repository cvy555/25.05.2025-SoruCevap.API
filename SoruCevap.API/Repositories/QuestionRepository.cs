using SoruCevap.API.Models;
using SoruCevap.Repositories;

namespace SoruCevap.API.Repositories
{
    public class QuestionRepository : GenericRepository <Question>
    {
       public QuestionRepository(AppDbContext context) : base(context)
        {

        }
        
    }
}
