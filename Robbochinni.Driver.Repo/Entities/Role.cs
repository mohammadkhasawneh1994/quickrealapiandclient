using Robbochinni.Driver.Mag.Abstracions;

namespace Robbochinni.Driver.Repo.Entities
{
    internal class Role : IEntity
    {
        public Guid Id { get; set; }
        public string? RoleName { get; set; }
        public DateTime CreateDate { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
