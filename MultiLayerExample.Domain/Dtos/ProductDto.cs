﻿namespace MultiLayerExample.Domain.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
