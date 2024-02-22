using MyCompany.intranet.Core.Entities;
using MyCompany.intranet.Core.Managers.Interfaces;
using MyCompany.intranet.Core.Services.Interfaces;

namespace MyCompany.intranet.Core.Managers;

public class BmiManager : IBmiManager {

    private readonly IBmiService _service;

    public BmiManager(IBmiService service){
        _service = service;
    }

    public Bmi GetBmi(Person person){
        return _service.ProcessBmi(person);
    }
}