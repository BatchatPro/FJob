using System.ComponentModel.DataAnnotations;

namespace FJob.Shared;

public class CategoryDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage ="This poly is required.")]
    public string Title { get; set; }
    [Required(ErrorMessage = "This poly is required.")]
    public string Descrtiption { get; set; }
}
