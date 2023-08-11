namespace walkerscott_api.Response
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }

        public T? Data { get; set; }

        public Errors? Errors { get; set; }

    }

    public class Errors
    {
        public List<string>? ErrorDescription { get; set; }
    }
}
