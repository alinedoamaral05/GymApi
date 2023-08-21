using AutoMapper;
using GymApi.Data.Request.GymClient;
using GymApi.Data.Response.GymClient;
using GymApi.Domain.Models;
using GymApi.Domain.Repositories;
using GymApi.Domain.Repositories.Interfaces;
using GymApi.Exceptions;

namespace GymApi.Services
{
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
            var readClient = _mapper.Map<ICollection<ReadGymClientDto>>(gymClients);
            return readClient;

        }

        public ReadGymClientDto FindById(int id)
        {
            var gymClient = _gymClientRepository.FindById(id)
                ?? throw new NotFoundException();
            var readClient = _mapper.Map<ReadGymClientDto>(gymClient);
            return readClient;

        }

        public ReadGymClientDto UpdateById(UpdateGymClientDto dto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
