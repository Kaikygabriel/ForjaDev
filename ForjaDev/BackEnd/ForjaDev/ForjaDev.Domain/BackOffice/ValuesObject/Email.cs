using ForjaDev.Domain.BackOffice.Commum;

namespace ForjaDev.Domain.BackOffice.ValuesObject;

public class Email
{
    private Email()
    {
        
    }
    private Email(string address)
    {
        Address = address;
    }

    public string Address { get;private set; }

    public static class Factory
    {
        public static Result<Email> Create(string address)
            => Result<Email>.Success(new(address));
    }
}