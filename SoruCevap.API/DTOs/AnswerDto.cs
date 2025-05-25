namespace SoruCevap.API.DTOs
{
    public class AnswerDto
    {
        public int Id { get; set; }
       
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        public int QuestionId { get; set; }

        public QuestionDto? Question { get; set; }

        public UserDto? User { get; set; }

        public string? UserId { get; set; }




    }
}