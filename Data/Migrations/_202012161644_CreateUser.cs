using FluentMigrator;

namespace FProject.Data.Migrations
{
    [Migration(1)]
    public class _202012161644_CreateUser : Migration
    {
        private string TableName = "User";
        public override void Down()
        {
            Delete.Table(TableName);
        }

        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt16().PrimaryKey().Identity()
                .WithColumn("Username").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable()
                .WithColumn("Password").AsString().NotNullable();
        }
    }
}
