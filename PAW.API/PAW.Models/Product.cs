using System.ComponentModel.DataAnnotations.Schema;

namespace PAW.Models
{
    public partial class Product
    {
        [NotMapped]
        public string UniqueID { get; set; }
    }
}
