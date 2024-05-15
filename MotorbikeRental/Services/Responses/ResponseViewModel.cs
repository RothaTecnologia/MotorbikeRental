namespace MotorbikeRental.Services.Responses
{
    public class ResponseViewModel<T>
    {
        public T Response { get; set; }
        public string Message { get; set; }
    }
}
