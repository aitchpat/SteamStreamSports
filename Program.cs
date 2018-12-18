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
            var shortcutsFile = new StreamReader(@"C:\Program Files (x86)\Steam\userdata\45063689\config\shortcuts.vdf",true);
            string shortcuts = shortcutsFile.ReadToEnd();
            shortcutsFile.Close();
            foreach (NFLGame game in games)
            {
                shortcuts = shortcuts.Replace("nflgame",$" {game.Away.Location} {game.Away.Name} at {game.Home.Location} {game.Home.Name} - {game.GameStart.ToShortTimeString()} ");
                shortcuts = shortcuts.Replace("streamid",$"{game.StreamLink}");
                using(StreamWriter sw = new StreamWriter(@"C:\Program Files (x86)\Steam\userdata\45063689\config\shortcuts.vdf",false)){
                    sw.Write(shortcuts);
                }
            };
            Console.WriteLine(shortcuts);
        }
        public void AddGamesToSteam(List<NFLGame> games)
        {
            var shortcutsFile = new StreamReader(@"C:\Program Files (x86)\Steam\userdata\45063689\config\shortcuts.vdf",true).ReadToEnd();
            foreach (NFLGame game in games)
            {
                shortcutsFile.Replace("steamStreamSports.NFLTeam at steamStreamSports.NFLTeam - 8:15 PM",$"{game.Away} at {game.Home} - {game.GameStart.ToShortTimeString()}");
                shortcutsFile.Replace(@"D:\Libraries\Videos\Fortnite\Fortnite 01.15.2018 - 22.44.00.10.DVR.mp4",game.StreamLink);
                StreamWriter sw = new StreamWriter(@"C:\Program Files (x86)\Steam\userdata\45063689\config\shortcuts.vdf",true);
                sw.Write(shortcutsFile);
                sw.Close();
            };
        }

    }
    
}
