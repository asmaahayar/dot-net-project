namespace WebFrontend.Models
{
    public class ResponseDto
    {
        public bool success { get; set; } = true;
        public object result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> errorMessages { get; set; }
    }
}
