using System;
public class CommentThread{
    public string kind {get;set;}
    public CommentThreadData data {get;set;}
}

public class CommentThreadData{
    public string modHash{get;set;}
    public int? dist{get;set;}
    public CommentThreadChild[] children {get;set;}
    public int? after{get;set;}
    public int? before{get;set;}
}
public class CommentThreadChild{
    public string kind {get;set;}
    public CommentData data {get;set;}

}
public class CommentData{
    public string body {get;set;}
    public string permalink {get;set;}
    public string name {get;set;}
}
