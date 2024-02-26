using System.ComponentModel.DataAnnotations;

namespace BookWormProject.ViewModels.Genre
{
    public class GenreCreateEditViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên thể loại")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả về thể loại")]
        public string Description { get; set; }
        public int GenreId { get; set; }
    }
}
