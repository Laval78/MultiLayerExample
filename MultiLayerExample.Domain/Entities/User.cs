﻿namespace MultiLayerExample.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public ICollection<Order>? Orders { get; set; }
    }
}
