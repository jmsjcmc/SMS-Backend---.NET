using SMS_backend.Models;

namespace SMS_backend.Controllers
{
    public class AuthorService : IAuthorService
    {
        private readonly AuthorQuery _authorQuery;
        public AuthorService(AuthorQuery authQuery)
        {
            _authorQuery = authQuery;
        }

    }
}
