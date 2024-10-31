using Robbochinni.Driver.Mag.Abstracions;

namespace Robbochinni.Driver.Repo.Entities
{
    internal class Trip : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int State { get; set; }
        public Location? From { get; set; }
        public Location? To { get; set; }
        public DateTime CancellationDate { get; set; }
        public DateTime ArrivingDate { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public Guid DriverId { get; set; }
        public string? ConfirmationCode { get; set; }

        public Guid RequesterId { get; set; }
        public User? Requester { get; set; }
    }

    public record Location
    {
        public Guid Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string? Name { get; set; }
    }
}
