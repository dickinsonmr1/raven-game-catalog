using System;
using System.Linq;
using System.Web.Http;
using Raven.Client.Document;
using RavenGameCatalog.Models;

namespace RavenGameCatalog.Controllers
{
    public class RemoveController : ApiController
    {
        [HttpGet]
        public void Get(Guid gameId)
        {
            using (var session = RavenDbDataStore.DocumentStore.OpenSession())
            {
                var gameToRemove = session.Load<Game>().FirstOrDefault(g => g.GameId == gameId);
                if (gameToRemove != null)
                {
                    session.Delete(gameToRemove);
                    session.SaveChanges();
                }
            }
        }
    }
}
