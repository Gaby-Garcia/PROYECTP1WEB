using PROYECTP1W.Core.Entities;
using PROYECTP1W.Core.Managers.Interfaces;
using PROYECTP1W.Core.Services.Interfaces;

namespace PROYECTP1W.Core.Managers;

public class SfManager : ISfManager {

    private readonly ISfService _service;

    public SfManager(ISfService service){
        _service = service;
    }

    public Sf GetSf(Users users){
        return _service.IncomeSf(users);
    }
}