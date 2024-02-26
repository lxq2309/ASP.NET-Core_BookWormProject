using System.ComponentModel.DataAnnotations;

namespace BookWormProject.ViewModels.Category
{
    public class CategoryCreateEditViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên danh mục!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Đường dẫn")]
        public string Link { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
    }
}
