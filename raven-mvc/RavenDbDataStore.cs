using Raven.Client;
using Raven.Client.Document;

namespace RavenGameCatalog
{
    public class RavenDbDataStore
    {
        public new IDocumentSession Session { get; set; }

        private static IDocumentStore documentStore;

        public static IDocumentStore DocumentStore
        {
            get
            {
                if (documentStore != null)
                    return documentStore;

                lock (typeof (RavenDbDataStore))
                {
                    if (documentStore != null)
                        return documentStore;

                    documentStore = new DocumentStore
                    {
                        Url = "http://localhost:8088",
                        DefaultDatabase = "Games"
                    }.Initialize();
                }
                return documentStore;
            }
        }
    }
}