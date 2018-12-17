using System;
public class Subreddit{
    public string kind {get;set;}
    public SubRedditData data {get;set;}
}

public class SubRedditData{
    public string modHash{get;set;}
    public int dist{get;set;}
    public SubRedditChild[] children {get;set;}
    public int? after{get;set;}
    public int? before{get;set;}
}
public class SubRedditChild{
    public string kind {get;set;}
    public ChildData data {get;set;}

}
public class ChildData{
    public string subreddit_name {get;set;}
    public string url {get;set;}
    public string title {get;set;}
    }