namespace PrestoTraxSite.Models.Responses
{
    public class ResponseException : Exception
    {
        public ResponseException() : base()
        {
            
        }

        public ResponseException(string message) : base(message)
        {
            
        }
    }
}
