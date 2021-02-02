namespace KarTech.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class GPU
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        public double Rank { get; set; }

        public double Benchmark { get; set; }
    }
}
