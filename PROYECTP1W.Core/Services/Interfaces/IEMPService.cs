using PROYECTP1W.Core.Entities;

namespace PROYECTP1W.Core.Services.Interfaces;

public interface IEMPService
{
    Users GoalsAndLimits (Users users, List<Sf> transacciones);
}