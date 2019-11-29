using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebVale.Models;
//using ProjetoWebVale.Models;

namespace ProjetoWebVale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateAllController : ControllerBase
    {
        private readonly ProjetoWebValeDbContext _context;
        public CreateAllController(ProjetoWebValeDbContext context)
        {
            this._context = context;
        }

        // POST api/CreateAll
        [HttpPost("")]
        public IActionResult Poststring()
        {
            try
            {
                var accountsToDelete = _context.Account.ToList();
                var usersToDelete = _context.User.ToList();
                var tasksToDelete = _context.Task.ToList();

                _context.Account.RemoveRange(accountsToDelete);
                _context.User.RemoveRange(usersToDelete);
                _context.Task.RemoveRange(tasksToDelete);
                _context.SaveChanges();

                var nomes = new List<string> { "Matheus Gurgel", "Luan Douglas", "Ruan Gondim", "Wellington Júnior" };
                var emails = new List<string> { "matheustf7@mail.com", "eny@mail.com", "rypgod@mail.com", "wj@mail.com" };
                var usernames = new List<string> { "matheustf7", "eny", "rypgod", "wj" };

                var createAccount = new Account() { Name = "LAR", Initials = "LAR" };
                var createUsers = new List<User>();

                for (int i = 0; i < 4; i++)
                {
                    var newUser = new User();
                    newUser.Email = emails[i];
                    newUser.Password = "senha";
                    newUser.Username = usernames[i];
                    newUser.Nome = nomes[i];

                    createUsers.Add(newUser);
                }

                createAccount.Users = createUsers;
                _context.Account.Add(createAccount);
                _context.SaveChanges();
                // var createTask = new Models.Task();
                return Ok("deu certo");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}