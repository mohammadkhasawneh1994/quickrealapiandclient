using Robbochinni.Driver.Mag.Abstracions;

namespace Robbochinni.Driver.Repo.Entities
{
    internal class User : IEntity
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; } 
        public string? Email { get; set; } 
        public string? Password { get; set; } 
        public string? Mobile { get; set; } 
        public string? Varification { get; set; } 

        public Guid RoleId { get; set; } 
        public Role? Role { get; set; }

        public Car? Car { get; set; }

        public DateTime CreateDate { get; set; } 
        public bool IsLocked { get; set; } 

        public ICollection<Trip>? Requests { get; set; }
    }
}
