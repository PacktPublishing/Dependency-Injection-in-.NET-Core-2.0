using Microsoft.AspNetCore.Mvc;
using PacktDIExamples.Common;

namespace PacktDIExamples.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public IActionResult Edit(int userId)
        {
            return View(_usersService.GetUser(userId));
        }

        // You should not write codes for Edit like below.
        // Event if you uncomment, these won't work as we have designed our classes not to allow direct references.
        //public IActionResult Edit(int userId)
        //{
        //    UsersService service = new UsersService(new UsersRepository());
        //    return View(service.GetUser(userId));
        //}

        //public IActionResult Edit(int userId)
        //{
        //    UsersRepository repo = new UsersRepository();
        //    return View(repo.GetUser(userId));
        //}

        //public IActionResult Edit(int userId)
        //{
        //    return View(
        //                new DataContext()
        //                .Users
        //                .SingleOrDefault(u => u.UserId == userId)
        //            );
        //}
    }
}