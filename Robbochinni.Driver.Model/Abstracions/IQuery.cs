namespace Robbochinni.Driver.Mag.Abstracions
{
    public interface IQuery<INPUT, OUTPUT>
    {
        public IQuery<INPUT, OUTPUT> SetInput(INPUT input);
        public Task<OUTPUT> Get();
        public Task<List<OUTPUT>> GetMany();
        public Task<bool> IsExist();
    }
}
