using Maktab.Sample.Blog.Abstraction.Exceptions;

namespace Maktab.Sample.Blog.Domain.Infirmaries;

public class InfirmaryDomainException : BaseException
{
    public InfirmaryDomainException(string message, int sequence) : base(message)
    {
        Code = $"InfirmaryDomain_{sequence}";
    }
}



public class BaseEmptyArgumentException : InfirmaryDomainException
{
    public BaseEmptyArgumentException(string argument, int sequence) : base($"{argument} can't be emtpy.", sequence)
    {
    }
}

public class EmptyInfirmaryNameException : BaseEmptyArgumentException
{
    public EmptyInfirmaryNameException() : base("Infirmary Name", 1)
    {
    }
}

public class EmptySupportedInsuranceException : BaseEmptyArgumentException
{
    public EmptySupportedInsuranceException() : base("Supported Insurance", 2)
    {
    }
}
public class EmptyStateException : BaseEmptyArgumentException
{
    public EmptyStateException() : base("State", 3)
    {
    }
}
public class EmptyCityException : BaseEmptyArgumentException
{
    public EmptyCityException() : base("City", 4)
    {
    }
}
public class EmptyStreetException : BaseEmptyArgumentException
{
    public EmptyStreetException() : base("Street", 5)
    {
    }
}
public class EmptyPhoneNumberException : BaseEmptyArgumentException
{
    public EmptyPhoneNumberException() : base("Phone Number", 6)
    {
    }
}

//public class EmptyAuthorIdException : BaseEmptyArgumentException
//{
//    public EmptyAuthorIdException() : base("Author id", 7)
//    {
//    }
//}

public class EmptyIsAroundTheClockException : BaseEmptyArgumentException
{
    public EmptyIsAroundTheClockException() : base("Is Around The Clock", 7)
    {
    }
}
