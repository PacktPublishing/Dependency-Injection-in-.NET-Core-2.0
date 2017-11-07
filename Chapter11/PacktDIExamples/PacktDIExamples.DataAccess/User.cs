using PacktDIExamples.Common.Entities.User;

namespace PacktDIExamples.DataAccess
{
    internal class User : IUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}