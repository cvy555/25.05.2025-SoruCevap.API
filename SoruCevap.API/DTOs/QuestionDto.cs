

namespace SoruCevap.API.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
       
        public string VideoUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        public int CategoryId { get; set; }

        public CategoryDto? Category { get; set; }

        public string? UserId { get; set; }

        public UserDto? User { get; set; }


    }
}
