namespace Visit.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePicture : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Picture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Picture", c => c.String(maxLength: 50));
        }
    }
}
