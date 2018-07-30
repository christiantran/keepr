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
    public Vault CreateVault(Vault vault)
    {
      int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaults (name, description, authorId)
                VALUES (@Name, @Description, @AuthorId);
                SELECT LAST_INSERT_ID();
            ", vault);
      vault.Id = id;
      return vault;
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
    internal Vault GetbyId(int id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @id;", new { id });
    }

    // EDIT VAULT
    public Vault EditVault(int id, Vault edit)
    {
      edit.Id = id;
      var i = _db.Execute(@"
                UPDATE vaults SET
                    name = @Name,
                    description = @Description
                WHERE id = @Id
                AND authorId = @AuthorId;
            ", edit);
      if (i > 0)
      {
        return edit;
      }
      return null;
    }

    // DELETE VAULT
    public bool DeleteVault(int id, string authorId)
    {
      var i = _db.Execute(@"
      DELETE FROM vaults
      WHERE id = @id
      AND authorId = @authorId
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