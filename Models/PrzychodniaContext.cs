using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class PrzychodniaContext : DbContext
    {
        public PrzychodniaContext()
        {
        }

        public PrzychodniaContext(DbContextOptions<PrzychodniaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Choroby> Chorobies { get; set; }
        public virtual DbSet<Gabinet> Gabinets { get; set; }
        public virtual DbSet<Lekarze> Lekarzes { get; set; }
        public virtual DbSet<Pacjenci> Pacjencis { get; set; }
        public virtual DbSet<PersonelCdn> PersonelCdns { get; set; }
        public virtual DbSet<Pracownicy> Pracownicies { get; set; }
        public virtual DbSet<Recepty> Recepties { get; set; }
        public virtual DbSet<Specjalizacja> Specjalizacjas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Przychodnia;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Choroby>(entity =>
            {
                entity.HasKey(e => new { e.IdChoroby, e.IdPracownika, e.IdPacjenta })
                    .HasName("PK_Choroby_1");

                entity.ToTable("Choroby");

                entity.Property(e => e.IdChoroby).HasColumnName("id_choroby");

                entity.Property(e => e.IdPracownika).HasColumnName("id_pracownika");

                entity.Property(e => e.IdPacjenta).HasColumnName("id_pacjenta");

                entity.Property(e => e.IdRecepty).HasColumnName("id_recepty");

                entity.Property(e => e.PrzebiegChoroby)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("przebieg_choroby");

                entity.HasOne(d => d.IdPacjentaNavigation)
                    .WithMany(p => p.Chorobies)
                    .HasForeignKey(d => d.IdPacjenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Choroby_Pacjenci");

                entity.HasOne(d => d.IdPracownikaNavigation)
                    .WithMany(p => p.Chorobies)
                    .HasForeignKey(d => d.IdPracownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Choroby_Lekarze");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Chorobies)
                    .HasForeignKey(d => new { d.IdChoroby, d.IdRecepty })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Choroby_Recepty");
            });

            modelBuilder.Entity<Gabinet>(entity =>
            {
                entity.HasKey(e => e.NumerGabinetu);

                entity.ToTable("Gabinet");

                entity.Property(e => e.NumerGabinetu)
                    .ValueGeneratedNever()
                    .HasColumnName("numer_gabinetu");

                entity.Property(e => e.DupaJasia)
                    .HasMaxLength(10)
                    .HasColumnName("dupa jasia")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Lekarze>(entity =>
            {
                entity.HasKey(e => e.IdPracownika);

                entity.ToTable("Lekarze");

                entity.Property(e => e.IdPracownika)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pracownika");

                entity.Property(e => e.NumerGabinetu).HasColumnName("numer_gabinetu");

                entity.Property(e => e.Specjalizacja)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("specjalizacja");

                entity.HasOne(d => d.IdPracownikaNavigation)
                    .WithOne(p => p.Lekarze)
                    .HasForeignKey<Lekarze>(d => d.IdPracownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lekarze_Pracownicy");

                entity.HasOne(d => d.NumerGabinetuNavigation)
                    .WithMany(p => p.Lekarzes)
                    .HasForeignKey(d => d.NumerGabinetu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lekarze_Gabinet");

                entity.HasOne(d => d.SpecjalizacjaNavigation)
                    .WithMany(p => p.Lekarzes)
                    .HasForeignKey(d => d.Specjalizacja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lekarze_Specjalizacja");
            });

            modelBuilder.Entity<Pacjenci>(entity =>
            {
                entity.HasKey(e => e.IdPacjenta);

                entity.ToTable("Pacjenci");

                entity.Property(e => e.IdPacjenta).HasColumnName("id_pacjenta");

                entity.Property(e => e.AdresZamieszkania)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("adres_zamieszkania");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("imie");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("pesel")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PersonelCdn>(entity =>
            {
                entity.ToTable("personel cdn");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnType("date")
                    .HasColumnName("Data_Urodzenia");

                entity.Property(e => e.DataZatrudnienia)
                    .HasColumnType("date")
                    .HasColumnName("Data_Zatrudnienia");

                entity.Property(e => e.Imię)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MiejsceZamieszkania)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Miejsce_Zamieszkania");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ulica)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pracownicy>(entity =>
            {
                entity.HasKey(e => e.IdPracownika);

                entity.ToTable("Pracownicy");

                entity.Property(e => e.IdPracownika).HasColumnName("id_pracownika");

                entity.Property(e => e.AdresZamieszkania)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("adres_zamieszkania");

                entity.Property(e => e.DataZatrudnienia)
                    .HasColumnType("date")
                    .HasColumnName("data_zatrudnienia");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("imie");

                entity.Property(e => e.KoniecKontraktu)
                    .HasColumnType("date")
                    .HasColumnName("koniec_kontraktu");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("pesel")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Recepty>(entity =>
            {
                entity.HasKey(e => new { e.IdChoroby, e.IdRecepty });

                entity.ToTable("Recepty");

                entity.Property(e => e.IdChoroby).HasColumnName("id_choroby");

                entity.Property(e => e.IdRecepty)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_recepty");

                entity.Property(e => e.DataWystawienia)
                    .HasColumnType("date")
                    .HasColumnName("data_wystawienia");

                entity.Property(e => e.Lek)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lek");
            });

            modelBuilder.Entity<Specjalizacja>(entity =>
            {
                entity.HasKey(e => e.Specjalizacja1);

                entity.ToTable("Specjalizacja");

                entity.Property(e => e.Specjalizacja1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("specjalizacja");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
