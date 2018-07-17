using Microsoft.AspNetCore.Mvc;
using keepr.Repositories;
using keepr.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class KeepsController : Controller
    {
        private readonly KeepRepository _db;

        public KeepsController(KeepRepository repo)
        {
            _db = repo;
        }

        [HttpPost]
        [Authorize]
        public Keep CreateKeep([FromBody]Keep newKeep)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User;
                newKeep.AuthorId = user.Identity.Name;
                return _db.CreateKeep(newKeep);
            }
            return null;
        }

        //GET ALL KEEPS
        [HttpGet]
        public IEnumerable<Keep> GetAll()
        {
            return _db.GetAll();
        }

        //GET BY ID
        [HttpGet("{id}")]
        public Keep GetById(string id)
        {
            return _db.GetbyKeepId(id);
        }

        //GET BY AUTHOR
        [HttpGet("author/{id}")]
        public IEnumerable<Keep> GetByAuthorId(string id)
        {
            return _db.GetbyAuthorId(id);
        }

        // //EDIT KEEPS
        // [HttpPut("{id}")]
        // public Vault EditKeep(int id, [FromBody]Keep editKeep)
        // {
        //     return _db.EditKeep(id, editKeep);
        //     // if (ModelState.IsValid)
        //     // {
        //     //     return _db.EditVault(id, editVault);
        //     // }
        //     // return null;
        // }

        // // DELETE VAULT
        // [HttpDelete("{id}")]
        // [Authorize]
        // public string DeleteVault(int id)
        // {
        //     var user = HttpContext.User.Identity.Name;
        //     bool delete = _db.DeleteVault(id, user);
        //     if (delete)
        //     {
        //         return "Successfully Deleted";
        //     }
        //     return "Try again";
        // }
    }
}