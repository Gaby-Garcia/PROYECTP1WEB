using MyCompany.intranet.Core.Entities;

namespace MyCompany.intranet.Core.Services.Interfaces;

public interface IBmiService{
    Bmi ProcessBmi (Person person);
}