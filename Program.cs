using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Linq;

namespace steamStreamSports
{
    class Program
    {
        static void Main(string[] args)
        {
            NFL service = new NFL();
            List<NFLGame> games = service.GetGames();
            
        }

    }
    
}
