using AutoMapper;
using Entities.RequestFeatures;

namespace Entities.Extensions
{
    public static class PagedListExtensions
    {
        public static PagedList<TDestination> ToMappedPagedList<TSource, TDestination>(this PagedList<TSource> source, IMapper mapper)
        {
            var mappedItems = mapper.Map<IEnumerable<TDestination>>(source).ToList();

            return new PagedList<TDestination>(mappedItems, source.MetaData.TotalCount, source.MetaData.CurrentPage, source.MetaData.PageSize);
        }
    }
}
