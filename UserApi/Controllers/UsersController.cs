using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly InMemoryDbContext _inMemoryDbContext;

        public UsersController(InMemoryDbContext context)
        {
            _inMemoryDbContext = context;          
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<User> ListAll()
        {
            // return a 200 response
            return _inMemoryDbContext.Users.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(int id)
        {
            // find user in in-memory DB
            User user = _inMemoryDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                // return a 404 response
                return NotFound();
            }

            // return a 200 response
            return new ObjectResult(user);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]User user)
        {
            // validate the model
            if (user == null || user.Name == null || user.Name.Trim().Length > 50 || user.Age <= 0 ||
                (user.Address != null && user.Address.Trim().Length > 50))
            {
                // return a 400 response
                return BadRequest();
            }
            
            // add user to in-memory DB
            _inMemoryDbContext.Users.Add(user);
            _inMemoryDbContext.SaveChanges();

            // return a 201 response
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]User updatedUser)
        {
            // validate the model
            if (updatedUser == null || updatedUser.Id != id ||
                updatedUser.Name == null || updatedUser.Name.Trim().Length > 50 || updatedUser.Age <= 0 ||
                (updatedUser.Address != null && updatedUser.Address.Trim().Length > 50))
            {
                // return a 400 response
                return BadRequest();
            }

            // find user in in-memory DB
            User oldUser =_inMemoryDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (oldUser == null)
            {
                // return a 404 response
                return NotFound();
            }

            // update fields
            oldUser.Name = updatedUser.Name;
            oldUser.Age = updatedUser.Age;
            oldUser.Address = updatedUser.Address;

            // update user to in-memory DB
            _inMemoryDbContext.Users.Update(oldUser);
            _inMemoryDbContext.SaveChanges();

            // return a 204 response
            return new NoContentResult();
        }

        
    }
}
