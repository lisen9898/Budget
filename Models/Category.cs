using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Category Name")]
    [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; }

    public ICollection<Transaction> Transactions { get; set; }
}