using PROYECTP1W.Core.Entities;
using PROYECTP1W.Core.Managers.Interfaces;
using PROYECTP1W.Core.Services.Interfaces;

namespace PROYECTP1W.Core.Managers;

public class EMPManager : IEMPManager
{
    private readonly IEMPService _service;

    public EMPManager(IEMPService service){
        _service = service;
    }

    public Users GetEMP(Users users, List<Sf> list){
        return _service.GoalsAndLimits(users, list);
    }
}