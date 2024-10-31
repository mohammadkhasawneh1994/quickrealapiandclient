using Robbochinni.Driver.Mag.Abstracions;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Mag.Statics;

namespace Robbochinni.Driver.Business.Operations
{
    public class AuthManager : Manager
    {
        private readonly ICommand<AddUser> _userCommand;
        private readonly IQuery<UserLogin, UserInfo> _loginQuery;

        private readonly IQuery<UserByMobile, UserInfo> _userByMobileQuery;
        private readonly IQuery<UserByEmail, UserInfo> _userByEmailQuery;
        private readonly IQuery<AllQuery, UserInfo> _allUsersQuery;

        public AuthManager(ResultBuilder resultBuilder,
                           ICommand<AddUser> userCommand,
                           IQuery<UserLogin, UserInfo> loginQuery,
                           IQuery<UserByEmail, UserInfo> userByEmailQuery,
                           IQuery<UserByMobile, UserInfo> userByMobileQuery,
                           IQuery<AllQuery, UserInfo> allUsersQuery) : base(resultBuilder)
        {
            _userCommand = userCommand;
            _loginQuery = loginQuery;
            _userByEmailQuery = userByEmailQuery;
            _userByMobileQuery = userByMobileQuery;
            _allUsersQuery = allUsersQuery;
        }

        public async Task<Result> Signup(AddUser addUser)
        {
            try
            {
                _userByMobileQuery.SetInput(new UserByMobile(addUser.Phone));
                var isUserMobileExist = await _userByMobileQuery.IsExist();

                _userByEmailQuery.SetInput(new UserByEmail(addUser.Email));
                var isUserEmailExist = await _userByEmailQuery.IsExist();

                if (isUserEmailExist || isUserMobileExist) throw new Exception("User Already Exist");

                var Id = await _userCommand.Insert(addUser);

                return _resultBuilder.Success!
                    .SetMessage("User Added")
                    .SetPayload(Id);
                    
            }
            catch (Exception ex)
            {
                return _resultBuilder.Error!.SetException(ex);
            }
            
        }

        public async Task<Result> Login(UserLogin login)
        {
            try
            {
                _loginQuery.SetInput(login);
                var result = await _loginQuery.Get();

                if (result == null) return _resultBuilder.Error!.SetStatusCode(401);

                return _resultBuilder.Success!
                    .SetMessage("Entity Found")
                    .SetPayload(new Token(result.Encode(), result.Id, result.Role, result.FullName!));

            }
            catch (Exception ex)
            {
                return _resultBuilder.Error!.SetException(ex);
            }

        }

        public async Task<Result> GetAll()
        {
            try
            {
                var users = await _allUsersQuery.GetMany();

                return _resultBuilder.Success!
                    .SetMessage("Entity Found")
                    .SetPayload(users);

            }
            catch (Exception ex)
            {
                return _resultBuilder.Error!.SetException(ex);
            }

        }
    }
}
