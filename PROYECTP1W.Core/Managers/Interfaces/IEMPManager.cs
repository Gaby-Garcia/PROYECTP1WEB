using PROYECTP1W.Core.Entities;

namespace PROYECTP1W.Core.Managers.Interfaces;

public interface IEMPManager
{
    Users GetEMP(Users users, List<Sf> list);
}