using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShared.Data
{
    public class ComicBookArtistsRepository : BaseRepository<ComicBookArtist>
    {
       // private Context _context = null;

        public ComicBookArtistsRepository(Context context)
            :base(context)
        {
        }

        
        public override ComicBookArtist Get(int id, bool includeRealatedEntity = true)
        {
            var comicBookArtists = Context.ComicBookArtists.AsQueryable();
            if (includeRealatedEntity)
            {
                comicBookArtists = comicBookArtists
                        .Include(cba => cba.Artist)
                        .Include(cba => cba.Role)
                        .Include(cba => cba.ComicBook.Series);

            }

            return comicBookArtists
                .Where(cba => cba.Id == (int)id)
                .SingleOrDefault();
            //throw new NotImplementedException();
        }

        public override IList<ComicBookArtist> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
