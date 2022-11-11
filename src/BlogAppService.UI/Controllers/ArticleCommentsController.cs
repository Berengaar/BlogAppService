using AutoMapper;
using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Application.Dtos.ArticleCommentDtos;
using BlogAppService.Application.Dtos.ArticleDtos;
using BlogAppService.Application.Dtos.ArticleRelishDtos;
using BlogAppService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppService.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ArticleCommentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleCommentsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{articleId}")]
        public async Task<IActionResult> GetCommentsByArticleIdAsync(string articleId)
        {
            var commentList = await _unitOfWork.ArticleCommentReadRepository.GetWhereAsync(x => x.ArticleId == articleId, x => x.AppUser);
            if (commentList != null)
            {
                var comments = _mapper.Map<List<ArticleCommentDto>>(commentList);
                if (comments != null)
                {
                    return Ok(comments);
                }
                return NoContent();
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddArticleCommentDto addArticleCommentDto)
        {
            var identityModel = await _unitOfWork.IdentityHelperService.GetIdentityModel(User.Identity.Name);
            var articleComment = _mapper.Map<ArticleComment>(addArticleCommentDto);
            if (articleComment != null)
            {
                articleComment.AppUserId = identityModel.Id;
                var result = await _unitOfWork.ArticleCommentWriteRepository.AddAsync(articleComment);
                if (result)
                {
                    return StatusCode(201);
                }
                return StatusCode(501);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateArticleCommentDto updateArticleCommentDto)
        {
            var identityModel = await _unitOfWork.IdentityHelperService.GetIdentityModel(User.Identity.Name);
            var articleComment = _mapper.Map<ArticleComment>(updateArticleCommentDto);
            if (articleComment != null)
            {
                var isExist = await _unitOfWork.ArticleCommentReadRepository.FindAsync(x => x.Id == updateArticleCommentDto.Id);
                var isUserControl = await _unitOfWork.ArticleCommentReadRepository.FindAsync(x => x.AppUserId == identityModel.Id && x.Id == updateArticleCommentDto.Id);

                if (isExist != null && isUserControl != null)
                {
                    articleComment.AppUserId = identityModel.Id;
                    articleComment.ArticleId = isExist.ArticleId;
                    var result = await _unitOfWork.ArticleCommentWriteRepository.UpdateAsync(articleComment);
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
