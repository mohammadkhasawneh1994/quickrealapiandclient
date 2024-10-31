using Robbochinni.Driver.Mag.Abstracions;

namespace Robbochinni.Driver.Repo.Entities
{
    internal class Car : IEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public string? Color { get; set; }
        public int? Ref { get; set; }
        public int? Number { get; set; }
        public int? RideType { get; set; }
        public Location? AvaialableIn { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid DriverId { get; set; }
        public User? Driver { get; set; }
    }
}
