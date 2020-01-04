namespace Widly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerDoB : DbMigration
    {
        public override void Up()
        {
            Sql("Update Customers SET DOB = '02/06/1988' WHERE Id = 1");
            Sql("Update Customers SET DOB = '03/14/1989' WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
