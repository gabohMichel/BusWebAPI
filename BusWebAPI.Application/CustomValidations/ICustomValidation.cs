namespace BusWebAPI.Application.CustomValidations
{
    public interface ICustomValidation
    {
        bool IsValid(object? val);
    }
}
