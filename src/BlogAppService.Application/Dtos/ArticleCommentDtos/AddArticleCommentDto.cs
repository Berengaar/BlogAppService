﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Dtos.ArticleCommentDtos
{
    public class AddArticleCommentDto : ArticleCommentDto
    {
        public string Content { get; set; }
        public string ArticleId { get; set; }
    }
}
