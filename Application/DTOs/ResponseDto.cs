namespace Application.DTOs
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }

        public ResponseDto(bool success, T? data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }

        public ResponseDto(T? data) : this(true, data, string.Empty) { }

        public ResponseDto(string message) : this(false, default(T), message) { }
    }
}
