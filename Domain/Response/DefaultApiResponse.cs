namespace Domain.Response
{
    public class DefaultApiResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
                
        public DefaultApiResponse(T data)
        {
            Data = data;
            Success = true;
        }

        public DefaultApiResponse(string message)
        {
            Message = message;
            Success = false;
        }

        public DefaultApiResponse(List<string> errors)
        {
            Errors = errors;
            Success = false;
        }
    }
}