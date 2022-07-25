namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreandoDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auxiliar",
                c => new
                {
                    IDPeriferico = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                    IDAuxiliar = c.String(unicode: false),
                    Funcionando = c.Boolean(),
                    Observaciones = c.String(unicode: false),
                    Fecha_Inst = c.DateTime(storeType: "date"),
                })
                .PrimaryKey(t => t.IDPeriferico)
                .ForeignKey("dbo.Perifericos", t => t.IDPeriferico)
                .Index(t => t.IDPeriferico);

            CreateTable(
                "dbo.Perifericos",
                c => new
                {
                    IDPeriferico = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                    Marca = c.String(unicode: false),
                    Modelo = c.String(unicode: false),
                    NoSerie = c.String(unicode: false),
                    Revisado = c.Boolean(),
                    Baja = c.DateTime(storeType: "date"),
                    Aplicacion = c.String(unicode: false),
                    Expediente = c.String(unicode: false),
                    Comentario = c.String(unicode: false),
                    Disponibilidad = c.Boolean(),
                    Check_ = c.Boolean(),
                    Tipo_Periferico = c.String(unicode: false),
                })
                .PrimaryKey(t => t.IDPeriferico);

            CreateTable(
                "dbo.Computadora_Perifericos",
                c => new
                {
                    IDPeriferico = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                    Codigo_PC = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                    Area = c.String(unicode: false),
                    Ubicacion_Act = c.String(unicode: false),
                    Status_ = c.String(unicode: false),
                    Fecha_Asignacion = c.DateTime(storeType: "date"),
                })
                .PrimaryKey(t => new { t.IDPeriferico, t.Codigo_PC })
                .ForeignKey("dbo.Computadora", t => t.Codigo_PC)
                .ForeignKey("dbo.Perifericos", t => t.IDPeriferico)
                .Index(t => t.IDPeriferico)
                .Index(t => t.Codigo_PC);

            CreateTable(
                "dbo.Computadora",
                c => new
                {
                    Codigo_PC = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                    Actualizado = c.Boolean(),
                    Baja = c.DateTime(storeType: "date"),
                    Aplicacion = c.String(unicode: false),
                    Expediente = c.String(unicode: false),
                    Check_ = c.Boolean(),
                    Maquina = c.String(unicode: false),
                    Red = c.Boolean(),
                    IPV4 = c.String(unicode: false),
                    Mascara_IPV4 = c.String(unicode: false),
                    IPV6 = c.String(unicode: false),
                    Mascara_IPV6 = c.String(unicode: false),
                    Internet = c.String(unicode: false),
                    Correo = c.String(unicode: false),
                    Tipo_Computador = c.String(unicode: false),
                    Observaciones = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Codigo_PC);

            CreateTable(
                "dbo.Bitacora",
                c => new
                {
                    IDBitacora = c.Int(nullable: false, identity: true),
                    Codigo_PC = c.String(maxLength: 7, fixedLength: true, unicode: false),
                    Expediente = c.String(unicode: false),
                    Falla_Reportada = c.String(unicode: false),
                    Que_Presenta = c.String(unicode: false),
                    Causa = c.String(unicode: false),
                    Accion = c.String(unicode: false),
                    Observaciones = c.String(unicode: false),
                    Reporto = c.String(unicode: false),
                    Atendio = c.String(unicode: false),
                    Fecha_Reporte = c.DateTime(storeType: "date"),
                    Fecha_Solucion = c.DateTime(storeType: "date"),
                    Ubicacion = c.String(unicode: false),
                })
                .PrimaryKey(t => t.IDBitacora)
                .ForeignKey("dbo.Computadora", t => t.Codigo_PC)
                .Index(t => t.Codigo_PC);

            CreateTable(
                "dbo.Factura_Detalle_Comp",
                c => new
                {
                    IDFactura = c.Int(nullable: false),
                    Codigo_PC = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                    Fecha = c.DateTime(storeType: "date"),
                    Hora = c.Time(precision: 7),
                    Responsable = c.String(unicode: false),
                })
                .PrimaryKey(t => new { t.IDFactura, t.Codigo_PC })
                .ForeignKey("dbo.Factura", t => t.IDFactura)
                .ForeignKey("dbo.Computadora", t => t.Codigo_PC)
                .Index(t => t.IDFactura)
                .Index(t => t.Codigo_PC);

            CreateTable(
                "dbo.Factura",
                c => new
                {
                    IDFactura = c.Int(nullable: false, identity: true),
                    IDProveedor = c.Int(nullable: false),
                    Vendedor = c.String(unicode: false),
                    Factura = c.Binary(),
                    Fecha_Compra = c.DateTime(nullable: false, storeType: "date"),
                    Requisicion = c.Binary(),
                    Descripcion = c.String(),
                })
                .PrimaryKey(t => t.IDFactura)
                .ForeignKey("dbo.Proveedores", t => t.IDProveedor, cascadeDelete: true)
                .Index(t => t.IDProveedor);

            CreateTable(
                "dbo.Factura_Detalle_Per",
                c => new
                {
                    IDFactura = c.Int(nullable: false),
                    IDPeriferico = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                    Fecha = c.DateTime(storeType: "date"),
                    Hora = c.Time(precision: 7),
                    Responsable = c.String(unicode: false),
                })
                .PrimaryKey(t => new { t.IDFactura, t.IDPeriferico })
                .ForeignKey("dbo.Factura", t => t.IDFactura)
                .ForeignKey("dbo.Perifericos", t => t.IDPeriferico)
                .Index(t => t.IDFactura)
                .Index(t => t.IDPeriferico);

            CreateTable(
                "dbo.Factura_Detalle_Soft",
                c => new
                {
                    IDFactura = c.Int(nullable: false),
                    IDSoftware = c.Int(nullable: false),
                    Fecha = c.DateTime(storeType: "date"),
                    Hora = c.Time(precision: 7),
                    Responsable = c.String(unicode: false),
                })
                .PrimaryKey(t => new { t.IDFactura, t.IDSoftware })
                .ForeignKey("dbo.Software", t => t.IDSoftware)
                .ForeignKey("dbo.Factura", t => t.IDFactura)
                .Index(t => t.IDFactura)
                .Index(t => t.IDSoftware);

            CreateTable(
                "dbo.Software",
                c => new
                {
                    IDSoftware = c.Int(nullable: false, identity: true),
                    Product_Key = c.String(unicode: false),
                    Tipo_Lic = c.String(unicode: false),
                    Licencia = c.String(unicode: false),
                    Num_Licencia = c.String(unicode: false),
                    License_Pack_Bar_Code = c.String(unicode: false),
                    Certificado = c.String(unicode: false),
                    AGMT_ID = c.String(unicode: false),
                    Activa = c.String(unicode: false),
                    Cantidad = c.String(unicode: false),
                    Revisado = c.Boolean(),
                })
                .PrimaryKey(t => t.IDSoftware);

            CreateTable(
                "dbo.Proveedores",
                c => new
                {
                    IDProveedor = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.IDProveedor);

            CreateTable(
                "dbo.Ranuras",
                c => new
                {
                    IDRanura = c.Int(nullable: false, identity: true),
                    Codigo_PC = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                    Tipo_Slot = c.String(unicode: false),
                    Disponible = c.Boolean(),
                })
                .PrimaryKey(t => t.IDRanura)
                .ForeignKey("dbo.Computadora", t => t.Codigo_PC)
                .Index(t => t.Codigo_PC);

            CreateTable(
                "dbo.Ranura_Detalle_Hard",
                c => new
                {
                    IDRanura = c.Int(nullable: false),
                    IDHardware = c.Int(nullable: false),
                    Fecha = c.DateTime(storeType: "date"),
                    Hora = c.Time(precision: 7),
                    Responsable = c.String(unicode: false),
                })
                .PrimaryKey(t => new { t.IDRanura, t.IDHardware })
                .ForeignKey("dbo.Hardware", t => t.IDHardware)
                .ForeignKey("dbo.Ranuras", t => t.IDRanura)
                .Index(t => t.IDRanura)
                .Index(t => t.IDHardware);

            CreateTable(
                "dbo.Hardware",
                c => new
                {
                    IDHardware = c.Int(nullable: false, identity: true),
                    Tamano = c.Int(),
                    Unidad_Med = c.String(unicode: false),
                    Velocidada = c.Int(),
                })
                .PrimaryKey(t => t.IDHardware);

            CreateTable(
                "dbo.Ranura_Detalle_Per",
                c => new
                {
                    IDRanura = c.Int(nullable: false),
                    IDPeriferico = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                    Fecha = c.DateTime(storeType: "date"),
                    Hora = c.Time(precision: 7),
                    Responsable = c.String(unicode: false),
                })
                .PrimaryKey(t => new { t.IDRanura, t.IDPeriferico })
                .ForeignKey("dbo.Ranuras", t => t.IDRanura)
                .ForeignKey("dbo.Perifericos", t => t.IDPeriferico)
                .Index(t => t.IDRanura)
                .Index(t => t.IDPeriferico);

            CreateTable(
                "dbo.Impresora",
                c => new
                {
                    IDPeriferico = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                    IDImpresora = c.String(unicode: false),
                    Cart_Negro = c.String(unicode: false),
                    Cart_Color = c.String(unicode: false),
                    Tipo = c.String(unicode: false),
                    Tipo_Imp = c.String(unicode: false),
                    Responsable = c.String(unicode: false),
                    Garantia = c.DateTime(storeType: "date"),
                })
                .PrimaryKey(t => t.IDPeriferico)
                .ForeignKey("dbo.Perifericos", t => t.IDPeriferico)
                .Index(t => t.IDPeriferico);

            CreateTable(
                "dbo.Monitor",
                c => new
                {
                    IDPeriferico = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                    IDMonitor = c.String(unicode: false),
                    Tipo = c.String(unicode: false),
                    Tamano = c.Int(),
                    Unidad_Med = c.String(unicode: false),
                })
                .PrimaryKey(t => t.IDPeriferico)
                .ForeignKey("dbo.Perifericos", t => t.IDPeriferico)
                .Index(t => t.IDPeriferico);

            CreateTable(
                "dbo.sysdiagrams",
                c => new
                {
                    diagram_id = c.Int(nullable: false, identity: true),
                    name = c.String(nullable: false, maxLength: 128),
                    principal_id = c.Int(nullable: false),
                    version = c.Int(),
                    definition = c.Binary(),
                })
                .PrimaryKey(t => t.diagram_id);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ranura_Detalle_Per", "IDPeriferico", "dbo.Perifericos");
            DropForeignKey("dbo.Monitor", "IDPeriferico", "dbo.Perifericos");
            DropForeignKey("dbo.Impresora", "IDPeriferico", "dbo.Perifericos");
            DropForeignKey("dbo.Factura_Detalle_Per", "IDPeriferico", "dbo.Perifericos");
            DropForeignKey("dbo.Computadora_Perifericos", "IDPeriferico", "dbo.Perifericos");
            DropForeignKey("dbo.Ranuras", "Codigo_PC", "dbo.Computadora");
            DropForeignKey("dbo.Ranura_Detalle_Per", "IDRanura", "dbo.Ranuras");
            DropForeignKey("dbo.Ranura_Detalle_Hard", "IDRanura", "dbo.Ranuras");
            DropForeignKey("dbo.Ranura_Detalle_Hard", "IDHardware", "dbo.Hardware");
            DropForeignKey("dbo.Factura_Detalle_Comp", "Codigo_PC", "dbo.Computadora");
            DropForeignKey("dbo.Factura", "IDProveedor", "dbo.Proveedores");
            DropForeignKey("dbo.Factura_Detalle_Soft", "IDFactura", "dbo.Factura");
            DropForeignKey("dbo.Factura_Detalle_Soft", "IDSoftware", "dbo.Software");
            DropForeignKey("dbo.Factura_Detalle_Per", "IDFactura", "dbo.Factura");
            DropForeignKey("dbo.Factura_Detalle_Comp", "IDFactura", "dbo.Factura");
            DropForeignKey("dbo.Computadora_Perifericos", "Codigo_PC", "dbo.Computadora");
            DropForeignKey("dbo.Bitacora", "Codigo_PC", "dbo.Computadora");
            DropForeignKey("dbo.Auxiliar", "IDPeriferico", "dbo.Perifericos");
            DropIndex("dbo.Monitor", new[] { "IDPeriferico" });
            DropIndex("dbo.Impresora", new[] { "IDPeriferico" });
            DropIndex("dbo.Ranura_Detalle_Per", new[] { "IDPeriferico" });
            DropIndex("dbo.Ranura_Detalle_Per", new[] { "IDRanura" });
            DropIndex("dbo.Ranura_Detalle_Hard", new[] { "IDHardware" });
            DropIndex("dbo.Ranura_Detalle_Hard", new[] { "IDRanura" });
            DropIndex("dbo.Ranuras", new[] { "Codigo_PC" });
            DropIndex("dbo.Factura_Detalle_Soft", new[] { "IDSoftware" });
            DropIndex("dbo.Factura_Detalle_Soft", new[] { "IDFactura" });
            DropIndex("dbo.Factura_Detalle_Per", new[] { "IDPeriferico" });
            DropIndex("dbo.Factura_Detalle_Per", new[] { "IDFactura" });
            DropIndex("dbo.Factura", new[] { "IDProveedor" });
            DropIndex("dbo.Factura_Detalle_Comp", new[] { "Codigo_PC" });
            DropIndex("dbo.Factura_Detalle_Comp", new[] { "IDFactura" });
            DropIndex("dbo.Bitacora", new[] { "Codigo_PC" });
            DropIndex("dbo.Computadora_Perifericos", new[] { "Codigo_PC" });
            DropIndex("dbo.Computadora_Perifericos", new[] { "IDPeriferico" });
            DropIndex("dbo.Auxiliar", new[] { "IDPeriferico" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Monitor");
            DropTable("dbo.Impresora");
            DropTable("dbo.Ranura_Detalle_Per");
            DropTable("dbo.Hardware");
            DropTable("dbo.Ranura_Detalle_Hard");
            DropTable("dbo.Ranuras");
            DropTable("dbo.Proveedores");
            DropTable("dbo.Software");
            DropTable("dbo.Factura_Detalle_Soft");
            DropTable("dbo.Factura_Detalle_Per");
            DropTable("dbo.Factura");
            DropTable("dbo.Factura_Detalle_Comp");
            DropTable("dbo.Bitacora");
            DropTable("dbo.Computadora");
            DropTable("dbo.Computadora_Perifericos");
            DropTable("dbo.Perifericos");
            DropTable("dbo.Auxiliar");
        }
    }
}
