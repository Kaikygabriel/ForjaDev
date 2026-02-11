using ForjaDev.Domain.BackOffice.Commum;

namespace ForjaDev.Application.Services.Interfaces;

public interface IServiceEmail
{
    Task Send(EmailSendBuilder emailBuilder);
}