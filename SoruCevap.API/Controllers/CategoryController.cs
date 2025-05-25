using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoruCevap.API.DTOs;
using SoruCevap.API.Models;
using SoruCevap.API.Repositories;
using SoruCevap.Repositories;
using System.Security.Claims;


namespace SoruCevap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly QuestionRepository _questionRepository;

        private readonly IMapper _mapper;
        ResultDto _result = new ResultDto();
        public CategoryController(IMapper mapper, CategoryRepository categoryRepository, QuestionRepository questionRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public async Task<List<CategoryDto>> List()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var CategoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            return CategoryDtos;
        }

        [HttpGet("{id}")]
        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            var CategoryDto = _mapper.Map<CategoryDto>(category);
            return CategoryDto;
        }

        [HttpPost]
        public async Task<ResultDto> Add(CategoryDto model)
        {
            var list = _categoryRepository.Where(s => s.Name == model.Name).ToList();
            if (list.Count() > 0)
            {
                _result.Status = false;
                _result.Message = "Girilen Kategori Adı Kayıtlıdır!";
                return _result;
            }
            else
            {
                var category = _mapper.Map<Category>(model);
                await _categoryRepository.AddAsync(category);
                _result.Status = true;
                _result.Message = "Kayıt Eklendi";
                return _result;
            }
        }

       
        [HttpGet("{id}/Question")]
        public async Task<List<QuestionDto>> QuestionList(int id)
        {
            var questions = await _questionRepository.Where(s => s.CategoryId == id).Include(i => i.Category).Include(i => i.User).ToListAsync();
            var questionsDto = _mapper.Map<List<QuestionDto>>(questions);

            if (!User.IsInRole("Admin"))
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                questionsDto = questionsDto.Where(s => s.UserId == userId).ToList();
            }

            return questionsDto;
        }



        [HttpPut]
        public async Task<ResultDto> Update(Category model)
        {
            var category = await _categoryRepository.GetByIdAsync(model.Id);
            category.Name = model.Name;
            category.Description = model.Description;
            await _categoryRepository.UpdateAsync(category);
            _result.Status = true;
            _result.Message = "Kayıt Güncellendi";
            return _result;
        }

        [HttpDelete("{id}")]
        public async Task<ResultDto> Delete(int id) { 
        

            await _categoryRepository.DeleteAsync(id);
            _result.Status = true;
            _result.Message = "Kayıt Silindi";
            return _result;

        }
    }
}