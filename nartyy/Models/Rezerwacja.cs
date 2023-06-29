using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace nartyy.Models
{
    public class Rezerwacja
    {
        [Key]
        public int IDSprzet { get; set; }

        public string? TypSprzetu { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DataOdbioru { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DataZwrotu { get; set; }

        [ForeignKey("Client")]
        public int? IDClient { get; set; }
        public Client Client { get; set; }

        public virtual  ICollection<Narty> Sprzet_Narty{ get; set; }

        public virtual ICollection<ButyNarciarskie> Sprzet_Buty { get; set; }

        
    }
}

