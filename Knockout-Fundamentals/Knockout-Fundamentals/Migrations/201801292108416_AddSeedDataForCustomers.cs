namespace Knockout_Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeedDataForCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, Age, Comments) Values ('James', 33, 'From Maryland')");
            Sql("INSERT INTO Customers (Name, Age, Comments) Values ('Pete', 44, 'From Pete')");
            Sql("INSERT INTO Customers (Name, Age, Comments) Values ('Lost', 55, 'Todo')");
        }
        
        public override void Down()
        {
        }
    }
}
