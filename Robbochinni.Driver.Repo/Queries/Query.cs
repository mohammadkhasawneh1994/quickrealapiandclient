using Mapster;
using Microsoft.EntityFrameworkCore;
using Robbochinni.Driver.Mag.Abstracions;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Queries
{
    internal abstract class Query<INPUT, ENTITY, OUTPUT> : IQuery<INPUT, OUTPUT> where ENTITY : class, IEntity
    {
        protected readonly DbCtx _ctx;
        protected Query(DbCtx ctx)
        {
            _ctx = ctx;
        }

        protected INPUT input;

        protected IQueryable<ENTITY> Entity => _ctx.Set<ENTITY>();
        protected abstract IQueryable<ENTITY> Queryable { get; }
        public async Task<OUTPUT> Get()
        {
            var entity = await Queryable.FirstOrDefaultAsync();
            var value = entity.Adapt<OUTPUT>();

            return value;
        }

        public async Task<List<OUTPUT>> GetMany()
        {
            var entities = await Queryable.ToListAsync();
            var values = entities.Adapt<List<OUTPUT>>();

            return values;
        }

        public async Task<bool> IsExist()
        {
            return await Queryable.AnyAsync();
        }

        public IQuery<INPUT, OUTPUT> SetInput(INPUT input)
        {
            this.input = input; 
            return this;
        }
    }
}
