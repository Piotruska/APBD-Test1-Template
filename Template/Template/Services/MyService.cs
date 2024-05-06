using PharmacyDB.Repositories;

namespace PharmacyDB.Services;

public class MyService : ImyService
{
    private ImyRepository _repository;
    
    public async Task<Object> GetAsync()
    {
        return _repository.GetAsync();
    }
}