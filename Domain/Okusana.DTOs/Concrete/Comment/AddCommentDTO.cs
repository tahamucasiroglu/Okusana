using Okusana.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Concrete.Comment
{
    public class AddCommentDTO : AddDTO
    {
        public Guid BlogId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = null!;
        public int? Rate { get; set; }
        public bool IsLike { get; set; }
    }
}
