using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using IPSAInventario.Models;

namespace IPSAInventario.Models
{
    public partial class InventarioDbcontext : DbContext
    {
        public InventarioDbcontext()
            : base("name=DBInventarioDbContext")
        {
        }

        public virtual DbSet<Auxiliar> Auxiliar { get; set; }
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<Computadora> Computadora { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Hardware> Hardware { get; set; }
        public virtual DbSet<Impresora> Impresora { get; set; }
        public virtual DbSet<Monitor> Monitor { get; set; }
        public virtual DbSet<Perifericos> Perifericos { get; set; }
        public virtual DbSet<Ranuras> Ranuras { get; set; }
        public virtual DbSet<Software> Software { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Computadora_Perifericos> Computadora_Perifericos { get; set; }
        public virtual DbSet<Factura_Detalle_Comp> Factura_Detalle_Comp { get; set; }
        public virtual DbSet<Factura_Detalle_Per> Factura_Detalle_Per { get; set; }
        public virtual DbSet<Factura_Detalle_Soft> Factura_Detalle_Soft { get; set; }
        public virtual DbSet<Ranura_Detalle_Hard> Ranura_Detalle_Hard { get; set; }
        public virtual DbSet<Ranura_Detalle_Per> Ranura_Detalle_Per { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auxiliar>()
                .Property(e => e.IDPeriferico)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Auxiliar>()
                .Property(e => e.IDAuxiliar)
                .IsUnicode(false);

            modelBuilder.Entity<Auxiliar>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Bitacora>()
                .Property(e => e.Codigo_PC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bitacora>()
                .Property(e => e.Expediente)
                .IsUnicode(false);

            modelBuilder.Entity<Bitacora>()
                .Property(e => e.Falla_Reportada)
                .IsUnicode(false);

            modelBuilder.Entity<Bitacora>()
                .Property(e => e.Que_Presenta)
                .IsUnicode(false);

            modelBuilder.Entity<Bitacora>()
                .Property(e => e.Causa)
                .IsUnicode(false);

            modelBuilder.Entity<Bitacora>()
                .Property(e => e.Accion)
                .IsUnicode(false);

            modelBuilder.Entity<Bitacora>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Bitacora>()
                .Property(e => e.Reporto)
                .IsUnicode(false);

            modelBuilder.Entity<Bitacora>()
                .Property(e => e.Atendio)
                .IsUnicode(false);

            modelBuilder.Entity<Bitacora>()
                .Property(e => e.Ubicacion)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .Property(e => e.Codigo_PC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .Property(e => e.Aplicacion)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .Property(e => e.Expediente)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .Property(e => e.Maquina)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .Property(e => e.IPV4)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .Property(e => e.Mascara_IPV4)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .Property(e => e.IPV6)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .Property(e => e.Mascara_IPV6)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .Property(e => e.Internet)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .Property(e => e.Tipo_Computador)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora>()
                .HasMany(e => e.Factura_Detalle_Comp)
                .WithRequired(e => e.Computadora)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Computadora>()
                .HasMany(e => e.Computadora_Perifericos)
                .WithRequired(e => e.Computadora)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Computadora>()
                .HasMany(e => e.Ranuras)
                .WithRequired(e => e.Computadora)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Factura>()
                .Property(e => e.Vendedor)
                .IsUnicode(false);

            modelBuilder.Entity<Factura>()
                .HasMany(e => e.Factura_Detalle_Comp)
                .WithRequired(e => e.Factura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Factura>()
                .HasMany(e => e.Factura_Detalle_Per)
                .WithRequired(e => e.Factura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Factura>()
                .HasMany(e => e.Factura_Detalle_Soft)
                .WithRequired(e => e.Factura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hardware>()
                .Property(e => e.Unidad_Med)
                .IsUnicode(false);

            modelBuilder.Entity<Hardware>()
                .HasMany(e => e.Ranura_Detalle_Hard)
                .WithRequired(e => e.Hardware)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Impresora>()
                .Property(e => e.IDPeriferico)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Impresora>()
                .Property(e => e.IDImpresora)
                .IsUnicode(false);

            modelBuilder.Entity<Impresora>()
                .Property(e => e.Cart_Negro)
                .IsUnicode(false);

            modelBuilder.Entity<Impresora>()
                .Property(e => e.Cart_Color)
                .IsUnicode(false);

            modelBuilder.Entity<Impresora>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Impresora>()
                .Property(e => e.Tipo_Imp)
                .IsUnicode(false);

            modelBuilder.Entity<Impresora>()
                .Property(e => e.Responsable)
                .IsUnicode(false);

            modelBuilder.Entity<Monitor>()
                .Property(e => e.IDPeriferico)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Monitor>()
                .Property(e => e.IDMonitor)
                .IsUnicode(false);

            modelBuilder.Entity<Monitor>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Monitor>()
                .Property(e => e.Unidad_Med)
                .IsUnicode(false);

            modelBuilder.Entity<Perifericos>()
                .Property(e => e.IDPeriferico)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Perifericos>()
                .Property(e => e.Marca)
                .IsUnicode(false);

            modelBuilder.Entity<Perifericos>()
                .Property(e => e.Modelo)
                .IsUnicode(false);

            modelBuilder.Entity<Perifericos>()
                .Property(e => e.NoSerie)
                .IsUnicode(false);

            modelBuilder.Entity<Perifericos>()
                .Property(e => e.Aplicacion)
                .IsUnicode(false);

            modelBuilder.Entity<Perifericos>()
                .Property(e => e.Expediente)
                .IsUnicode(false);

            modelBuilder.Entity<Perifericos>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Perifericos>()
                .Property(e => e.Tipo_Periferico)
                .IsUnicode(false);

            modelBuilder.Entity<Perifericos>()
                .HasOptional(e => e.Auxiliar)
                .WithRequired(e => e.Perifericos);

            modelBuilder.Entity<Perifericos>()
                .HasOptional(e => e.Impresora)
                .WithRequired(e => e.Perifericos);

            modelBuilder.Entity<Perifericos>()
                .HasOptional(e => e.Monitor)
                .WithRequired(e => e.Perifericos);

            modelBuilder.Entity<Perifericos>()
                .HasMany(e => e.Computadora_Perifericos)
                .WithRequired(e => e.Perifericos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perifericos>()
                .HasMany(e => e.Factura_Detalle_Per)
                .WithRequired(e => e.Perifericos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perifericos>()
                .HasMany(e => e.Ranura_Detalle_Per)
                .WithRequired(e => e.Perifericos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ranuras>()
                .Property(e => e.Codigo_PC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ranuras>()
                .Property(e => e.Tipo_Slot)
                .IsUnicode(false);

            modelBuilder.Entity<Ranuras>()
                .HasMany(e => e.Ranura_Detalle_Hard)
                .WithRequired(e => e.Ranuras)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ranuras>()
                .HasMany(e => e.Ranura_Detalle_Per)
                .WithRequired(e => e.Ranuras)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Software>()
                .Property(e => e.Product_Key)
                .IsUnicode(false);

            modelBuilder.Entity<Software>()
                .Property(e => e.Tipo_Lic)
                .IsUnicode(false);

            modelBuilder.Entity<Software>()
                .Property(e => e.Licencia)
                .IsUnicode(false);

            modelBuilder.Entity<Software>()
                .Property(e => e.Num_Licencia)
                .IsUnicode(false);

            modelBuilder.Entity<Software>()
                .Property(e => e.License_Pack_Bar_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Software>()
                .Property(e => e.Certificado)
                .IsUnicode(false);

            modelBuilder.Entity<Software>()
                .Property(e => e.AGMT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Software>()
                .Property(e => e.Activa)
                .IsUnicode(false);

            modelBuilder.Entity<Software>()
                .Property(e => e.Cantidad)
                .IsUnicode(false);

            modelBuilder.Entity<Software>()
                .HasMany(e => e.Factura_Detalle_Soft)
                .WithRequired(e => e.Software)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Computadora_Perifericos>()
                .Property(e => e.IDPeriferico)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Computadora_Perifericos>()
                .Property(e => e.Codigo_PC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Computadora_Perifericos>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora_Perifericos>()
                .Property(e => e.Ubicacion_Act)
                .IsUnicode(false);

            modelBuilder.Entity<Computadora_Perifericos>()
                .Property(e => e.Status_)
                .IsUnicode(false);

            modelBuilder.Entity<Factura_Detalle_Comp>()
                .Property(e => e.Codigo_PC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Factura_Detalle_Comp>()
                .Property(e => e.Responsable)
                .IsUnicode(false);

            modelBuilder.Entity<Factura_Detalle_Per>()
                .Property(e => e.IDPeriferico)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Factura_Detalle_Per>()
                .Property(e => e.Responsable)
                .IsUnicode(false);

            modelBuilder.Entity<Factura_Detalle_Soft>()
                .Property(e => e.Responsable)
                .IsUnicode(false);

            modelBuilder.Entity<Ranura_Detalle_Hard>()
                .Property(e => e.Responsable)
                .IsUnicode(false);

            modelBuilder.Entity<Ranura_Detalle_Per>()
                .Property(e => e.IDPeriferico)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ranura_Detalle_Per>()
                .Property(e => e.Responsable)
                .IsUnicode(false);
        }
    }
}
