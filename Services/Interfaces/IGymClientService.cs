using GymApi.Data.Request.GymClient;
using GymApi.Data.Response.GymClient;

namespace GymApi.Services;

public interface IGymClientService
{
    ReadGymClientDto Create(CreateGymClientDto dto);
    ReadGymClientDto UpdateById(UpdateGymClientDto dto, int id);
    void DeleteById(int id);
    ReadGymClientDto FindById(int id);
    ICollection<ReadGymClientDto> FindAll();
}
