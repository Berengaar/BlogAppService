using AutoMapper;
using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Application.Dtos.ArticleDtos;
using BlogAppService.Application.Dtos.Category;
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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var articleList = await _unitOfWork.ArticleReadRepository.GetAllAsync();
            if (articleList != null)
            {
                var articles = _mapper.Map<ArticleListDto>(articleList);
                if (articles != null)
                {
                    return Ok(articles);
                }
                return NoContent();
            }
            return BadRequest();
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetAllByCategoryIdAsync(string categoryId)
        {
            var articleList = await _unitOfWork.ArticleReadRepository.GetWhereAsync(x => x.CategoryId == categoryId);
            if (articleList != null)
            {
                var articles = _mapper.Map<ArticleListDto>(articleList);
                if (articleList != null)
                {
                    return Ok(articles);
                }
                return NoContent();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var article = await _unitOfWork.ArticleReadRepository.FindAsync(x => x.Id == id);
            if (article != null)
            {
                var mappedArticle = _mapper.Map<ArticleDto>(article);
                if (mappedArticle != null)
                {
                    return Ok(mappedArticle);
                }
                return NoContent();
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddArticleDto addArticleDto)
        {
            var identityModel = await _unitOfWork.IdentityHelperService.GetIdentityModel(User.Identity.Name);
            var article = _mapper.Map<Article>(addArticleDto);
            if (article != null)
            {
                article.AppUserId = identityModel.Id;
                var result = await _unitOfWork.ArticleWriteRepository.AddAsync(article);
                if (result)
                {
                    return StatusCode(201);
                }
                return StatusCode(501);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateArticleDto updateArticleDto)
        {
            var identityModel = await _unitOfWork.IdentityHelperService.GetIdentityModel(User.Identity.Name);
            var article = _mapper.Map<Article>(updateArticleDto);
            if (article != null)
            {
                var isExist = await _unitOfWork.ArticleReadRepository.FindAsync(x => x.Id == updateArticleDto.Id);
                var isUserControl = await _unitOfWork.ArticleReadRepository.FindAsync(x => x.AppUserId == identityModel.Id && x.Id==updateArticleDto.Id);

                if (isExist != null && isUserControl != null)
                {
                    var result = await _unitOfWork.ArticleWriteRepository.UpdateAsync(article);
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
