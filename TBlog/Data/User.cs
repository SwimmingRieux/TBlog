using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace TBlog.Data
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UId { get; set; }
        [MaxLength(30)]
        [Required]
        public string UName {get; set;}
        [Required]
        [MinLength(6)]
        [MaxLength(24)]
        public string UPass{get; set;}
        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string UMail {get; set;}
        [Required]
        public string UIP {get; set;}
        [MinLength(10)]
        [MaxLength(200)]
        public string UBio {get; set;}
        [Required]
        public string URegDate{get; set;}
        public string UPic {get; set;}
        
    }
}