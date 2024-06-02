using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SVC.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        [Column(TypeName = "text")]
        public string Gist { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
    }
}
