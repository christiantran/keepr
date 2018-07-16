using System.Collections.Generic;
using System.Data;
using Dapper;
using System;
using keepr.Repositories;
using keepr.Models;

namespace keepr.Repositories
{
    public class VaultKeepRepository : DbContext
    {
        public VaultKeepRepository(IDbConnection db) : base(db)
        {

        }

        // CREATE VAULTKEEP
        public VaultKeep CreateVaultKeep(VaultKeep vaultkeep)
        {
            int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaults (name, description, authorId)
                VALUES (@Name, @Description, @AuthorId);
                SELECT LAST_INSERT_ID();
            ", vaultkeep);
            vaultkeep.Id = id;
            return vaultkeep;
        }

        // GET BY AUTHOR
        public IEnumerable<VaultKeep> GetbyAuthorId(int id)
        {
            return _db.Query<VaultKeep>("SELECT * FROM vaults WHERE authorId = @id;", new { id });
        }

    }
}