using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;

namespace keepr.Repositories
{
    public class KeepRepository : DbContext
    {
        public KeepRepository(IDbConnection db) : base(db)
        {

        }

        // CREATE KEEP
        public Keep CreateKeep(Keep newKeep)
        {
            int id = _db.ExecuteScalar<int>(@"
                INSERT INTO keeps (name, description, img, authorId)
                VALUES (@Name, @Description, @Img, @AuthorId);
                SELECT LAST_INSERT_ID();
            ", newKeep);
            newKeep.Id = id;
            return newKeep;
        }

        // GET ALL KEEPS
        public IEnumerable<Keep> GetAll()
        {
            var keeps = _db.Query<Keep>("SELECT * FROM keeps;");
            return keeps;
        }

        // GET BY AUTHOR
        internal IEnumerable<Keep> GetbyAuthorId(string id)
        {
            return _db.Query<Keep>("SELECT * FROM keeps WHERE authorId = @id;", new { id });
        }

        // GET BY VAULT ID
        internal IEnumerable<Keep> GetByVaultId(int id)
        {
            return _db.Query<Keep>("SELECT * FROM keeps WHERE vaultId = @id;", new { id });
        }

        // GET BY ID
        public Keep GetbyKeepId(string id)
        {
            return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @id;", new { id });
        }

        // EDIT KEEP
        internal Keep EditKeep(int id, Keep editKeep, string user)
        {
            editKeep.Id = id;
            editKeep.AuthorId = user;
            var i = _db.Execute(@"
                UPDATE keeps SET
                    name = @Name,
                    description = @Description,
                    img =@img,
                    authorId = @AuthorId
                WHERE id = @Id
            ", editKeep);
            if (i > 0)
            {
                return editKeep;
            }
            return null;
        }

        // DELETE KEEP
        internal bool DeleteKeep(int id, string user)
        {
            var i = _db.Execute(@"
      DELETE FROM keeps
      WHERE id = @id
      LIMIT 1;
      ", new { id });
            if (i > 0)
            {
                return true;
            }
            return false;
        }

    }

}