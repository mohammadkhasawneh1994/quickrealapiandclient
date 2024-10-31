using Robbochinni.Driver.Mag.Abstracions;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Mag.Output;

namespace Robbochinni.Driver.Business.Operations
{
    public class RoleManager
    {
        private readonly ICommand<AddRole> _roleCommand;
        private readonly IQuery<AllQuery, RoleInfo> _getAllRoles;

        public RoleManager(ICommand<AddRole> roleCommand)
        {
            _roleCommand = roleCommand;
        }
        public async Task GetAll()
        {
            var data = await _getAllRoles.SetInput(new AllQuery(true)).GetMany();
        }


        public async Task Insert(string Name)
        {
            var data = await _roleCommand.Insert(new AddRole(Name));
        }
    }
}
