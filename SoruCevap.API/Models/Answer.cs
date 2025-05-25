using SoruCevap.API.DTOs;
   
namespace SoruCevap.API.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public string VideoURL { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }

        public Question Question { get; set; }

        public int QuestionId { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

    }

}
