using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Abstract
{
    public interface IDeleteDTO : IDTO
    {
        public Guid Id { get; set; }
    }
}
