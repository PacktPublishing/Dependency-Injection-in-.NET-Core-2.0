using PacktDIExamples.Common;
using PacktDIExamples.Common.Entities.User;
using PacktDIExamples.DataAccess;

namespace PacktDIExamples.Business
{
    internal class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IUser GetUser(int userId) => _usersRepository.GetUser(userId);
    }
}