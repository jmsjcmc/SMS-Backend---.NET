using SMS_backend.Models;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public interface IAuthorController
    {
    }
    public interface IAuthorService
    {
        Task<AuthorOnlyResponse?> CreateAuthorAsync(CreateAuthorRequest request, ClaimsPrincipal creator);
        Task<AuthorOnlyResponse?> PatchAuthorByIDAsync(int ID, UpdateAuthorRequest request, ClaimsPrincipal updater);
    }
    public interface IAuthorQuery
    {
        Task<Author?> PatchAuthorByIDAsync(int ID);
        Task<AuthorOnlyResponse?> AuthorOnlyResponseByIDAsync(int ID);
        IQueryable<AuthorOnlyResponse> AuthorOnlyResponseAsync(string? searchTerm, AuthorStatus? authorStatus);
    }
}
