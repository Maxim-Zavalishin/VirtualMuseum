using AutoMapper;
using VirtualMuseum.Domain.Dto.Article;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.Application.AutoMapper.ArticleMappers;

public class ArticleMapper : Profile
{
    public ArticleMapper()
    {
        CreateMap<Article, ArticleDto>().ReverseMap();
    }
}