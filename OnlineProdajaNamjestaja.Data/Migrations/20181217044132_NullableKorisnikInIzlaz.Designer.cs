﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OnlineProdajaNamjestaja.Data;
using System;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    [DbContext(typeof(MojContext))]
    [Migration("20181217044132_NullableKorisnikInIzlaz")]
    partial class NullableKorisnikInIzlaz
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.AkcijskiKatalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumPocetka");

                    b.Property<DateTime>("DatumZavrsetka");

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.ToTable("AkcijskiKatalog");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Boja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Boja");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Dostava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cijena");

                    b.Property<string>("Opis");

                    b.Property<string>("Tip");

                    b.HasKey("Id");

                    b.ToTable("Dostava");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Dostavljac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Naziv");

                    b.Property<string>("Telefon");

                    b.Property<string>("ZiroRacun");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Dostavljac");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Izlaz", b =>
                {
                    b.Property<int>("NarudzbaId");

                    b.Property<string>("BrojNarudzbe");

                    b.Property<DateTime>("Datum");

                    b.Property<decimal>("IznosBezPDV");

                    b.Property<decimal>("IznosSaPDV");

                    b.Property<int?>("KorisnikId");

                    b.Property<int>("SkladisteId");

                    b.Property<bool>("Zakljucena");

                    b.HasKey("NarudzbaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("Izlaz");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.IzlazStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cijena");

                    b.Property<int>("IzlazId");

                    b.Property<int>("Kolicina");

                    b.Property<int>("Popust");

                    b.Property<int>("ProizvodId");

                    b.HasKey("Id");

                    b.HasIndex("IzlazId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("IzlaziStavka");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Kanton", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Kanton");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.KatalogStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AkcijskiKatalogId");

                    b.Property<int>("PopustProcent");

                    b.Property<int>("ProizvodId");

                    b.HasKey("Id");

                    b.HasIndex("AkcijskiKatalogId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("KatalogStavka");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Komentar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int>("KupacId");

                    b.Property<int>("ProizvodId");

                    b.Property<string>("Sadrzaj");

                    b.HasKey("Id");

                    b.HasIndex("KupacId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("Komentar");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Lozinka");

                    b.Property<int>("OpstinaId");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.Property<int>("UlogaId");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("KorisnickoIme")
                        .IsUnique()
                        .HasFilter("[KorisnickoIme] IS NOT NULL");

                    b.HasIndex("Lozinka")
                        .IsUnique()
                        .HasFilter("[Lozinka] IS NOT NULL");

                    b.HasIndex("OpstinaId");

                    b.HasIndex("UlogaId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Kupac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Lozinka");

                    b.Property<string>("Prezime");

                    b.Property<string>("Spol");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("KorisnickoIme")
                        .IsUnique()
                        .HasFilter("[KorisnickoIme] IS NOT NULL");

                    b.HasIndex("Lozinka")
                        .IsUnique()
                        .HasFilter("[Lozinka] IS NOT NULL");

                    b.ToTable("Kupac");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Akcija");

                    b.Property<int>("KupacId");

                    b.Property<DateTime>("Vrijeme");

                    b.HasKey("Id");

                    b.HasIndex("KupacId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojNarudzbe");

                    b.Property<DateTime>("Datum");

                    b.Property<int?>("DostavaId");

                    b.Property<int>("KupacId");

                    b.Property<bool>("Otkazano");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DostavaId");

                    b.HasIndex("KupacId");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.NarudzbaDostava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DostavaId");

                    b.Property<int>("NarudzbaId");

                    b.HasKey("Id");

                    b.HasIndex("DostavaId");

                    b.HasIndex("NarudzbaId");

                    b.ToTable("NarudzbaDostava");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.NarudzbaStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BojaId");

                    b.Property<int>("Kolicina");

                    b.Property<int>("NarudzbaId");

                    b.Property<int>("ProizvodId");

                    b.HasKey("Id");

                    b.HasIndex("BojaId");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("NarudzbaStavka");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Ocjena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int>("KupacId");

                    b.Property<int>("Ocjena_Br");

                    b.Property<int>("ProizvodId");

                    b.HasKey("Id");

                    b.HasIndex("KupacId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("Ocjena");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Opstina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KantonId");

                    b.Property<string>("Naziv");

                    b.Property<string>("PostanskiBroj");

                    b.HasKey("Id");

                    b.HasIndex("KantonId");

                    b.ToTable("Opstina");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cijena");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Sifra");

                    b.Property<string>("Slika");

                    b.Property<int>("VrstaProizvodaId");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("Sifra")
                        .IsUnique()
                        .HasFilter("[Sifra] IS NOT NULL");

                    b.HasIndex("VrstaProizvodaId");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.ProizvodBoja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BojaId");

                    b.Property<int>("ProizvodId");

                    b.HasKey("Id");

                    b.HasIndex("BojaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("ProizvodBoja");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.ProizvodSkladiste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Kolicina");

                    b.Property<int>("ProizvodId");

                    b.Property<int>("SkladisteId");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("ProizvodSkladiste");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.RadniNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int>("DostavljacId");

                    b.Property<int?>("NarudzbaId");

                    b.HasKey("Id");

                    b.HasIndex("DostavljacId");

                    b.HasIndex("NarudzbaId");

                    b.ToTable("RadniNalog");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Skladiste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<int?>("KorisnikId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Skladiste");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Ulaz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojFakture");

                    b.Property<DateTime>("Datum");

                    b.Property<decimal>("IznosRacuna");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Napomena");

                    b.Property<decimal>("PDV");

                    b.Property<int>("SkladisteId");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("Ulaz");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.UlazStavke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cijena");

                    b.Property<int>("Kolicina");

                    b.Property<int>("ProizvodId");

                    b.Property<int>("UlazId");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodId");

                    b.HasIndex("UlazId");

                    b.ToTable("UlazStavke");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Uloga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TipUloge");

                    b.HasKey("Id");

                    b.ToTable("Uloga");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.VrstaProizvoda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("VrstaProizvoda");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Izlaz", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Narudzba", "Narudzba")
                        .WithOne("Izlaz")
                        .HasForeignKey("OnlineProdajaNamjestaja.Data.Models.Izlaz", "NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Skladiste", "Skladiste")
                        .WithMany()
                        .HasForeignKey("SkladisteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.IzlazStavka", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Izlaz", "Izlaz")
                        .WithMany()
                        .HasForeignKey("IzlazId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Kanton", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.KatalogStavka", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.AkcijskiKatalog", "AkcijskiKatalog")
                        .WithMany()
                        .HasForeignKey("AkcijskiKatalogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Komentar", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Korisnik", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Opstina", "Opstina")
                        .WithMany()
                        .HasForeignKey("OpstinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Uloga", "Uloga")
                        .WithMany()
                        .HasForeignKey("UlogaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Log", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Narudzba", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Dostava", "Dostava")
                        .WithMany()
                        .HasForeignKey("DostavaId");

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.NarudzbaDostava", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Dostava", "Dostava")
                        .WithMany()
                        .HasForeignKey("DostavaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.NarudzbaStavka", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Boja", "Boja")
                        .WithMany()
                        .HasForeignKey("BojaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Ocjena", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Opstina", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Kanton", "Kanton")
                        .WithMany()
                        .HasForeignKey("KantonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Proizvod", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.VrstaProizvoda", "VrstaProizvoda")
                        .WithMany()
                        .HasForeignKey("VrstaProizvodaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.ProizvodBoja", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Boja", "Boja")
                        .WithMany()
                        .HasForeignKey("BojaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.ProizvodSkladiste", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Skladiste", "Skladiste")
                        .WithMany()
                        .HasForeignKey("SkladisteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.RadniNalog", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Dostavljac", "Dostavljac")
                        .WithMany()
                        .HasForeignKey("DostavljacId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaId");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Skladiste", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.Ulaz", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Skladiste", "Skladiste")
                        .WithMany()
                        .HasForeignKey("SkladisteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineProdajaNamjestaja.Data.Models.UlazStavke", b =>
                {
                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineProdajaNamjestaja.Data.Models.Ulaz", "Ulaz")
                        .WithMany()
                        .HasForeignKey("UlazId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
