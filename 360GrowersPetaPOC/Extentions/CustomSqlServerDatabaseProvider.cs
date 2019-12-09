using PetaPoco;
using System.Data;

namespace _360GrowersPetaPOC.Extentions
{
    public class CustomSqlServerDatabaseProvider : SqlServerDatabaseProvider
    {
        public override object ExecuteInsert(Database db, IDbCommand cmd, string primaryKeyName)
        {
            cmd.CommandText = "DECLARE @output TABLE(ID UniqueIdentifier); " + cmd.CommandText + "; SELECT ID FROM @output";

            return ExecuteScalarHelper(db, cmd);
        }

        public override string GetInsertOutputClause(string primaryKeyName)
            => $" OUTPUT INSERTED.[{primaryKeyName}] INTO @output(ID)";
    }
}
