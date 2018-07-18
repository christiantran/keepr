using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class VaultKeepController : Controller
    {
        private readonly VaultKeepRepository _db;
        public VaultKeepController(VaultKeepRepository repo)
        {
            _db = repo;
        }

        // CREATE VAULT KEEP
        [HttpPost]
        [Authorize]
        public VaultKeep CreateVaultKeep([FromBody]VaultKeep newVaultKeep)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User;
                newVaultKeep.AuthorId = user.Identity.Name;
                return _db.CreateVaultKeep(newVaultKeep);
            }
            return null;
        }

        // // GET BY AUTHOR
        // [HttpGet("author/{id}")]
        // public IEnumerable<VaultKeep> GetByAuthorId(int id)
        // {
        //     return _db.GetbyAuthorId(id);
        // }

        // GET BY ID
        [HttpGet("{id}")]
        public IEnumerable<Keep> GetKeepsInVault(int id)
        {
            return _db.GetKeepsInVault(id);
        }

        // DELETE VAULT KEEP
        [HttpDelete("{id}")]
        [Authorize]
        public string DeleteVaultKeep(int id)
        {
            var user = HttpContext.User.Identity.Name;
            bool delete = _db.DeleteVaultKeep(id, user);
            if (delete)
            {
                return "Successfully Deleted";
            }
            return "Try again";
        }


    }
}