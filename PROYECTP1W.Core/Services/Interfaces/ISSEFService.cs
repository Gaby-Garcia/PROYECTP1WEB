using PROYECTP1W.Core.Entities;

namespace PROYECTP1W.Core.Services.Interfaces;

public interface ISSEFService
{
    void Consult(Users users, List<Sf> transacciones);
}