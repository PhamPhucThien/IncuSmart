namespace IncuSmart.API.Responses

{
    public class BaseResponse<T>
    {
        public StatusCode StatusCode { get; set; } = StatusCode.SUCCESS;
        public string Message { get; set; } = "";
        public T Data { get; set; } = default!;
    }
}
