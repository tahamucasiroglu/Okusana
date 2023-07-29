using AutoMapper;
using Okusana.DTOs.Abstract;
using Okusana.DTOs.Concrete.Blog;
using Okusana.DTOs.Concrete.Category;
using Okusana.DTOs.Concrete.Comment;
using Okusana.DTOs.Concrete.HashTag;
using Okusana.DTOs.Concrete.SubCategory;
using Okusana.DTOs.Concrete.User;
using Okusana.Entities.Abstract;
using Okusana.Entities.Concrete;

namespace Okusana.Mapper.Extensions
{
    static public class MapperConverExtension
    {
        #region private generic converter methods
        private static IEnumerable<T> ConvertToEntity<T>(IEnumerable<IDTO> entity, IMapper mapper)
            where T : class, IEntity
            => mapper.Map<IEnumerable<T>>(entity);
        private static T ConvertToEntity<T>(IDTO entity, IMapper mapper)
            where T : class, IEntity
            => mapper.Map<T>(entity);

        private static IEnumerable<T> ConvertToDto<T>(IEnumerable<IEntity> entity, IMapper mapper)
            where T : class, IGetDTO
            => mapper.Map<IEnumerable<T>>(entity);
        private static T ConvertToDto<T>(IEntity entity, IMapper mapper)
            where T : class, IGetDTO
            => mapper.Map<T>(entity);
        #endregion

        #region Guid To entity
        public static IEnumerable<T> ConvertToEntityCustom<T>(this IEnumerable<Guid> entity, IMapper mapper)
            where T : class, IEntity
            => mapper.Map<IEnumerable<T>>(entity);

        public static T ConvertToEntityCustom<T>(this Guid entity, IMapper mapper)
            where T : class, IEntity
            => mapper.Map<T>(entity);
        #endregion

        #region Generic general convert methods
        public static IEnumerable<T> ConvertToEntityCustom<T>(this IEnumerable<IDTO> entity, IMapper mapper)
            where T : class, IEntity =>
            ConvertToEntity<T>(entity, mapper);
        public static T ConvertToEntityCustom<T>(this IDTO entity, IMapper mapper)
            where T : class, IEntity =>
            ConvertToEntity<T>(entity, mapper);

        public static IEnumerable<T> ConvertToDtoCustom<T>(this IEnumerable<IEntity> entity, IMapper mapper)
            where T : class, IGetDTO
            => ConvertToDto<T>(entity, mapper);
        public static T ConvertToDtoCustom<T>(this IEntity entity, IMapper mapper)
            where T : class, IGetDTO
            => ConvertToDto<T>(entity, mapper);

        public static IEnumerable<T> ConvertToEntityCustom<T>(this IEnumerable<int> entity, IMapper mapper)
            where T : class, IEntity
            => mapper.Map<IEnumerable<T>>(entity);

        public static T ConvertToEntityCustom<T>(this int entity, IMapper mapper)
            where T : class, IEntity
            => mapper.Map<T>(entity);
        #endregion

        #region Add Methods

        public static IEnumerable<Blog> ConvertToEntity(this IEnumerable<AddBlogDTO> entity, IMapper mapper)
        => ConvertToEntity<Blog>(entity, mapper);
        public static IEnumerable<Category> ConvertToEntity(this IEnumerable<AddCategoryDTO> entity, IMapper mapper)
        => ConvertToEntity<Category>(entity, mapper);
        public static IEnumerable<Comment> ConvertToEntity(this IEnumerable<AddCommentDTO> entity, IMapper mapper)
        => ConvertToEntity<Comment>(entity, mapper);
        public static IEnumerable<HashTag> ConvertToEntity(this IEnumerable<AddHashTagDTO> entity, IMapper mapper)
        => ConvertToEntity<HashTag>(entity, mapper);
        public static IEnumerable<SubCategory> ConvertToEntity(this IEnumerable<AddSubCategoryDTO> entity, IMapper mapper)
        => ConvertToEntity<SubCategory>(entity, mapper);
        public static IEnumerable<User> ConvertToEntity(this IEnumerable<AddUserDTO> entity, IMapper mapper)
        => ConvertToEntity<User>(entity, mapper);

        public static Blog ConvertToEntity(this AddBlogDTO entity, IMapper mapper)
        => ConvertToEntity<Blog>(entity, mapper);
        public static Category ConvertToEntity(this AddCategoryDTO entity, IMapper mapper)
        => ConvertToEntity<Category>(entity, mapper);
        public static Comment ConvertToEntity(this AddCommentDTO entity, IMapper mapper)
        => ConvertToEntity<Comment>(entity, mapper);
        public static HashTag ConvertToEntity(this AddHashTagDTO entity, IMapper mapper)
        => ConvertToEntity<HashTag>(entity, mapper);
        public static SubCategory ConvertToEntity(this AddSubCategoryDTO entity, IMapper mapper)
        => ConvertToEntity<SubCategory>(entity, mapper);
        public static User ConvertToEntity(this AddUserDTO entity, IMapper mapper)
        => ConvertToEntity<User>(entity, mapper);

        #endregion

        #region Update Methods

        public static IEnumerable<Blog> ConvertToEntity(this IEnumerable<UpdateBlogDTO> entity, IMapper mapper)
        => ConvertToEntity<Blog>(entity, mapper);
        public static IEnumerable<Category> ConvertToEntity(this IEnumerable<UpdateCategoryDTO> entity, IMapper mapper)
        => ConvertToEntity<Category>(entity, mapper);
        public static IEnumerable<Comment> ConvertToEntity(this IEnumerable<UpdateCommentDTO> entity, IMapper mapper)
        => ConvertToEntity<Comment>(entity, mapper);
        public static IEnumerable<HashTag> ConvertToEntity(this IEnumerable<UpdateHashTagDTO> entity, IMapper mapper)
        => ConvertToEntity<HashTag>(entity, mapper);
        public static IEnumerable<SubCategory> ConvertToEntity(this IEnumerable<UpdateSubCategoryDTO> entity, IMapper mapper)
        => ConvertToEntity<SubCategory>(entity, mapper);
        public static IEnumerable<User> ConvertToEntity(this IEnumerable<UpdateUserDTO> entity, IMapper mapper)
        => ConvertToEntity<User>(entity, mapper);

        public static Blog ConvertToEntity(this UpdateBlogDTO entity, IMapper mapper)
        => ConvertToEntity<Blog>(entity, mapper);
        public static Category ConvertToEntity(this UpdateCategoryDTO entity, IMapper mapper)
        => ConvertToEntity<Category>(entity, mapper);
        public static Comment ConvertToEntity(this UpdateCommentDTO entity, IMapper mapper)
        => ConvertToEntity<Comment>(entity, mapper);
        public static HashTag ConvertToEntity(this UpdateHashTagDTO entity, IMapper mapper)
        => ConvertToEntity<HashTag>(entity, mapper);
        public static SubCategory ConvertToEntity(this UpdateSubCategoryDTO entity, IMapper mapper)
        => ConvertToEntity<SubCategory>(entity, mapper);
        public static User ConvertToEntity(this UpdateUserDTO entity, IMapper mapper)
        => ConvertToEntity<User>(entity, mapper);

        #endregion

        #region Delete Methods

        public static IEnumerable<Blog> ConvertToEntity(this IEnumerable<DeleteBlogDTO> entity, IMapper mapper)
        => ConvertToEntity<Blog>(entity, mapper);
        public static IEnumerable<Category> ConvertToEntity(this IEnumerable<DeleteCategoryDTO> entity, IMapper mapper)
        => ConvertToEntity<Category>(entity, mapper);
        public static IEnumerable<Comment> ConvertToEntity(this IEnumerable<DeleteCommentDTO> entity, IMapper mapper)
        => ConvertToEntity<Comment>(entity, mapper);
        public static IEnumerable<HashTag> ConvertToEntity(this IEnumerable<DeleteHashTagDTO> entity, IMapper mapper)
        => ConvertToEntity<HashTag>(entity, mapper);
        public static IEnumerable<SubCategory> ConvertToEntity(this IEnumerable<DeleteSubCategoryDTO> entity, IMapper mapper)
        => ConvertToEntity<SubCategory>(entity, mapper);
        public static IEnumerable<User> ConvertToEntity(this IEnumerable<DeleteUserDTO> entity, IMapper mapper)
        => ConvertToEntity<User>(entity, mapper);

        public static Blog ConvertToEntity(this DeleteBlogDTO entity, IMapper mapper)
        => ConvertToEntity<Blog>(entity, mapper);
        public static Category ConvertToEntity(this DeleteCategoryDTO entity, IMapper mapper)
        => ConvertToEntity<Category>(entity, mapper);
        public static Comment ConvertToEntity(this DeleteCommentDTO entity, IMapper mapper)
        => ConvertToEntity<Comment>(entity, mapper);
        public static HashTag ConvertToEntity(this DeleteHashTagDTO entity, IMapper mapper)
        => ConvertToEntity<HashTag>(entity, mapper);
        public static SubCategory ConvertToEntity(this DeleteSubCategoryDTO entity, IMapper mapper)
        => ConvertToEntity<SubCategory>(entity, mapper);
        public static User ConvertToEntity(this DeleteUserDTO entity, IMapper mapper)
        => ConvertToEntity<User>(entity, mapper);

        #endregion

        #region Get Methods

        public static IEnumerable<GetBlogDTO> ConvertToEntity(this IEnumerable<Blog> entity, IMapper mapper)
        => ConvertToDto<GetBlogDTO>(entity, mapper);
        public static IEnumerable<GetCategoryDTO> ConvertToEntity(this IEnumerable<Category> entity, IMapper mapper)
        => ConvertToDto<GetCategoryDTO>(entity, mapper);
        public static IEnumerable<GetCommentDTO> ConvertToEntity(this IEnumerable<Comment> entity, IMapper mapper)
        => ConvertToDto<GetCommentDTO>(entity, mapper);
        public static IEnumerable<GetHashTagDTO> ConvertToEntity(this IEnumerable<HashTag> entity, IMapper mapper)
        => ConvertToDto<GetHashTagDTO>(entity, mapper);
        public static IEnumerable<GetSubCategoryDTO> ConvertToEntity(this IEnumerable<SubCategory> entity, IMapper mapper)
        => ConvertToDto<GetSubCategoryDTO>(entity, mapper);
        public static IEnumerable<GetUserDTO> ConvertToEntity(this IEnumerable<User> entity, IMapper mapper)
        => ConvertToDto<GetUserDTO>(entity, mapper);

        public static GetBlogDTO ConvertToEntity(this Blog entity, IMapper mapper)
        => ConvertToDto<GetBlogDTO>(entity, mapper);
        public static GetCategoryDTO ConvertToEntity(this Category entity, IMapper mapper)
        => ConvertToDto<GetCategoryDTO>(entity, mapper);
        public static GetCommentDTO ConvertToEntity(this Comment entity, IMapper mapper)
        => ConvertToDto<GetCommentDTO>(entity, mapper);
        public static GetHashTagDTO ConvertToEntity(this HashTag entity, IMapper mapper)
        => ConvertToDto<GetHashTagDTO>(entity, mapper);
        public static GetSubCategoryDTO ConvertToEntity(this SubCategory entity, IMapper mapper)
        => ConvertToDto<GetSubCategoryDTO>(entity, mapper);
        public static GetUserDTO ConvertToEntity(this User entity, IMapper mapper)
        => ConvertToDto<GetUserDTO>(entity, mapper);

        #endregion













    }
}
