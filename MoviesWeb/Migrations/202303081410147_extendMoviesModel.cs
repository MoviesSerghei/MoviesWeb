namespace MoviesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extendMoviesModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "ExternalMovieId", c => c.Long(nullable: false));
            AlterColumn("dbo.Movie", "Rate", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "Rate", c => c.Int(nullable: false));
            DropColumn("dbo.Movie", "ExternalMovieId");
        }
    }
}
