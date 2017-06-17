using FluentMigrator;

namespace TaskManager.Migration
{
    [Migration(170620171217)]
    public class Migration170620171217 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Tasks")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(250).NotNullable()
                .WithColumn("Description").AsString(int.MaxValue).Nullable()
                .WithColumn("State").AsInt32().NotNullable()
                .WithColumn("Priority").AsInt32().NotNullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                .WithColumn("TimeToComplete").AsDateTime().NotNullable();
        }
    }
}
