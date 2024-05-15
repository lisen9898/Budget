using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.Models;

public class Transaction
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Transactions Name")]
    [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; }

    [Range(0, 1000000)]
    [Display(Name = "Amount (RMB)")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Transactions Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Column(TypeName = "date")] /*删除测试有用*/
    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}