﻿using Abp.AutoMapper;
using Cinotam.AbpModuleZero.Attachments.Entities;

namespace Cinotam.SimplePost.Application.Posts.Dto
{
    [AutoMap(typeof(Attachment))]
    public class PostAttachmentDto
    {
        public string Description { get; set; }
        public string ContentUrl { get; set; }
        public bool StoredInCdn { get; set; }
    }
}
