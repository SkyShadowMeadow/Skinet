using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class BaseEntity
    {
        public int Id {get; set;}
        
         [Required] // Ensure that the Name property is required
        public string Name {get; set;}
    }
}