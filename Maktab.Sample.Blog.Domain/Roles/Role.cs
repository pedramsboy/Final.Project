using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Maktab.Sample.Blog.Domain.Roles;

public class Role : IdentityRole<Guid>
{


    /// <summary>
    /// The Date Time  of The Data Has Been Created
    /// </summary>
    public DateTime CreatedAt { get; set; }
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
