using System.ComponentModel.DataAnnotations.Schema;

namespace AG.Yonetim.MVC.Data.Entities
{
    public class Bill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
        
    }
}
