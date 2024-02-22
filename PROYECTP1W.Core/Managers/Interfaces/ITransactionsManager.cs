using MyCompany.intranet.Core.Entities;

namespace MyCompany.intranet.Core.Managers.Interfaces;
public interface IBmiManager{

    Bmi GetBmi (Person person);
}