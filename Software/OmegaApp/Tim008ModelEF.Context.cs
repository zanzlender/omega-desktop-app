﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Omega
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PI20_008_DBEntities2 : DbContext
    {
        public PI20_008_DBEntities2()
            : base("name=PI20_008_DBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FAQ> FAQ { get; set; }
        public virtual DbSet<Natjecaj> Natjecaj { get; set; }
        public virtual DbSet<PredloziKolegu> PredloziKolegu { get; set; }
        public virtual DbSet<RadnoMjesto> RadnoMjesto { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipPrijave> TipPrijave { get; set; }
        public virtual DbSet<UputeZaRad> UputeZaRad { get; set; }
        public virtual DbSet<Obrasci> Obrasci { get; set; }
        public virtual DbSet<StrateskiDokumenti> StrateskiDokumenti { get; set; }
    }
}