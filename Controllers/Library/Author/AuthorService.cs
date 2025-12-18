using SMS_backend.Models;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public class AuthorService 
    {
        private readonly AuthorQuery _authorQuery;
        public AuthorService(AuthorQuery authQuery)
        {
            _authorQuery = authQuery;
        }
    }
}
