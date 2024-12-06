using Maktab.Sample.Blog.Abstraction.Exceptions;

namespace Maktab.Sample.Blog.Domain.Roles;

public class RoleDomainException : BaseException
{
    public RoleDomainException(string message, int sequence) : base(message)
    {
        Code = $"RoleDomain_{sequence}";
    }
}

public class EmptyRoleNameException : RoleDomainException
{
    public EmptyRoleNameException() : base("Role name can't be empty", 1)
    {
    }
}
public class EmptyRoleDescriptionException : RoleDomainException
{
    public EmptyRoleDescriptionException() : base("Role Description can't be empty", 2)
    {
    }
}