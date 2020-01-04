namespace Widly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyingCharacterLimitOnMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: true, maxLength: 50));
            Sql("Update MembershipTypes SET Name = 'PayAsYouGo' WHERE Id = 1");
            Sql("Update MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("Update MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            Sql("Update MembershipTypes SET Name = 'Yearly' WHERE Id = 4");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
    }
}
