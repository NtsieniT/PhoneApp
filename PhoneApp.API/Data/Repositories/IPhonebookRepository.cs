using PhoneApp.API.Models;
using System.Threading.Tasks;

namespace PhoneApp.API.Data.Repositories
{
    public interface IPhonebookRepository
    {
        Task<Entry> AddEntry(Entry phonebook);
        void DeleteEntry(int id);
    }
}