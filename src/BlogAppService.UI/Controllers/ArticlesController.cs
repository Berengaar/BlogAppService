using AutoMapper;
using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Application.Dtos.ArticleDtos;
using BlogAppService.Domain.Consts;
using BlogAppService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppService.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.User)]
    public class ArticlesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ArticlesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetArticles()
        {
            return Ok("Get çağrıldı");
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddArticleDto articleDto)
        {
            if (articleDto == null) return BadRequest("Article boş geldi");
            var article = _mapper.Map<Article>(articleDto);
            if (article != null)
            {
                await _unitOfWork.ArticleWriteRepository.AddAsync(article);
                return Ok("Article başarıyla eklendi");
            }
            return BadRequest("Article map edilirken hata oluştu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateArticleDto articleDto)
        {
            if (articleDto == null) return BadRequest("Article boş geldi");
            var article = _mapper.Map<Article>(articleDto);
            if (article != null)
            {
                await _unitOfWork.ArticleWriteRepository.UpdateAsync(article);
                return Ok("Article başarıyla eklendi");
            }
            return BadRequest("Article map edilirken hata oluştu");
        }
    }
}
