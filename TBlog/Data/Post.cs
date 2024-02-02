using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TBlog.Data
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Required]
        [ForeignKey("Site")]
        public int PSId { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int PCId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int PUId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Site Site { get; set; }
        public virtual User User { get; set; }
        [Required]
        [MaxLength(120)]
        public string PTitle { get; set; }
        [Required]
        public string PText { get; set; }
        [MaxLength(120)]
        public string PSubtitle { get; set; }
        [Required]
        public string PDate { get; set; }
        [Required]
        public string PTDate { get; set; }
        [Required]
        public string PPicture { get; set; }
        [Required]
        public int PType { get; set; }
        public string PAudio { get; set; }
        [Required]
        [Url]
        public string PLink { get; set; }
        public int PViews { get; set; }
        public int PLikes { get; set; }
        [Required]
        public int PMins { get; set; }
        [Required]
        public bool PShow { get; set; }
        public bool PChecked {get; set;}

    }
}