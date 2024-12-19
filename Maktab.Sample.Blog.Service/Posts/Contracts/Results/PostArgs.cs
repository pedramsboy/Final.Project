using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Service.Users.Contracts.Result;

namespace Maktab.Sample.Blog.Service.Posts.Contracts.Results;


public class PostArgs: GeneralResult
{
    public string Title { get; set; }
    public string Text { get; set; }
    public UserArgs? Author { get; set; }
    
}

public static class PostArgsMapper
{
    public static PostArgs MapToPostArgs(this Post post)
    {
        return new PostArgs
        {
            Id = post.Id,
            Title = post.Title,
            Text = post.PostText,
            Author = post.Author?.MapToUserArgs(),
           
        };
    }
}