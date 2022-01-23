using LifeDekApi.Dtos;
using System;
using System.Collections.Generic;

namespace LifeDekApi.Models
{
    public partial class Card
    {
        public Guid Guid { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }


        public override string ToString() => $"Card named '{Name}', belongs to UserID: {UserId}.{Environment.NewLine}Create on {CreateDate.ToString("mm-dd-yyyy")}";

        public static implicit operator CardDto(Card c) => new CardDto()
        {
            Guid = c.Guid,
            UserId = c.UserId,
            Name = c.Name,
            Description = c.Description,
            CreateDate = c.CreateDate,
        };
        public static explicit operator Card(CardDto c) => new Card()
        {
            Guid = c.Guid,
            UserId = c.UserId,
            Name = c.Name,
            Description = c.Description,
            CreateDate = c.CreateDate,
        };
    }
}
