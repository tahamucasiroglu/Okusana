using AutoMapper;
using Okusana.DTOs.Concrete.Blog;
using Okusana.DTOs.Concrete.Category;
using Okusana.DTOs.Concrete.Comment;
using Okusana.DTOs.Concrete.HashTag;
using Okusana.DTOs.Concrete.SubCategory;
using Okusana.DTOs.Concrete.User;
using Okusana.Entities.Concrete;
using Okusana.Mapper.Extensions;

namespace Okusana.Mapper.MapProfile
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {
            CreateMap<AddBlogDTO, Blog>().DefaultAddMapConfig();
            CreateMap<AddCategoryDTO, Category>().DefaultAddMapConfig();
            CreateMap<AddCommentDTO, Comment>().DefaultAddMapConfig();
            CreateMap<AddHashTagDTO, HashTag>().DefaultAddMapConfig();
            CreateMap<AddSubCategoryDTO, SubCategory>().DefaultAddMapConfig();
            CreateMap<AddUserDTO, User>().DefaultAddMapConfig();

            CreateMap<UpdateBlogDTO, Blog>().DefaultUpdateMapConfig();
            CreateMap<UpdateCategoryDTO, Category>().DefaultUpdateMapConfig();
            CreateMap<UpdateCommentDTO, Comment>().DefaultUpdateMapConfig();
            CreateMap<UpdateHashTagDTO, HashTag>().DefaultUpdateMapConfig();
            CreateMap<UpdateSubCategoryDTO, SubCategory>().DefaultUpdateMapConfig();
            CreateMap<UpdateUserDTO, User>().DefaultUpdateMapConfig();

            CreateMap<DeleteBlogDTO, Blog>().DefaultDeleteMapConfig();
            CreateMap<DeleteCategoryDTO, Category>().DefaultDeleteMapConfig();
            CreateMap<DeleteCommentDTO, Comment>().DefaultDeleteMapConfig();
            CreateMap<DeleteHashTagDTO, HashTag>().DefaultDeleteMapConfig();
            CreateMap<DeleteSubCategoryDTO, SubCategory>().DefaultDeleteMapConfig();
            CreateMap<DeleteUserDTO, User>().DefaultDeleteMapConfig();

            CreateMap<Blog, GetBlogDTO>();
            CreateMap<Category, GetCategoryDTO>();
            CreateMap<Comment, GetCommentDTO>();
            CreateMap<HashTag, GetHashTagDTO>();
            CreateMap<SubCategory, GetSubCategoryDTO>();
            CreateMap<User, GetUserDTO>();
        }
    }
}
