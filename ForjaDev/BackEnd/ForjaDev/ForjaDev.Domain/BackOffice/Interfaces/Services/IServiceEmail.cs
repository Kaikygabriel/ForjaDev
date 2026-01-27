using ForjaDev.Domain.BackOffice.Commum;

namespace ForjaDev.Domain.BackOffice.Interfaces.Services;

public interface IServiceEmail
{
    Task Send(EmailSendBuilder emailBuilder);
}