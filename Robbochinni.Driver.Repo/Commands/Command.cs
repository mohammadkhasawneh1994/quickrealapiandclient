using Mapster;
using Microsoft.EntityFrameworkCore;
using Robbochinni.Driver.Mag.Abstracions;
using Robbochinni.Driver.Mag.Exceptions;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Commands
{
    internal class Command<ENTITY, MODEL> : ICommand<MODEL> where ENTITY : class, IEntity
    {
        protected readonly DbCtx _ctx;
        protected DbSet<ENTITY> _entity => _ctx.Set<ENTITY>();

        public Command(DbCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<Guid> Delete(Guid? id)
        {
            var entity = await FindAsync(id);
            var result = _entity.Remove(entity!);
            await SaveAsync();

            return result.Entity.Id;
        }

        public async Task<Guid> Insert(MODEL model)
        {
            var entity = model.Adapt<ENTITY>();

            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;

            var insert = await _entity.AddAsync(entity);
            await SaveAsync();

            return insert.Entity.Id;
        }

        public async Task<Guid> Update<CUSTOM>(CUSTOM model, Guid? id)
        {
            var entity = await FindAsync(id);

            var clone = model.Adapt<MODEL>();
            var update = clone.Adapt(entity);

            await SaveAsync();

            return update!.Id;

        }

        private async Task SaveAsync()
        {
            int affectedRows = await _ctx.SaveChangesAsync();
            if(affectedRows < 1) throw new NoAffectedRowsException($"{nameof(MODEL)} command is not affected or not executed!");
        }

        private async Task<ENTITY> FindAsync(Guid? Id)
        {
            var entity = await _ctx.Set<ENTITY>().FindAsync(Id);
            if (entity is null) throw new EntityNotFoundException($"{nameof(MODEL)} command is not found with this id or not executed!");

            return entity;
        }
    }
}
