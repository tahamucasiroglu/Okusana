using Okusana.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Concrete.Blog
{
    public class AddBlogDTO : AddDTO
    {
        public Guid UserId { get; set; }
        public Guid SubCategoryId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? PublicationDate { get; set; }
        public bool IsPublished { get; set; }
    }
}
