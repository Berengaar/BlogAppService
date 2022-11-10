using AutoMapper;
using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Application.Dtos.Category;
using BlogAppService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppService.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _unitOfWork.CategoryReadRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddCategoryDto addCategoryDto)
        {
            var category = _mapper.Map<Category>(addCategoryDto);
            if (category != null)
            {
                var result= await _unitOfWork.CategoryWriteRepository.AddAsync(category);
                if (result)
                {
                    return StatusCode(201);
                }
                return StatusCode(501);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category= _mapper.Map<Category>(updateCategoryDto);
            if (category != null)
            {
                var isExist = await _unitOfWork.CategoryReadRepository.FindAsync(x => x.Id == updateCategoryDto.Id);
                if(isExist != null)
                {
                    var result=await _unitOfWork.CategoryWriteRepository.UpdateAsync(category);
                    if (result)
                    {
                        return Ok();
                    }
                    return StatusCode(501);
                }
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoryDto deleteCategoryDto)
        {
            var category=_mapper.Map<Category>(deleteCategoryDto);
            if (category != null)
            {
                var isExist=await _unitOfWork.CategoryReadRepository.FindAsync(x=>x.Id==deleteCategoryDto.Id);
                if (isExist != null)
                {
                    var result = await _unitOfWork.CategoryWriteRepository.DeleteAsync(category);
                    if (result)
                    {
                        return Ok();
                    }
                    return StatusCode(501);
                }
                return NoContent();
            }
            return BadRequest();
        }
    }
}
