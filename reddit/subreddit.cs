using System;
public class Subreddit{
    public string kind {get;set;}
    public SubRedditData data {get;set;}
}

public class SubRedditData{
    public SubRedditChild[] children {get;set;}
}
public class SubRedditChild{
    public ChildData data {get;set;}

}
public class ChildData{
    public string url {get;set;}
    public string title {get;set;}
    }