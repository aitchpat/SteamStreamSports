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

namespace steamStreamSports{
    class NFL{
        private List<NFLTeam> _teams {
            get{
                List<NFLTeam> teamList = new List<NFLTeam>();
                return teamList;
            }
        }
        public List<NFLGame> GetGames(){
            WebRequest request = WebRequest.Create("https://www.reddit.com/r/nflstreams.json");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream ();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader (dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            Subreddit nflStreams = JsonConvert.DeserializeObject<Subreddit>(responseFromServer);
            List<SubRedditChild> gameThreads = new List<SubRedditChild>();
            foreach (SubRedditChild thread in nflStreams.data.children)
            {
                if(thread.data.title.IndexOf(" Thread")!=-1){
                    gameThreads.Add(thread);
                }
            }
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
            List<NFLGame> games = new List<NFLGame>();
            foreach (SubRedditChild thread in gameThreads)
            {
                string threadTitle = thread.data.title;
                if(threadTitle.IndexOf("RedZone") != -1){
                    NFLTeam rzTeam = new NFLTeam{
                        Location = "Redzone -",
                        Name = threadTitle.Substring(threadTitle.IndexOf(":")+1)
                    };
                    NFLGame rzGame = new NFLGame{
                        Home = rzTeam,
                        ThreadLink = thread.data.url
                    };
                    rzGame.AddStream();
                    games.Add(rzGame);
                    Console.WriteLine($"{rzGame.Home.Location} {rzGame.Home.Name}");
                    Console.WriteLine($"{rzGame.StreamLink}");
                }
                else{
                    string awayPart = threadTitle.Substring(threadTitle.IndexOf(":")+1,threadTitle.IndexOf("@") - threadTitle.IndexOf(":")+-2).Trim();
                    NFLTeam awayTeam = new NFLTeam{
                        Location = awayPart.Substring(0,awayPart.LastIndexOf(" ")).Trim(),
                        Name = awayPart.Substring(awayPart.LastIndexOf(" ")).Trim()
                    };
                    string homePart = threadTitle.Substring(threadTitle.IndexOf("@")+1,threadTitle.IndexOf("(") - threadTitle.IndexOf("@")-2).Trim();
                    string[] home = homePart.Split(" ");
                    NFLTeam homeTeam = new NFLTeam{
                        Location = homePart.Substring(0,homePart.LastIndexOf(" ")).Trim(),
                        Name = homePart.Substring(homePart.LastIndexOf(" ")).Trim()
                    };
                    string timePart = threadTitle.Substring(threadTitle.IndexOf("(")+1,threadTitle.IndexOf(")") - threadTitle.IndexOf("(")-2).Trim();
                    string[] times = timePart.Split(":");
                    double hours = double.Parse(times[0].Substring(0,2));
                    double minutes = double.Parse(times[1].Substring(0,2));
                    DateTime utcMidnight = new DateTime(DateTime.UtcNow.Year,DateTime.UtcNow.Month,DateTime.UtcNow.Day);
                    DateTime gameTime = utcMidnight.AddHours(hours + 5).AddMinutes(minutes);
                    
                    NFLGame game = new NFLGame{
                        Away = awayTeam,
                        Home = homeTeam,
                        GameStart = gameTime.ToLocalTime(),
                        ThreadLink = thread.data.url
                    };
                    game.AddStream();
                    games.Add(game);
                    Console.WriteLine($"{game.Away.Location} {game.Away.Name} at {game.Home.Location} {game.Home.Name} at {game.GameStart.ToLongTimeString()}");
                    Console.WriteLine($"{game.StreamLink}");
                }
            }
            return games;
        }
    }
}