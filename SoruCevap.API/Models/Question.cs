using SoruCevap.API.DTOs;

namespace SoruCevap.API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }


        public string VideoURL { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }


    }
}
