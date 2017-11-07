using PacktDIExamples.Common.Entities.User;

namespace PacktDIExamples.Common
{
    public interface IUsersService
    {
        IUser GetUser(int userId);
    }
}