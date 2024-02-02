using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBlog.Data
{
    public class Site
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SId { get; set; }
        [Required]
        public string SName { get; set; }
        [Required]
        public string SPersianName { get; set; }
        [Required]
        [Url]
        public string SLink {get; set; }
        [Required]
        public string SPic {get; set; }

        
    }
}