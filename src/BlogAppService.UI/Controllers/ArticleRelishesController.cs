using AutoMapper;
using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Application.Dtos.ArticleDtos;
using BlogAppService.Application.Dtos.ArticleRelishDtos;
using BlogAppService.Application.Dtos.Category;
using BlogAppService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppService.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleRelishesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleRelishesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{articleId}")]
        public async Task<IActionResult> GetArticlesByUserId(string articleId)
        {
            var relishList = await _unitOfWork.ArticleRelishReadRepository.GetWhereAsync(x => x.ArticleId == articleId, x => x.AppUser);
            if (relishList != null)
            {
                var relishes = _mapper.Map<List<ArticleRelishDto>>(relishList);
                if (relishes != null)
                {
                    return Ok(relishes);
                }
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddArticleRelishDto addArticleRelishDto)
        {
            var identityModel = await _unitOfWork.IdentityHelperService.GetIdentityModel(User.Identity.Name);
            var articleRelish = _mapper.Map<ArticleRelish>(addArticleRelishDto);
            if (articleRelish != null)
            {
                articleRelish.AppUserId = identityModel.Id;
                var result = await _unitOfWork.ArticleRelishWriteRepository.AddAsync(articleRelish);
                if (result)
                {
                    return StatusCode(201);
                }
                return StatusCode(501);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateArticleRelishDto updateArticleRelishDto)
        {
            var identityModel = await _unitOfWork.IdentityHelperService.GetIdentityModel(User.Identity.Name);
            var articleRelish = _mapper.Map<ArticleRelish>(updateArticleRelishDto);
            if (articleRelish != null)
            {
                var isExist = await _unitOfWork.ArticleRelishReadRepository.FindAsync(x => x.Id == updateArticleRelishDto.Id);
                var isUserControl = await _unitOfWork.ArticleRelishReadRepository.FindAsync(x => x.AppUserId == identityModel.Id && x.Id == updateArticleRelishDto.Id);

                if (isExist != null && isUserControl != null)
                {
                    articleRelish.AppUserId = identityModel.Id;
                    articleRelish.ArticleId = isExist.ArticleId;
                    var result = await _unitOfWork.ArticleRelishWriteRepository.UpdateAsync(articleRelish);
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
        public async Task<IActionResult> DeleteAsync(DeleteArticleRelishDto deleteArticleRelishDto)
        {
            var identityModel = await _unitOfWork.IdentityHelperService.GetIdentityModel(User.Identity.Name);
            var articleRelish = _mapper.Map<ArticleRelish>(deleteArticleRelishDto);
            if (articleRelish != null)
            {
                var isExist = await _unitOfWork.ArticleRelishReadRepository.FindAsync(x => x.Id == deleteArticleRelishDto.Id && x.AppUserId==identityModel.Id);
                if (isExist != null)
                {
                    var result = await _unitOfWork.ArticleRelishWriteRepository.DeleteAsync(articleRelish);
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
