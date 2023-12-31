﻿using Okusana.DTOs.Base;


namespace Okusana.DTOs.Concrete.HashTag
{
    public sealed record AddHashTagDTO : AddDTO
    {
        public string Name { get; init; } = null!;
    }
}
