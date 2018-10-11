namespace TallerApi.Apis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelo1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publicacions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        FechaPublicacion = c.DateTime(nullable: false),
                        MeGusta = c.Int(nullable: false),
                        MeDisgusta = c.Int(nullable: false),
                        VecesCompartido = c.Int(nullable: false),
                        EsPrivado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Publicacions");
        }
    }
}
