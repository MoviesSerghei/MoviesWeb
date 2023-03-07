namespace MoviesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Date = c.DateTime(nullable: false),
                        Image = c.String(),
                        Description = c.String(),
                        GenreID = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                        Favorite = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genre", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.GenreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "GenreID", "dbo.Genre");
            DropIndex("dbo.Movie", new[] { "GenreID" });
            DropTable("dbo.Movie");
            DropTable("dbo.Genre");
        }
    }
}
