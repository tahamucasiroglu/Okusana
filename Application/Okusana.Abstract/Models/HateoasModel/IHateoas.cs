using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Abstract.Models.HateoasModel
{
    public interface IHateoas
    {
        public Dictionary<string, List<string>> Links { get; }
        public Dictionary<string, Dictionary<string, string>> Methods { get; }
    }
}
