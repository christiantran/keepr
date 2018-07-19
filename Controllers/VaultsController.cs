using Microsoft.AspNetCore.Mvc;
using keepr.Repositories;
using keepr.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class VaultsController : Controller
    {
        private readonly VaultRepository _db;

        public VaultsController(VaultRepository repo)
        {
            _db = repo;
        }

        //CREATE VAULT
        [HttpPost]
        //[Authorize]
        public Vault CreateVault([FromBody]Vault newVault)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User;
                newVault.AuthorId = user.Identity.Name;
                return _db.CreateVault(newVault);
            }
            return null;
        }

        //GET ALL VAULTS
        [HttpGet]
        public IEnumerable<Vault> GetAll()
        {
            return _db.GetAll();
        }

        //GET BY ID
        [HttpGet("{id}")]
        public Vault GetById(int id)
        {
            return _db.GetbyVaultId(id);
        }

        //GET BY AUTHOR
        [HttpGet("author/{id}")]
        public IEnumerable<Vault> GetByAuthorId(string id)
        {
            return _db.GetbyAuthorId(id);
        }

        // //EDIT VAULT
        // [HttpPut("{id}")]
        // public Vault EditVault(int id, [FromBody]Vault editVault)
        // {
        //     //return _db.EditVault(id, newVault);
        //     if (ModelState.IsValid)
        //     {
        //         return _db.EditVault(id, editVault);
        //     }
        //     return null;
        // }

        // DELETE VAULT
        [HttpDelete("{id}")]
        [Authorize]
        public string DeleteVault(int id)
        {
            var user = HttpContext.User.Identity.Name;
            bool delete = _db.DeleteVault(id, user);
            if (delete)
            {
                return "Successfully Deleted";
            }
            return "Try again";
        }
    }
}