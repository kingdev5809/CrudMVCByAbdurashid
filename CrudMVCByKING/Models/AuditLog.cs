namespace CrudMVCByKING.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Action { get; set; } 
        public string? EntityName { get; set; } 
        public string? EntityId { get; set; } 
        public DateTime TimeStamp { get; set; }
    }

}
