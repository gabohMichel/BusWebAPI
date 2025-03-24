namespace BusWebAPI.Domain.Common
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public short StatusCode { get; set; }
        public Response()
        {
                
        }
        public Response(T? data, bool success, string? message, short statusCode)
        {
            Data = typeof(T) == typeof(string) ? (T)(object)string.Empty : default;
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }
    }
}
