namespace Widly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaxLengthToMovieAndGenreName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(maxLength: 150));
            AlterColumn("dbo.Genres", "Name", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
