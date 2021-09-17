namespace TodoApp.Shared
{
    public class Response<T>
    {
        public int StatusCode { get; set; }

        public T Data { get; set; }

        public string ErrorMessage { get; set; }
    }
}
