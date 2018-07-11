using Microsoft.AspNetCore.Mvc;
using keepr.Repositories;
using keepr.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  public class KeepController : Controller
  {
    private readonly KeepRepository _db;

    public KeepController(KeepRepository repo)
    {
      _db = repo;  
    }

    [HttpPost]
    [Authorize]
    public Keep CreateKeep([FromBody]Keep newKeep)
    {
      if(ModelState.IsValid)
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
    public Keep GetById(int id)
    {
      return _db.GetbyKeepId(id);
    }

    //GET BY AUTHOR
    [HttpGet("author/{id}")]
    public IEnumerable<Keep> GetByAuthorId(int id)
    {
      return _db.GetbyAuthorId(id);
    }

    //EDIT KEEP
    [HttpPut("{id}")]
    public Keep EditKeep(int id, [FromBody]Keep newKeep)
    {
      return _db.EditKeep(id, newKeep);
    }
  }
}