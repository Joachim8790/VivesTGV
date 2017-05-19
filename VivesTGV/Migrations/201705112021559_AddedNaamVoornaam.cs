namespace VivesTGV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNaamVoornaam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Voornaam", c => c.String());
            AddColumn("dbo.AspNetUsers", "Naam", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Naam");
            DropColumn("dbo.AspNetUsers", "Voornaam");
        }
    }
}
