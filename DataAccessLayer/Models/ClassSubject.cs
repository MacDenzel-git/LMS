namespace DataAccessLayer.Models;

public sealed class ClassSubject : BaseEntity
{
    public Guid ClassRoomId { get; set; }
    public Guid SubjectId { get; set; }
}
