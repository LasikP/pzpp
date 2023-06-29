using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nartyy.Models
{
    
    public class ButyNarciarskie
    {
        [Key]
        public int IDButyNarciarskie { get; set; }
        public string? Nazwa { get; set; }
        public string? Opis { get; set; }
        public string? Producent { get; set; }
        public string? Kolor { get; set; }
        public int? Rozmiar { get; set; }
        public decimal? CenaGodzinowa { get; set; }
        public bool? Dostepnosc { get; set; }
        public byte[]? Zdjecie { get; set; }

        [ForeignKey("Rezerwacja")]
        public int? IDRezerwacji { get; set; }
        public Rezerwacja Rezerwacja { get; set; }

    }
}
