using System.Collections.Generic;
using System;
using System.Data;
using keepr.Models;
using Dapper;
using keepr.Repositories;

namespace keepr.Repositories
{
  public class VaultRepository : DbContext
  {
    public VaultRepository(IDbConnection db) : base(db)
    {

    }

    // CREATE VAULT
    public Vault CreateVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaults (name, description, authorId)
                VALUES (@Name, @Description, @AuthorId);
                SELECT LAST_INSERT_ID();
            ", newVault);
      newVault.Id = id;
      return newVault;
    }

    // GET ALL VAULTS
    public IEnumerable<Vault> GetAll()
    {
      return _db.Query<Vault>("SELECT * FROM vaults;");
    }

    // GET BY AUTHOR
    public IEnumerable<Vault> GetbyAuthorId(string id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE authorId = @id;", new { id });
    }

    // GET BY ID
    internal Vault GetbyVaultId(int id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @id;", new { id });
    }

    // EDIT VAULT
    public Vault EditVault(int id, Vault editVault, string user)
    {
      editVault.Id = id;
      editVault.AuthorId = user;
      var i = _db.Execute(@"
                UPDATE vaults SET
                    name = @Name,
                    description = @Description
                    authorId = @AuthorId;
                WHERE id = @Id
            ", editVault);
      if (i > 0)
      {
        return editVault;
      }
      return null;
    }

    // DELETE VAULT
    public bool DeleteVault(int id, string user)
    {
      var i = _db.Execute(@"
      DELETE FROM vaults
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