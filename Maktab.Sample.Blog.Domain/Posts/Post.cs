using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Comments;
using Maktab.Sample.Blog.Domain.Likes;
using Maktab.Sample.Blog.Domain.Users;

namespace Maktab.Sample.Blog.Domain.Posts;

public class Post : BaseEntity
{
    public Post(string title, string postText, Guid authorId)
    {
        Title = title;
        PostText = postText;
        AuthorId = authorId;
        Validate();
    }
    /// <summary>
    /// Title of The Post
    /// </summary>
    public string Title { get; private set; }
    /// <summary>
    /// Text of The Post
    /// </summary>
    public string PostText { get; private set; }
    /// <summary>
    /// Id of The Athor for Navigation Purposes
    /// </summary>
    public Guid AuthorId { get; private set; }
    /// <summary>
    /// An Instance of The User Object for Navigation Purposes
    /// </summary>
    public User Author { get; private set; }
    /// <summary>
    /// Each Post Can Be Consists of List of Comments
    /// </summary>
    public List<Comment> Comments { get; private set; } = new();
    /// <summary>
    /// Each Post Can Be Consists of List of Comments
    /// </summary>
    public List<Like> Likes { get; private set; } = new();
    
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Title))
            throw new EmptyPostTitleException();

        if (string.IsNullOrWhiteSpace(PostText))
            throw new EmptyPostTextException();

        if (AuthorId == null || AuthorId == Guid.Empty)
            throw new EmptyAuthorIdException();
    }

    public void SetPostInfo(string title, string text)
    {
        if (!string.IsNullOrWhiteSpace(title))
            Title = title;
        
        if (!string.IsNullOrWhiteSpace(text))
            PostText = text;
    }
}