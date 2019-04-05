namespace GerenciamentoVendasMovel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GerenciamentoMovel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movels", "Medida_Altura", c => c.Double(nullable: false));
            AddColumn("dbo.Movels", "Medida_Largura", c => c.Double(nullable: false));
            AddColumn("dbo.Movels", "Medida_Comprimento", c => c.Double(nullable: false));
            DropColumn("dbo.Movels", "Medida");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movels", "Medida", c => c.Double(nullable: false));
            DropColumn("dbo.Movels", "Medida_Comprimento");
            DropColumn("dbo.Movels", "Medida_Largura");
            DropColumn("dbo.Movels", "Medida_Altura");
        }
    }
}
