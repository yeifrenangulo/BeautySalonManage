using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace BeautySalonManage.Application.Common.Mappings;

public static class MappingExtensions
{
    public static List<TDestination> ProjectToList<TOrigin, TDestination>(this IEnumerable<TOrigin> list, IConfigurationProvider configuration) 
        where TDestination : class 
        where TOrigin : class
    {
        return list.AsQueryable().ProjectTo<TDestination>(configuration).ToList();
    }
}
