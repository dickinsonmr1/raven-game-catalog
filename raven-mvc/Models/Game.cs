using System;
using System.Collections.Generic;

namespace RavenGameCatalog.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string Rating { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }

        public List<Programmer> Programmers { get; set; }

        public List<string> Tags { get; set; } 

        public Game()
        {
            Programmers = new List<Programmer>();
            Tags = new List<string>();
        }
    }

    public class Programmer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
