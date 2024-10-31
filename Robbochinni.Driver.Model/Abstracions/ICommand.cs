namespace Robbochinni.Driver.Mag.Abstracions
{
    public interface ICommand<MODEL>
    {
        public Task<Guid> Insert(MODEL model);
        public Task<Guid> Update<CUSTOM>(CUSTOM model, Guid? id);
        public Task<Guid> Delete(Guid? id);
    }
}
