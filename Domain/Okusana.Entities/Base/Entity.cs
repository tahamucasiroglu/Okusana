using Okusana.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Entities.Base
{
    abstract public class Entity : IEntity
    {
        public Guid Id { get; set; }

    }
}
