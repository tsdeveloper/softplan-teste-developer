﻿namespace Core.Entities
{
    public class TaxaJuro : BaseEntity
    {
        public decimal ValorJuro { get; set; }
        public decimal ValorInicial { get; set; }
        public int Tempo { get; set; }
        public string ValorFinal { get; set; }
       
    }
}