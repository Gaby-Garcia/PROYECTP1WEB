using PROYECTP1W.Core.Entities;

namespace PROYECTP1W.Core.Managers.Interfaces;
public interface ISfManager{

    List<Sf> GetSf (Users users, List<Sf> list);
}