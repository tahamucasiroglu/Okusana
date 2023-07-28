using AutoMapper;
using Okusana.DTOs.Abstract;
using Okusana.Entities.Abstract;

namespace Okusana.Mapper.Extensions
{
    static public class MapperConfigExtension
    {
        static public IMappingExpression<TDest, TSrc> DefaultAddMapConfig<TDest, TSrc>(this IMappingExpression<TDest, TSrc> mapper) 
            where TDest: IAddDTO
            where TSrc: IEntity =>
            mapper.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

        static public IMappingExpression<TDest, TSrc> DefaultUpdateMapConfig<TDest, TSrc>(this IMappingExpression<TDest, TSrc> mapper)
            where TDest : IUpdateDTO
            where TSrc : IEntity =>
            mapper.ForMember(dest => dest.UpdateDate, src => src.MapFrom(src => DateTime.UtcNow));

        static public IMappingExpression<TDest, TSrc> DefaultDeleteMapConfig<TDest, TSrc>(this IMappingExpression<TDest, TSrc> mapper)
            where TDest : IDeleteDTO
            where TSrc : IEntity =>
            mapper.ForMember(dest => dest.DeleteDate, src => src.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.IsDeleted, src => src.MapFrom(src => true));



    }   
}
