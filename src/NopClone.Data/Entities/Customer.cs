using NopClone.Data.Entities.Base;

namespace NopClone.Data.Entities;

public class Customer : BaseEntity<string>
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Surname { get; set; }

    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}