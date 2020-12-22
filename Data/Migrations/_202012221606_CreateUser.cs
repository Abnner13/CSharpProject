using FluentMigrator;

namespace FProject.Data.Migrations
{
    [Migration(3)]
    public class _202012221606_CreateUser : Migration
    {
        internal static readonly string TableName = "User";
        public override void Down()
        {
            Delete.Table(TableName);
        }

        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt16().PrimaryKey().Identity()
                .WithColumn("Username").AsString(100).NotNullable()
                .WithColumn("Email").AsString(100).NotNullable()
                .WithColumn("Password").AsString(100).NotNullable()
                .WithColumn("Salt").AsString(100).NotNullable().WithDefaultValue(string.Empty);

        }
    }
}
