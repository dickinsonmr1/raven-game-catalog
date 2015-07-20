using System;
using System.Linq;
using System.Web.Http;
using RavenGameCatalog.Models;

namespace RavenGameCatalog.Controllers
{
    public class EditController : ApiController
    {
        [HttpGet]
        public void Update(Guid gameId, string name, int releaseYear, string rating, string publisher, string description, string genre)
        {
            using (var session = RavenDbDataStore.DocumentStore.OpenSession())
            {

                var game = session.Query<Game>().FirstOrDefault(g => g.GameId == gameId);
                if (game != null)
                {
                    game.Name = name;
                    game.ReleaseYear = releaseYear;
                    game.Rating = rating;                    
                    game.Publisher = publisher;
                    game.Description = description;
                    game.Genre = genre;
                }
                session.SaveChanges();
            }
        }
    }
}
