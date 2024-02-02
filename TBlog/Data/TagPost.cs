using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBlog.Data
{
    public class TagPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TPId { get; set; }
        [Required]
        [ForeignKey("Tag")]
        public int TId { get; set; }

        [Required]
        [ForeignKey("Post")]
        public int PId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Post Post { get; set; }

    }
}