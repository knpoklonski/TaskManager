using FluentMigrator;

namespace TaskManager.Migration
{
    [Migration(170620171441)]
    public class Migration170620171441 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Alter.Table("Tasks")
                .AddColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false);
        }
    }
}