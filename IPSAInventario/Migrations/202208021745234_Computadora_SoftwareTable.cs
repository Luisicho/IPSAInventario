namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Computadora_SoftwareTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computadora_Software",
                c => new
                    {
                        IDSoftware = c.Int(nullable: false),
                        Codigo_PC = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                        Instalado = c.String(),
                        Comentarios = c.String(),
                        Auditoria_MS = c.DateTime(),
                        Revisado = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.IDSoftware, t.Codigo_PC })
                .ForeignKey("dbo.Computadora", t => t.Codigo_PC, cascadeDelete: true)
                .ForeignKey("dbo.Software", t => t.IDSoftware, cascadeDelete: true)
                .Index(t => t.IDSoftware)
                .Index(t => t.Codigo_PC);
            
            AddColumn("dbo.Software", "License_Pack", c => c.String());
            AddColumn("dbo.Software", "Disponibilidad", c => c.Boolean());
            DropColumn("dbo.Software", "Revisado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Software", "Revisado", c => c.Boolean());
            DropForeignKey("dbo.Computadora_Software", "IDSoftware", "dbo.Software");
            DropForeignKey("dbo.Computadora_Software", "Codigo_PC", "dbo.Computadora");
            DropIndex("dbo.Computadora_Software", new[] { "Codigo_PC" });
            DropIndex("dbo.Computadora_Software", new[] { "IDSoftware" });
            DropColumn("dbo.Software", "Disponibilidad");
            DropColumn("dbo.Software", "License_Pack");
            DropTable("dbo.Computadora_Software");
        }
    }
}
