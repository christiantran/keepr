using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;

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
    public IEnumerable<Vault> GetbyAuthorId(int id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE authorId = @id;", new { id });
    }

    // GET BY ID
    public Vault GetbyVaultId(int id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @id;", new { id });
    }

    // EDIT VAULT
    public Vault EditVault(int id, Vault vault)
    {
      vault.Id = id;
      var i = _db.Execute(@"
                UPDATE vaults SET
                    name = @Name,
                    description = @Description
                WHERE id = @Id
            ", vault);
      if (i > 0)
      {
        return vault;
      }
      return null;
    }

    // DELETE VAULT
    public bool DeletVault(int id)
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