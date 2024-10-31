namespace Robbochinni.Driver.Mag.Abstracions
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
