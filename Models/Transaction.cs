using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Budget.Models;

public class Transaction
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Type")]
    public bool IsIncome { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "The {0} must be a positive number.")]
    [DataType(DataType.Currency)]
    [Precision(18,2)]
    public decimal Amount { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM月dd日 dddd}", ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }

    [StringLength(100, ErrorMessage = "The {0} must be at most {1} characters long.")]
    [Column(TypeName = "varchar(100)")]
    public string Description { get; set; }

    [Required]
    public Category Category { get; set; }
}