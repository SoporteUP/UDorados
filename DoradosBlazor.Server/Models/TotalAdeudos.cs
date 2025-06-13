using System.ComponentModel.DataAnnotations;
namespace DoradosBlazor.Server.Models
{
    public class TotalAdeudos
    {
        [Key]
        public double TotalNeto { get; set; }
    }
}
