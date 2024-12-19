
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.prescription;
using Microsoft.AspNetCore.Identity;

namespace Maktab.Sample.Blog.Domain.Users;

public class User : IdentityUser<Guid>
{
    
    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Validate();
    }
    /// <summary>
    /// First Name of The User
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Last Name of The User
    /// </summary>
    public string LastName { get; set; }



    //********************* Navigation Properties ********************//

    /// <summary>
    /// Each User Can Write Many Posts
    /// </summary>
    public List<Post> Posts { get; set; } = new();

    /// <summary>
    /// Each User Can Have Many Patients
    /// </summary>

    public List<Patient> Patients { get; set; } = new();

    /// <summary>
    /// Each User Have Many Prescriptions
    /// </summary>

    public List<Prescription> Prescriptions { get; set; } = new();

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



    protected void Validate()
    {
        if (string.IsNullOrWhiteSpace(FirstName))
            throw new EmptyFirstNameException();

        if (string.IsNullOrWhiteSpace(LastName))
            throw new EmptyLastNameException();

        
    }
}