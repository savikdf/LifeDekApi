using LifeDekApi.Dtos;
using System;
using System.Collections.Generic;

namespace LifeDekApi.Models
{
    public partial class User
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreateDate { get; set; }

        public override string ToString() => $"{FirstName} {LastName}. GUID:{Guid.ToString()}.{Environment.NewLine}Create on {CreateDate.ToString("mm-dd-yyyy")}";

        public static implicit operator UserDto(User u) => new UserDto()
        {
            Guid = u.Guid,  
            FirstName = u.FirstName,
            LastName = u.LastName,
            CreateDate = u.CreateDate,
        };
        public static explicit operator User(UserDto u) => new User()
        {
            Guid = u.Guid,
            FirstName = u.FirstName,
            LastName = u.LastName,
            CreateDate = u.CreateDate,
        };
    }
}
