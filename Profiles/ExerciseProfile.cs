using AutoMapper;
using GymApi.Data.Request.Exercise;
using GymApi.Data.Response.Exercise;
using GymApi.Domain.Models;

namespace GymApi.Profiles;

public class ExerciseProfile: Profile
{
    public ExerciseProfile()
    {
        CreateMap<CreateExerciseDto, Exercise>();
        CreateMap<Exercise, ReadExerciseDto>();
        CreateMap<UpdateExerciseDto, Exercise>();
        CreateMap<UpdateExerciseDto, CreateExerciseDto>();
    }
}
