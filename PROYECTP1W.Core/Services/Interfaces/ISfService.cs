using PROYECTP1W.Core.Entities;

namespace PROYECTP1W.Core.Services.Interfaces;

public interface ISfService{
    List<Sf> IncomeSf (Users users, List<Sf> transacciones);
}