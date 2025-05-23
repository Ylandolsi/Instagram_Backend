using Instagram_Backend.Database;
using Instagram_Backend.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Backend.Mappers;

public static class MapperPagedResult
{
    public static async Task<PagedResult<TDestination>> MapPagedResult<TSource, TDestination>(
        IQueryable<TSource> source, int page, int pageSize, 
        Func<TSource, TDestination> mapFunc)
    {
        var totalCount = await source.CountAsync();
        
        var items = await source
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var mappedItems = items.Select(item => mapFunc(item)).ToList();

        return new PagedResult<TDestination>
        {
            Items = mappedItems,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize,
        };
    }
    
    public static async Task<PagedResult<TDestination>> MapPagedResult2<TSource, TDestination>(
        IQueryable<TSource> source, int page, int pageSize, Guid currentUserId,
        ApplicationDbContext context,
        Func<TSource, Guid, ApplicationDbContext ,  TDestination> mapFunc)
    {
        var totalCount = await source.CountAsync();
        
        var items = await source
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var mappedItems = items.Select(item => mapFunc(item, currentUserId , context)).ToList();

        return new PagedResult<TDestination>
        {
            Items = mappedItems,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize,
        };
    }
}
    // public static PagedResult<CommentDto> MapCommentsToPagedResult(IQueryable<Comment> comments, int page, int pageSize, Guid currentUserId)
    // {
    //     var totalCount = comments.Count();
    //     var pagedComments = comments
    //         .Skip((page - 1) * pageSize)
    //         .Take(pageSize)
    //         .Select(c => MapCommentToDto(c, currentUserId))
    //         .ToList();

    //     return new PagedResult<CommentDto>
    //     {
    //         Items = pagedComments,
    //         TotalCount = totalCount,
    //         Page = page,
    //         PageSize = pageSize
    //     };
    // }