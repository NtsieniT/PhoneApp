using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneApp.API.Data;
using PhoneApp.API.Data.Repositories;
using PhoneApp.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IPhonebookRepository _repository;
        private readonly DataContext _context;

        public EntriesController(IPhonebookRepository repository, DataContext context)
        {
            _repository = repository;
            _context = context;
        }

        // GET: api/<Entries>
        [HttpGet("All")]
        public async Task<IActionResult> GetEntries()
        {
            var entries = await _context.Entries.ToListAsync();
            return  Ok(entries);
        }

        // GET api/<Entries>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry(int id)
        {
            var entry = await _context.Entries.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(entry);
        }

        // POST api/<Entries>
        [HttpPost("AddEntry")]
        public async Task<IActionResult> AddEntry(Entry entry)
        {
            await _repository.AddEntry(entry);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteEntry(id);
        }


    }
}
