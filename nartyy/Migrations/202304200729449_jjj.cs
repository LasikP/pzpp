namespace nartyy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jjj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ButyNarciarskie",
                c => new
                    {
                        IDButyNarciarskie = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Opis = c.String(),
                        Producent = c.String(),
                        Kolor = c.String(),
                        Rozmiar = c.Int(),
                        CenaGodzinowa = c.Decimal(precision: 18, scale: 2),
                        Dostepnosc = c.Boolean(),
                        Zdjecie = c.Binary(),
                        IDRezerwacji = c.Int(),
                    })
                .PrimaryKey(t => t.IDButyNarciarskie)
                .ForeignKey("dbo.Rezerwacje", t => t.IDRezerwacji)
                .Index(t => t.IDRezerwacji);
            
            CreateTable(
                "dbo.Rezerwacje",
                c => new
                    {
                        IDSprzet = c.Int(nullable: false, identity: true),
                        TypSprzetu = c.String(),
                        DataOdbioru = c.DateTime(precision: 7, storeType: "datetime2"),
                        DataZwrotu = c.DateTime(precision: 7, storeType: "datetime2"),
                        IDClient = c.Int(),
                    })
                .PrimaryKey(t => t.IDSprzet)
                .ForeignKey("dbo.Clients", t => t.IDClient)
                .Index(t => t.IDClient);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IDClient = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Adress = c.String(),
                        Roles = c.String(),
                    })
                .PrimaryKey(t => t.IDClient);
            
            CreateTable(
                "dbo.Narty",
                c => new
                    {
                        IDNarty = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Opis = c.String(),
                        Producent = c.String(),
                        Kolor = c.String(),
                        Rozmiar = c.Int(),
                        CenaGodzinowa = c.Decimal(precision: 18, scale: 2),
                        Dostepnosc = c.Boolean(),
                        Zdjecie = c.Binary(),
                        IDRezerwacji = c.Int(),
                    })
                .PrimaryKey(t => t.IDNarty)
                .ForeignKey("dbo.Rezerwacje", t => t.IDRezerwacji)
                .Index(t => t.IDRezerwacji);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ButyNarciarskie", "IDRezerwacji", "dbo.Rezerwacje");
            DropForeignKey("dbo.Narty", "IDRezerwacji", "dbo.Rezerwacje");
            DropForeignKey("dbo.Rezerwacje", "IDClient", "dbo.Clients");
            DropIndex("dbo.Narty", new[] { "IDRezerwacji" });
            DropIndex("dbo.Rezerwacje", new[] { "IDClient" });
            DropIndex("dbo.ButyNarciarskie", new[] { "IDRezerwacji" });
            DropTable("dbo.Narty");
            DropTable("dbo.Clients");
            DropTable("dbo.Rezerwacje");
            DropTable("dbo.ButyNarciarskie");
        }
    }
}
