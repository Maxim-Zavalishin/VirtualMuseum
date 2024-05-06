using AutoMapper;
using VirtualMuseum.Domain.Dto.Article;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.Application.AutoMapper.ArticleMappers;

public class GetArticleMapper : Profile
{
    public GetArticleMapper()
    {
        CreateMap<Article, GetArticleDto>().ReverseMap();
    }
}