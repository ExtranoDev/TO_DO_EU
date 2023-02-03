using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoEU.Models.DTO
{
    public class ToDoItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Activity Field is required")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Activity")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Description")]
        public string ItemDescription { get; set; }

        [Required(ErrorMessage = "ItemStatus is required")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Status")]
        public string ItemStatus { get; set; }
        [Required]
        public string? userId { get; set; }
    }
}
