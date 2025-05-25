using System.Reflection;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoruCevap.API.DTOs;
using SoruCevap.API.Models;
using SoruCevap.API.Repositories;
namespace SoruCevap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionRepository _questionRepository;
        private readonly AnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        ResultDto _result = new ResultDto();
        public QuestionController(QuestionRepository questionRepository, IMapper mapper, AnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _answerRepository = answerRepository;
        }

        [HttpGet]
        public async Task<List<QuestionDto>> List()
        {
            var question = await _questionRepository.GetAllAsync();
            var questionDto = _mapper.Map<List<QuestionDto>>(question);
            return questionDto;
        }

        [HttpGet("{id}")]
        public async Task<QuestionDto> GetById(int id)
        {
            var question = await _questionRepository.GetByIdAsync(id);
            var questionDto = _mapper.Map<QuestionDto>(question);
            return questionDto;
        }

        [HttpPost]
        public async Task<ResultDto> Add(Question model)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var questions = _mapper.Map<Question>(model);
            questions.UserId = userId;
            questions.CreatedTime = DateTime.Now;
            questions.UpdatedTime = DateTime.Now;
            await _questionRepository.AddAsync(questions);
            _result.Status = true;
            _result.Message = "Kayıt Eklendi";
            return _result;
        }
        [HttpPut]
        public async Task<ResultDto> Update(Question model)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var questions = _mapper.Map<Question>(model);
            questions.UserId = userId;
            questions.UpdatedTime = DateTime.Now;
            await _questionRepository.UpdateAsync(questions);
            _result.Status = true;
            _result.Message = "Kayıt GüncelLendi";
            return _result;
        }

        [HttpDelete("{id}")]
        public async Task<ResultDto> Delete(int id)
        {

            await _questionRepository.DeleteAsync(id);
            _result.Status = true;
            _result.Message = "Kayıt Silindi";
            return _result;

        }
        [HttpGet("{id}/Answers")]
        public async Task<List<AnswerDto>> AnswerList(int id)
        {
            var answers = await _answerRepository
                .Where(s => s.QuestionId == id)
                .Include(i => i.Question)
                .Include(i => i.User)
                .ToListAsync();

            var answerDto = _mapper.Map<List<AnswerDto>>(answers);

            return answerDto;
        }

    }
}