using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium_2_ko_s22454.Models;
using kolokwium_2_ko_s22454.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_2_ko_s22454.Services
{
    public class MusicianService : IMusicianService
    {
        private readonly MusicDbContext _context;

        public MusicianService(MusicDbContext context)
        {
            _context = context;
        }


        public async Task<MusicianGet> GetMusician(int id)
        {
            
            return await _context.Musicans
                .Include(e => e.MusicanTracks)
                .ThenInclude(e => e.Track)
                .Select(e => new MusicianGet
                {
                    IdMusican = e.IdMusican,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    NickName = e.NickName,
                    Tracks = e.MusicanTracks.Select(e => new MusicianGet.Track
                    {
                        IdTrack = e.IdTrack,
                        TrackName = e.Track.TrackName,
                        Duraturation = e.Track.Duraturation,
                        IdMusicAlbum = e.Track.IdMusicAlbum
                    })
                })
                .Where(e => e.IdMusican == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteMusician(int id)
        {
            var musician = await _context
                .Musicans
                .Where(e => e.IdMusican == id)
                .FirstOrDefaultAsync();

            if (musician is null)
            {
                return false;
            }

            IEnumerable<Track> tracks = await _context.Tracks
                .Include(e => e.MusicanTracks.Where(e => e.IdMusician == id))
                .ThenInclude(e => e.Musican)
                .ToArrayAsync();

            foreach (var t in tracks)
            {
                Console.WriteLine(t.IdMusicAlbum);
                if (t.IdMusicAlbum is not null)
                {
                    return false;
                }
            }

            _context.Musicans.Remove(musician);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}