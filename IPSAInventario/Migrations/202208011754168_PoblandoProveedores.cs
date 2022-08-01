namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoblandoProveedores : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Proveedores Values('Luis')");
            Sql("INSERT INTO Proveedores Values('Pepe')");
            Sql("INSERT INTO Proveedores Values('Pedro')");
            Sql("INSERT INTO Proveedores Values('Martin')");
            Sql("INSERT INTO Proveedores Values('Julio')");
            Sql("INSERT INTO Proveedores Values('Alfonzo')");
            Sql("INSERT INTO Proveedores Values('Gustabo')");
            Sql("INSERT INTO Proveedores Values('Felipe')");
            Sql("INSERT INTO Proveedores Values('Daniel')");
        }
        
        public override void Down()
        {
        }
    }
}
