using AutoMapper;
using GymApi.Data.Request.GymClient;
using GymApi.Data.Response.GymClient;
using GymApi.Domain.Models;
using GymApi.Domain.Repositories;
using GymApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Services;

public class GymClientService : IGymClientService
{
    private readonly IGymClientRepository _gymClientRepository;
    private readonly IMapper _mapper;

    public GymClientService(IGymClientRepository gymClientRepository, IMapper mapper)
    {
        _gymClientRepository = gymClientRepository;
        _mapper = mapper;
    }

    public ReadGymClientDto Create(CreateGymClientDto dto)
    {
        var gymClient = _mapper.Map<GymClient>(dto);
        gymClient = _gymClientRepository.Create(gymClient);
        var readClient = _mapper.Map<ReadGymClientDto>(gymClient);

        return readClient;
    }

    public void DeleteById(int id)
    {
        var gymClient = _gymClientRepository.FindById(id)
            ?? throw new NotFoundException();

        _gymClientRepository.Delete(gymClient);
    }

    public ICollection<ReadGymClientDto> FindAll()
    {
        var gymClients = _gymClientRepository.FindAll();
        var readClients = _mapper.Map<ICollection<ReadGymClientDto>>(gymClients);

        return readClients;
    }

    public ReadGymClientDto FindById(int id)
    {
        var gymClient = _gymClientRepository.FindById(id)
            ?? throw new NotFoundException();
        var readClient = _mapper.Map<ReadGymClientDto>(gymClient);

        return readClient;
    }

    public ReadGymClientDto UpdateById(UpdateGymClientDto updateGymClientDto, int id)
    {
        var gymClient = _gymClientRepository.FindById(id);
        if (gymClient == null)
        {
            var createDto = _mapper.Map<CreateGymClientDto>(updateGymClientDto);
            return Create(createDto);
        }
        
        _mapper.Map(updateGymClientDto, gymClient);
        var updated = _gymClientRepository.Update(gymClient);

        var readGymClient = _mapper.Map<ReadGymClientDto>(updated);

        return readGymClient;

    }
}
