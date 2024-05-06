namespace Template.Repositories;

public interface ImyRepository
{
    public Task<Object> GetAsync();
    
    public Task<Object> SomeProcedure();
}