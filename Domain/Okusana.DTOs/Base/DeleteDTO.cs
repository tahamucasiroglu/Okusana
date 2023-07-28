﻿using Okusana.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Base
{
    abstract public class DeleteDTO : DTO, IDeleteDTO
    {
        public Guid Id { get; set; }
    }
}