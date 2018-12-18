using System;
public class CommentThread{
    public string kind {get;set;}
    public CommentThreadData data {get;set;}
}

public class CommentThreadData{
    public CommentThreadChild[] children {get;set;}
}
public class CommentThreadChild{
    public CommentData data {get;set;}

}
public class CommentData{
    public string body {get;set;}
    public string permalink {get;set;}
    public string name {get;set;}
}
