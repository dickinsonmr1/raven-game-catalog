using System;
using System.Linq;
using System.Web.Http;
using Raven.Client.Document;
using RavenGameCatalog.Models;

namespace RavenGameCatalog.Controllers
{
    public class GameController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var session = RavenDbDataStore.DocumentStore.OpenSession())
            {
                var games = session.Query<Game>().ToList();
                return Ok(games);
            }         
        }

        [HttpGet]
        public void AddGame(string title, int releaseYear, string rating, string publisher, string description, string genre)
        {
            using (var session = RavenDbDataStore.DocumentStore.OpenSession())
            {
                session.Store(new Game
                {
                    Id = Guid.NewGuid(),
                    Name = title,
                    ReleaseYear = releaseYear,
                    Rating = rating,
                    Description = description,
                    Genre = genre,
                    Publisher = publisher
                });
                session.SaveChanges();
            } 
        }

        [HttpGet]
        public void EditGame(string title, int releaseYear, string rating, string publisher, string description, string genre)
        {
            using (var session = RavenDbDataStore.DocumentStore.OpenSession())
            {
                session.Store(new Game
                {
                    Id = Guid.NewGuid(),
                    Name = title,
                    ReleaseYear = releaseYear,
                    Rating = rating,
                    Description = description,
                    Genre = genre,
                    Publisher = publisher
                });
                session.SaveChanges();
            }
        }

        [HttpGet]
        public void RemoveGame(Guid id)
        {
            using (var session = RavenDbDataStore.DocumentStore.OpenSession())
            {
                var gameToRemove = session.Load<Game>().FirstOrDefault(g => g.Id == id);
                if (gameToRemove != null)
                {
                    session.Delete(gameToRemove);
                    session.SaveChanges();
                }
            }
        }
    }
}
