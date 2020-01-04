namespace Widly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingMovieAndGenreNameMandatory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Movies", "Name", c => c.String(maxLength: 150));
        }
    }
}
