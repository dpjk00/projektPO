﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektWPF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SZKOŁA_PODSTAWOWAEntities : DbContext
    {
        public SZKOŁA_PODSTAWOWAEntities()
            : base("name=SZKOŁA_PODSTAWOWAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Klasy> Klasies { get; set; }
        public virtual DbSet<Nauczyciele> Nauczycieles { get; set; }
        public virtual DbSet<Przedmioty> Przedmioties { get; set; }
        public virtual DbSet<Uczniowie> Uczniowies { get; set; }
        public virtual DbSet<Wycieczki> Wycieczkis { get; set; }
        public virtual DbSet<ZadaniaDomowe> ZadaniaDomowes { get; set; }
    }
}