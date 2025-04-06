using Instagram_Backend.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Backend.Mappers;

public static class MapperPagedResult
{
    // benefits of this approach : 
        // -  Mapper logic is separated from the data access logic
        // -  Mapper logic is reusable across different services
    public static async Task<PagedResult<TDestination>> MapPagedResult<TSource, TDestination>(
        IQueryable<TSource> source, int page, int pageSize, 
        Func<TSource, TDestination> mapFunc)
    {
        var totalCount = await source.CountAsync();
        
        var items = await source
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var mappedItems = items.Select(mapFunc).ToList();

        return new PagedResult<TDestination>
        {
            Items = mappedItems,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize,
        };
    }
    
    public static async Task<PagedResult<TDestination>> MapPagedResult<TSource, TDestination>(
        IQueryable<TSource> source, int page, int pageSize, Guid currentUserId,
        Func<TSource, Guid, TDestination> mapFunc)
    {
        var totalCount = await source.CountAsync();
        
        var items = await source
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var mappedItems = items.Select(item => mapFunc(item, currentUserId)).ToList();

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