using System;
using System.Data.Entity.Migrations;

public partial class tododecero : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Clientes",
            c => new
                {
                    ClienteID = c.Int(nullable: false, identity: true),
                    Nombre_Cliente = c.String(nullable: false, maxLength: 30),
                    Apellido_Cliente = c.String(nullable: false, maxLength: 30),
                    Movil = c.String(nullable: false, maxLength: 30),
                    Direccion = c.String(nullable: false, maxLength: 30),
                    Email = c.String(),
                    Documento = c.String(nullable: false, maxLength: 30),
                    Id_tipoDocumento = c.Int(nullable: false),
                })
            .PrimaryKey(t => t.ClienteID)
            .ForeignKey("dbo.Tipo_documento", t => t.Id_tipoDocumento)
            .Index(t => t.Id_tipoDocumento);
        
        CreateTable(
            "dbo.Tipo_documento",
            c => new
                {
                    Id_tipoDocumento = c.Int(nullable: false, identity: true),
                    Descripcion = c.String(nullable: false),
                })
            .PrimaryKey(t => t.Id_tipoDocumento);
        
        CreateTable(
            "dbo.Empleadoes",
            c => new
                {
                    Id_empleado = c.Int(nullable: false, identity: true),
                    Nombres = c.String(nullable: false, maxLength: 30),
                    Apellidos = c.String(nullable: false, maxLength: 30),
                    Porcentaje_bonificado = c.Single(nullable: false),
                    FechaNacimiento = c.DateTime(nullable: false),
                    Hora_inicio = c.DateTime(nullable: false),
                    Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Email = c.String(nullable: false),
                    Id_tipoDocumento = c.Int(nullable: false),
                    Numero_documento = c.String(nullable: false),
                })
            .PrimaryKey(t => t.Id_empleado)
            .ForeignKey("dbo.Tipo_documento", t => t.Id_tipoDocumento)
            .Index(t => t.Id_tipoDocumento);
        
        CreateTable(
            "dbo.Productoes",
            c => new
                {
                    Id_producto = c.Int(nullable: false, identity: true),
                    Nombre_producto = c.String(nullable: false),
                    Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Cantidad = c.Int(nullable: false),
                    Ultima_compra = c.DateTime(nullable: false),
                    Existencias = c.Single(nullable: false),
                })
            .PrimaryKey(t => t.Id_producto);
        
        CreateTable(
            "dbo.ProveedorProductoes",
            c => new
                {
                    ProveedorProductoID = c.Int(nullable: false, identity: true),
                    ProveedorID = c.Int(nullable: false),
                    Id_producto = c.Int(nullable: false),
                })
            .PrimaryKey(t => t.ProveedorProductoID)
            .ForeignKey("dbo.Productoes", t => t.Id_producto)
            .ForeignKey("dbo.Proveedors", t => t.ProveedorID)
            .Index(t => t.ProveedorID)
            .Index(t => t.Id_producto);
        
        CreateTable(
            "dbo.Proveedors",
            c => new
                {
                    ProveedorID = c.Int(nullable: false, identity: true),
                    Nombre = c.String(nullable: false, maxLength: 30),
                    Nombre_Contacto = c.String(nullable: false, maxLength: 30),
                    Apellido_Contacto = c.String(nullable: false, maxLength: 30),
                    Movil = c.String(nullable: false, maxLength: 30),
                    Direccion = c.String(nullable: false, maxLength: 30),
                    Email = c.String(),
                })
            .PrimaryKey(t => t.ProveedorID);
        
    }
    
    public override void Down()
    {
        DropForeignKey("dbo.ProveedorProductoes", "ProveedorID", "dbo.Proveedors");
        DropForeignKey("dbo.ProveedorProductoes", "Id_producto", "dbo.Productoes");
        DropForeignKey("dbo.Empleadoes", "Id_tipoDocumento", "dbo.Tipo_documento");
        DropForeignKey("dbo.Clientes", "Id_tipoDocumento", "dbo.Tipo_documento");
        DropIndex("dbo.ProveedorProductoes", new[] { "Id_producto" });
        DropIndex("dbo.ProveedorProductoes", new[] { "ProveedorID" });
        DropIndex("dbo.Empleadoes", new[] { "Id_tipoDocumento" });
        DropIndex("dbo.Clientes", new[] { "Id_tipoDocumento" });
        DropTable("dbo.Proveedors");
        DropTable("dbo.ProveedorProductoes");
        DropTable("dbo.Productoes");
        DropTable("dbo.Empleadoes");
        DropTable("dbo.Tipo_documento");
        DropTable("dbo.Clientes");
    }
}
