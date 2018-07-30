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

        // [HttpPost]
        // [Authorize]
        // public Keep CreateKeep([FromBody]Keep newKeep)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         var user = HttpContext.User;
        //         newKeep.AuthorId = user.Identity.Name;
        //         return _db.CreateKeep(newKeep);
        //     }
        //     return null;
        // }

        [HttpPost]
        public Keep CreateKeep(int id, [FromBody]Keep newKeep)
        {
            if (ModelState.IsValid)
            {
                newKeep.AuthorId = HttpContext.User.Identity.Name;
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
        // [HttpGet("{id}")]
        // public Keep GetById(string id)
        // {
        //     return _db.GetbyKeepId(id);
        // }

                [HttpGet("{id}")]
        public Keep GetById(int id)
        {
            return _db.GetbyKeepId(id);
        }

        //GET BY AUTHOR
        [HttpGet("user/{id}")]
        [Authorize]
        public IEnumerable<Keep> GetByAuthorId(string id)
        {
            return _db.GetbyAuthorId(id);
        }

        //GET BY VAULT ID
        [HttpGet("vault/{id}")]
        [Authorize]
        public IEnumerable<Keep> GetByVaultId(int id)
        {
            return _db.GetByVaultId(id);
        }

        // //EDIT KEEPS
        [HttpPut("{id}")]
        [Authorize]
        public Keep EditKeep(int id, [FromBody]Keep editKeep)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User.Identity.Name;
                return _db.EditKeep(id, editKeep, user);
            }
            return null;
        }

        // DELETE KEEP
        [HttpDelete("{id}")]
        [Authorize]
        public string DeleteKeep(int id)
        {
            var user = HttpContext.User.Identity.Name;
            bool delete = _db.DeleteKeep(id, user);
            if (delete)
            {
                return "Successfully Deleted";
            }
            return "Try again";
        }
    }
}