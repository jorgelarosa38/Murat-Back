namespace ProjectMurat.Utilities
{
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string access_token { get; set; }
        public int Expires_int { get; set; }
    }
}
