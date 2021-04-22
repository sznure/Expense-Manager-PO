using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{

    public enum Categories { Sport, Elektronika, Dom, Transport, Jedzenie };
    
    [Table("Table_2")]
    
    public class ExpenseModel
    {   [Key]
        public int ExpenseId { get; set; }

        [Required(ErrorMessage = "Pole nazwa jest wymagane.")]
        [DisplayName("Nazwa")]
        [MaxLength(50)]
        public string Name { get; set; } 
        
        [DisplayName("Opis")]
        [MaxLength(2000)]
        public string Description { get; set; } 
        
        [DisplayName("Kwota [PLN]")]
        /*DataType(DataType.Currency)]*/
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [Required]
        [DisplayName("Data")]
        public DateTime? Date { get; set; }

        [Required]
        [DisplayName("Kategoria")]
        public int Category { get; set; }


    }
}
