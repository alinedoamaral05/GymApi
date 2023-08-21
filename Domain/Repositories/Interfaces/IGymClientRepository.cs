using GymApi.Domain.Models;

namespace GymApi.Domain.Repositories.Interfaces;

public interface IGymClientRepository
{
    GymClient Create(GymClient gymClient);
    GymClient Update(GymClient gymClient);
    void Delete(GymClient gymClient);
    GymClient FindById(int id);
    ICollection<GymClient> FindAll();
}
