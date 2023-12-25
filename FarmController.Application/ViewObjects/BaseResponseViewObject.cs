namespace FarmController.Application.ViewObjects
{
    public class BaseResponseViewObject
    {
        public object? Data { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public BaseResponseViewObject(object data)
        {
            Data = data;
        }

        public BaseResponseViewObject(IEnumerable<string>? errors)
        {
            Errors = errors;
        }
    }
}
