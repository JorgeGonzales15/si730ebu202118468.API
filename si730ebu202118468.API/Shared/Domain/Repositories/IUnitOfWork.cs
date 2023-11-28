namespace si730ebu202118468.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}