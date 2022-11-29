namespace API_Mokymai.Models.Dto
{
    public class GetLoggingResult
    {
        public GetLoggingResult(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Issaugota kazkokia zinute
        /// </summary>
        public string Message { get; set; }


    }
}
