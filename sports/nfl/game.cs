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
    public class NFLGame{
        public NFLTeam Home {get;set;}
        public NFLTeam Away {get;set;}
        public DateTime GameStart {get;set;}
        public int HomeScore {get;set;}
        public int AwayScore {get;set;}
        public string ThreadLink {get;set;}
        public string StreamLink {get;set;}
        public void AddStream(){
            WebRequest request = WebRequest.Create($"{this.ThreadLink}.json");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream ();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader (dataStream);
            JsonTextReader jReader = new JsonTextReader(reader);
            // Read the content.
            string responseFromServer = reader.ReadToEnd ();
            CommentThread[] threads = JsonConvert.DeserializeObject<CommentThread[]>(responseFromServer);
            CommentThreadChild[] comments = threads[1].data.children;

            List<CommentThreadChild> aceThreads = comments.Where(x => x.data.body.IndexOf("acestream://")!=-1).ToList();
            if(aceThreads.Count > 0){
                string topAceStream = aceThreads[0].data.body;
                string aceLink = topAceStream.Substring(topAceStream.IndexOf("acestream://"));
                if(aceLink.IndexOf(" ") == -1){
                    aceLink = aceLink.Trim();
                }else{
                    aceLink = aceLink.Substring(0,aceLink.IndexOf(" "));
                }
                this.StreamLink = aceLink;
            }
            // Cleanup the streams and the response.
            reader.Close ();
            dataStream.Close ();
            response.Close ();
        }
    }
}