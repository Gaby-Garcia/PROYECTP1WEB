using PROYECTP1W.Core.Services.Interfaces;
using PROYECTP1W.Core.Entities;
using PROYECTP1W.Core.Managers.Interfaces;

namespace PROYECTP1W.Core.Managers;

public class SSEFManager : ISSEFManager
{
    private readonly ISSEFService _service;
    
    public SSEFManager(ISSEFService service){
        _service = service;
    }
    
    public void GetSSEF(Users user, List<Sf> list){
        _service.Consult(user, list);
    }
}