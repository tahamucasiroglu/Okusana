﻿using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.Category
{
    public sealed record UpdateCategoryDTO : UpdateDTO
    {
        public string Name { get; init; } = null!;
        public string? Description { get; init; }
    }
}
