namespace BusWebAPI.Application.CustomValidations
{
    public class IsNullOrEmpty : ICustomValidation
    {
        public bool IsValid(object? val)
        {
            if (val == null || val.ToString().Trim() == "")
                return false;

            return true;
        }
    }
}
