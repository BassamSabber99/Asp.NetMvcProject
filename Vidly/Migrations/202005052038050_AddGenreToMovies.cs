namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreToMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        genreId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Genres", t => t.genreId, cascadeDelete: true)
                .Index(t => t.genreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
    }
}
