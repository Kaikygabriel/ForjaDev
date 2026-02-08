using System.Text.Json.Serialization;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;

namespace ForjaDev.Domain.BackOffice.ValuesObject;

public class Link
{
    public Link()
    {
        
    }
    public Link(string placeOfOrigin, string address)
    {
        PlaceOfOrigin = placeOfOrigin;
        Address = address;
    }
    
    public string PlaceOfOrigin { get;init; }
    public string Address { get;init; }

    public static class Factory
    {
        public static Result<Link> Create(string placeOfOrigin, string address)
        {
            if (ParametersOfCreationIsInvalid(placeOfOrigin, address))
                return new Error("Parameters.IsInvalid", "Parameters creation is invalid!");
            return Result<Link>.Success(new(placeOfOrigin, address));
        }
    }

    private static bool ParametersOfCreationIsInvalid(string placeOfOrigin, string address)
    {
        if (string.IsNullOrWhiteSpace(placeOfOrigin) || placeOfOrigin.Length <= 1)
            return true;
        if (string.IsNullOrWhiteSpace(address) || address.Length <=4)
            return true;
        return false;
    }
}