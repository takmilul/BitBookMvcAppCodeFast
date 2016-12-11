namespace BitBookMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profile", "Gender", c => c.String(maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profile", "Gender", c => c.String(maxLength: 10, fixedLength: true));
        }
    }
}
