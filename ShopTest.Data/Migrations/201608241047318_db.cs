namespace ShopTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactDetails", "Name", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactDetails", "Name", c => c.String(maxLength: 250));
        }
    }
}
