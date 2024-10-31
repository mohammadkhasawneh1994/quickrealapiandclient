using Robbochinni.Driver.Mag.Output;

namespace Robbochinni.Driver.Mag.Abstracions
{
    public class Manager
    {
        protected readonly ResultBuilder _resultBuilder;

        public Manager(ResultBuilder resultBuilder)
        {
            _resultBuilder = resultBuilder;
        }
    }
}
