using Template.Repositories;

namespace Template.Services;

public class MyService : ImyService
{
    private ImyRepository _repository;

    public MyService(ImyRepository repository)
    {
        _repository = repository;
    }

    public async Task<Object> GetAsync()
    {
        return await _repository.GetAsync();
    }
}