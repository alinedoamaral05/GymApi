using AutoMapper;
using GymApi.Data.Request.ExerciseDetail;
using GymApi.Data.Response.ExerciseDetail;
using GymApi.Domain.Repositories.Interfaces;

namespace GymApi.Services
{
    public class ExerciseDetailService : IExerciseDetailService
    {
        private readonly IMapper _mapper;
        private IExerciseDetailRepository _exerciseDetailRepository;
        public ExerciseDetailService(IMapper mapper, IExerciseDetailRepository exerciseDetailRepository)
        {
            _mapper = mapper;
            _exerciseDetailRepository = exerciseDetailRepository;
        }
        public ReadExerciseDetailDto Create(CreateExerciseDetailDto dto)
        {
            throw new NotImplementedException();
        }

        public ReadExerciseDetailDto DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ReadExerciseDetailDto> FindAll()
        {
            var exercises = _exerciseDetailRepository.FindAll();
            var map = _mapper.Map<IList<ReadExerciseDetailDto>>(exercises);
            return map;
        }

        public ReadExerciseDetailDto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public ReadExerciseDetailDto UpdateById(UpdateExerciseDetailDto dto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
