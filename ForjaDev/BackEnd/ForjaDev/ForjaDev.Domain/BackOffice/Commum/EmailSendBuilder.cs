namespace ForjaDev.Domain.BackOffice.Commum;

public class EmailSendBuilder
{
    private EmailSendBuilder()
    {
        
    }
    
    public string ToAddress { get;private set; }
    public string Body { get;private set; }
    public string Title { get;private set; }

    public static EmailSendBuilder Configure()
        => new();

    public EmailSendBuilder To(string toAddress)
    {
        ToAddress = toAddress;
        return this;
    }
    
    public EmailSendBuilder WithTitle(string title)
    {
        Title = title;
        return this;
    }
    
    public EmailSendBuilder WithBody(string body)
    {
        Body = body;
        return this;
    }
}