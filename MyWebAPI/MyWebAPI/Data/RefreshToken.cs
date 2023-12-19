﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPI.Data
{
    [Table("RefreshToken")]
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public NguoiDung NguoiDung { get; set; }

        public string Token { get; set; }

        public string JwtId { get; set; }

        public bool IsUsed { get; set; }

        public bool IsRevoked { get; set; }
        public DateTime IssueAt { get; set; }
        public DateTime ExpiredAt { get; set; }

    }
}
