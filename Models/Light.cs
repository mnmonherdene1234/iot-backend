using System.ComponentModel.DataAnnotations;

namespace IOTBackend.Models
{
    public class Light
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsOn { get; set; }
    }
}
