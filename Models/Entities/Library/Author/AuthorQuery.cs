using Microsoft.EntityFrameworkCore;
using SMS_backend.Controllers;

namespace SMS_backend.Models
{
    public class AuthorQuery : IAuthorQuery
    {
        private readonly Db _context;
        public AuthorQuery(Db context)
        {
            _context = context;
        }
        public async Task<Author?> PatchAuthorByIDAsync(int ID)
        {
            return await _context.Authors
                .SingleOrDefaultAsync(A => A.ID == ID);
        }
        public async Task<AuthorOnlyResponse?> AuthorOnlyResponseByIDAsync(int ID)
        {
            return await _context.Authors
                .AsNoTracking()
                .Where(A => A.ID == ID)
                .Select(A => new AuthorOnlyResponse
                {
                    ID = A.ID,
                    AuthorFullName = $"{A.FirstName} {A.LastName}",
                    AuthorityName = A.AuthorityName,
                    DateOfBirth = A.DateOfBirth,
                    DateOfDeath = A.DateOfDeath,
                    Nationality = A.Nationality,
                    Biography = A.Biography,
                    VIAF_ID = A.VIAF_ID,
                    WebSiteURL = A.WebSiteURL,
                    AuthorStatus = A.AuthorStatus
                }).SingleOrDefaultAsync();
        }
        public IQueryable<AuthorOnlyResponse> AuthorOnlyResponseAsync(string? searchTerm, AuthorStatus? authorStatus)
        {
            var query = _context.Authors
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(A => A.FirstName.Contains(searchTerm) ||
                A.LastName.Contains(searchTerm) ||
                A.AuthorityName.Contains(searchTerm) ||
                A.Nationality.Contains(searchTerm));
            }
            if (authorStatus.HasValue)
            {
                query = query.Where(A => A.AuthorStatus == authorStatus.Value);
            }

            return query
                .OrderByDescending(A => A.ID)
                .Select(A => new AuthorOnlyResponse
                {
                    ID = A.ID,
                    AuthorFullName = $"{A.FirstName} {A.LastName}",
                    AuthorityName = A.AuthorityName,
                    DateOfBirth = A.DateOfBirth,
                    DateOfDeath = A.DateOfDeath,
                    Nationality = A.Nationality,
                    Biography = A.Biography,
                    VIAF_ID = A.VIAF_ID,
                    WebSiteURL = A.WebSiteURL,
                    AuthorStatus = A.AuthorStatus
                });
        }
    }
}
