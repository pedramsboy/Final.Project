using Maktab.Sample.Blog.Domain.Comments;
using Maktab.Sample.Blog.Domain.Likes;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.AspNetCore.Identity;

namespace Maktab.Sample.Blog.Domain.Users;

public class User : IdentityUser<Guid>
{
    private User()
    {
    }
    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    /// <summary>
    /// First Name of The User
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Last Name of The User
    /// </summary>
    public string LastName { get; set; }
    
    public List<Post> Posts { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    public List<Like> Likes { get; set; } = new();

    /// <summary>
    /// The Date Time  of The Data Has Been Created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    /// <summary>
    /// The Date Time  of The Data Has Been Updated
    /// </summary>
    public DateTime? ModifiedAt { get; set; }
    /// <summary>
    /// Check If Data Has Been Deleted Or Not
    /// </summary>
    public bool IsDeleted { get; set; }
    /// <summary>
    /// The Date Time  of The Data Has Been Deleted
    /// </summary>
    public DateTime? DeletedAt { get; set; }
}