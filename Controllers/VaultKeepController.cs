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

        // CREATE VAULT
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

        // GET BY AUTHOR
        [HttpGet("author/{id}")]
        public IEnumerable<VaultKeep> GetByAuthorId(int id)
        {
            return _db.GetbyAuthorId(id);
        }




    }
}