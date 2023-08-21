using GymApi.Domain.Models;

namespace GymApi.Domain.Repositories.Interfaces;

public interface IGymClientRepository
{
    GymClient Create(GymClient gymClient);
    GymClient Update(GymClient gymClient);
    GymClient DeleteById(int id);
    GymClient FindById(int id);
    ICollection<GymClient> FindAll();
}
