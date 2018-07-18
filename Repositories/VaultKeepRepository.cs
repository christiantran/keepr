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
                INSERT INTO vaultkeeps (vaultId, keepId, authorId)
                VALUES (@VaultId, @KeepId, @AuthorId);
                SELECT LAST_INSERT_ID();
            ", vaultkeep);
            vaultkeep.Id = id;
            return vaultkeep;
        }

        // GET KEEPS
        public IEnumerable<Keep> GetKeepsInVault(int vaultId)
        {
            return _db.Query<Keep>("SELECT * FROM vaultkeeps vk INNER JOIN keeps k ON k.id = vk.keepId WHERE (vaultId = @vaultId)", new { vaultId });
        }

        // DELETE
        public bool DeleteVaultKeep(int id, string authorId)
        {
            var i = _db.Execute(@"
                DELETE FROM vaultkeep
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