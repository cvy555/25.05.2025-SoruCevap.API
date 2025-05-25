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
    public class AnswerController : ControllerBase
    {
        private readonly AnswerRepository _answerRepository;
        private readonly QuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        ResultDto _result = new ResultDto();

        public AnswerController(AnswerRepository answerRepository, IMapper mapper, QuestionRepository questionRepository)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public async Task<List<AnswerDto>> List()
        {
            var answer = await _answerRepository.GetAllAsync();
            var answerDto = _mapper.Map<List<AnswerDto>>(answer);
            return answerDto;
        }

        [HttpGet("{id}")]
        public async Task<AnswerDto> GetById(int id)
        {
            var answer = await _answerRepository.GetByIdAsync(id);
            var answerDto = _mapper.Map<AnswerDto>(answer);
            return answerDto;
        }

        [HttpPost]
        public async Task<ResultDto> Add(AnswerDto model)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            
            var answer = _mapper.Map<Answer>(model);
            answer.CreatedTime = DateTime.Now;
            answer.UpdatedTime = DateTime.Now;
            answer.UserId = userId;
            await _answerRepository.AddAsync(answer);
            _result.Status = true;
            _result.Message = "Kayıt Eklendi";
            return _result;
        }
        [HttpPut]
        public async Task<ResultDto> Update(Answer model)
        {
            var answer = _mapper.Map<Answer>(model);
            answer.UpdatedTime = DateTime.Now;
            await _answerRepository.UpdateAsync(answer);
            _result.Status = true;
            _result.Message = "Kayıt GüncelLendi";
            return _result;
        }

        [HttpDelete("{id}")]
        public async Task<ResultDto> Delete(int id)
        {

            await _answerRepository.DeleteAsync(id);
            _result.Status = true;
            _result.Message = "Kayıt Silindi";
            return _result;

        }
        

    }
}