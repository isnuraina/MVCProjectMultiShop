namespace Bigon.WebUI.Models.Entities
{
    public class Subscriber
    {
        public string Email { get; set; }
        public bool Approved { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
