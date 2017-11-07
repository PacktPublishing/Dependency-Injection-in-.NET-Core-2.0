using PacktDIExamples.Common.Entities.User;

namespace PacktDIExamples.DataAccess
{
    public interface IUsersRepository
    {
        IUser GetUser(int userId);
    }
}