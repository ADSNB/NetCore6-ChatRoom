namespace NetCoreChatRoom.Models
{
    public class JsonErrorResultModel
    {
        public string Message { get; set; }
        public string Details { get; set; }

        public static JsonErrorResultModel FromException(Exception ex) => new JsonErrorResultModel()
        {
            Details = ex.ToString(),
            Message = ex.Message
        };
    }
}