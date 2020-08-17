using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneApp.API.Data.Repositories
{
    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly DataContext _context;

        public PhonebookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Entry> AddEntry(Entry phonebook)
        {
            await _context.Entries.AddAsync(phonebook);
            await _context.SaveChangesAsync();

            return phonebook;
        }

        public void DeleteEntry(int id)
        {
            var entry =  _context.Entries.Find(id);
            if (entry != null)
            {
                _context.Entries.Remove(entry);
                 _context.SaveChangesAsync();
            }
           
        }

    }
}
