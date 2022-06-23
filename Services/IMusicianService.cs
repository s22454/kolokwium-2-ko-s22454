using System.Threading.Tasks;
using kolokwium_2_ko_s22454.Models.DTOs;

namespace kolokwium_2_ko_s22454.Services
{
    public interface IMusicianService
    {
        public Task<MusicianGet> GetMusician(int id);
        public Task<bool> DeleteMusician(int id);
    }
}