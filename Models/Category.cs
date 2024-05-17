using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.Models;

public class Category
{
    public int Id { get; set; }

    [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; }

    public ICollection<Transaction> Transactions { get; set; }
}