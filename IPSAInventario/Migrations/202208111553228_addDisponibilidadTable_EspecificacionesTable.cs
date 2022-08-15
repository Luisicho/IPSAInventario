namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDisponibilidadTable_EspecificacionesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disponibilidad",
                c => new
                    {
                        IdDisponibilidad = c.Int(nullable: false, identity: true),
                        Codigo_PC = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                        Area = c.String(),
                        Departamento = c.String(),
                        Ubicacion_Act = c.String(),
                        Status_ = c.String(),
                        Disponiblilidad = c.Boolean(),
                        Fecha_Asignacion = c.DateTime(),
                        Responsable = c.String(),
                    })
                .PrimaryKey(t => t.IdDisponibilidad)
                .ForeignKey("dbo.Computadora", t => t.Codigo_PC, cascadeDelete: true)
                .Index(t => t.Codigo_PC);
            
            CreateTable(
                "dbo.Especificaciones",
                c => new
                    {
                        IdEspecificaciones = c.Int(nullable: false, identity: true),
                        Codigo_PC = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                        Marca = c.String(),
                        Serie_Maq = c.String(),
                        Procesador = c.String(),
                        Nucleos = c.String(),
                        Velocidad = c.Int(nullable: false),
                        Unidad_Medida = c.String(maxLength: 7),
                        Mobo_Marca = c.String(),
                        Mobo_Modelo = c.String(),
                        Mobo_Serie = c.String(),
                    })
                .PrimaryKey(t => t.IdEspecificaciones)
                .ForeignKey("dbo.Computadora", t => t.Codigo_PC, cascadeDelete: true)
                .Index(t => t.Codigo_PC);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Especificaciones", "Codigo_PC", "dbo.Computadora");
            DropForeignKey("dbo.Disponibilidad", "Codigo_PC", "dbo.Computadora");
            DropIndex("dbo.Especificaciones", new[] { "Codigo_PC" });
            DropIndex("dbo.Disponibilidad", new[] { "Codigo_PC" });
            DropTable("dbo.Especificaciones");
            DropTable("dbo.Disponibilidad");
        }
    }
}
