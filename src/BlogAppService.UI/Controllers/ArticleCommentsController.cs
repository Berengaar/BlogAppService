using AutoMapper;
using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Application.Dtos.ArticleCommentDtos;
using BlogAppService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppService.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticleCommentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleCommentsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userInfo = "userInfo:"+User.Identity.Name;
            return Ok(userInfo);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddArticleCommentDto addArticleCommentDto)
        {
            var mapped = _mapper.Map<ArticleComment>(addArticleCommentDto);
            if (mapped != null)
            {
                await _unitOfWork.ArticleCommentWriteRepository.AddAsync(mapped);
                return Ok("Article comment başarıyla eklendi");
            }
            return Ok();
        }
    }
}
