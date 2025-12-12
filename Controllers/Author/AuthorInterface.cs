using SMS_backend.Models;

namespace SMS_backend.Controllers
{
    public interface IAuthorController
    {
    }
    public interface IAuthorService
    {

    }
    public interface IAuthorQuery
    {
        Task<Author?> PatchAuthorByIDAsync(int ID);
        Task<AuthorOnlyResponse?> AuthorOnlyResponseByIDAsync(int ID);
        IQueryable<AuthorOnlyResponse> AuthorOnlyResponseAsync(string? searchTerm, AuthorStatus? authorStatus);
    }
}
