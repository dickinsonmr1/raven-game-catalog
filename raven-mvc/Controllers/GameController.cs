using System;
using System.Linq;
using System.Web.Http;
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

        public IHttpActionResult GetSingleGame(Guid gameId)
        {
            using (var session = RavenDbDataStore.DocumentStore.OpenSession())
            {
                var game = session.Query<Game>().FirstOrDefault(g => g.GameId == gameId);
                return Ok(game);
            }
        }

        [HttpGet]
        public void Add(string name, int releaseYear, string rating, string publisher, string description, string genre)
        {
            using (var session = RavenDbDataStore.DocumentStore.OpenSession())
            {
                var id = Guid.NewGuid();
                session.Store(new Game
                {
                    Id = id,
                    GameId = id,
                    Name = name,
                    ReleaseYear = releaseYear,
                    Rating = rating,
                    Description = description,
                    Genre = genre,
                    Publisher = publisher
                });
                session.SaveChanges();
            } 
        }

        //[HttpGet]
        //public void Edit(string name, int releaseYear, string rating, string publisher, string description, string genre)
        //{
        //    using (var session = RavenDbDataStore.DocumentStore.OpenSession())
        //    {
        //        session.Store(new Game
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = name,
        //            ReleaseYear = releaseYear,
        //            Rating = rating,
        //            Description = description,
        //            Genre = genre,
        //            Publisher = publisher
        //        });
        //        session.SaveChanges();
        //    }
        //}
    }
}
