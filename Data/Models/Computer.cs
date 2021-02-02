using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KarTech.Data.Models
{
    public class Computer
    {
        public Computer()
        {
            this.Storages = new HashSet<Storage>();
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public CPU CPU { get; set; }

        [Required]
        public GPU GPU { get; set; }

        [Required]
        public Ram Ram { get; set; }

        public double Price { get; set; }

        public bool IsLaptop { get; set; }

        [Required]
        public string Url { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
