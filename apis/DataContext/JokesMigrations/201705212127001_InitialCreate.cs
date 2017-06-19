namespace Jokes.APIs.DataContext.JokesMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PostedBy = c.String(),
                        Content = c.String(maxLength: 200),
                        PostedDate = c.DateTime(nullable: false),
                        IsHideen = c.Boolean(nullable: false),
                        Joke_JokeId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.PostedJokes", t => t.Joke_JokeId)
                .Index(t => t.Joke_JokeId);
            
            CreateTable(
                "dbo.PostedJokes",
                c => new
                    {
                        JokeId = c.Int(nullable: false, identity: true),
                        PostedBy = c.String(),
                        Content = c.String(maxLength: 200),
                        PostedDate = c.DateTime(nullable: false),
                        UpVotes = c.Int(nullable: false),
                        DownVotes = c.Single(nullable: false),
                        IsHideen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.JokeId);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteID = c.Int(nullable: false, identity: true),
                        VotedBy = c.String(),
                        PostedDate = c.DateTime(nullable: false),
                        Joke_JokeId = c.Int(),
                    })
                .PrimaryKey(t => t.VoteID)
                .ForeignKey("dbo.PostedJokes", t => t.Joke_JokeId)
                .Index(t => t.Joke_JokeId);
            
            CreateTable(
                "dbo.PhotoLibraries",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageContent = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "Joke_JokeId", "dbo.PostedJokes");
            DropForeignKey("dbo.Comments", "Joke_JokeId", "dbo.PostedJokes");
            DropIndex("dbo.Votes", new[] { "Joke_JokeId" });
            DropIndex("dbo.Comments", new[] { "Joke_JokeId" });
            DropTable("dbo.PhotoLibraries");
            DropTable("dbo.Votes");
            DropTable("dbo.PostedJokes");
            DropTable("dbo.Comments");
        }
    }
}
