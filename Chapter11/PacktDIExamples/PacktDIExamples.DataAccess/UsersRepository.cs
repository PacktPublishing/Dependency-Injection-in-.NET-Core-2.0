using PacktDIExamples.Common.Entities.User;

namespace PacktDIExamples.DataAccess
{
    internal class UsersRepository : IUsersRepository
    {
        // Here we are returning dummy data. You can return data from database from this method.
        public IUser GetUser(int userId) => new User { UserId = 1, UserName = "Tadit" };

        // new DataContext().Users.SingleOrDefault(u => u.UserId == userId);
    }
}