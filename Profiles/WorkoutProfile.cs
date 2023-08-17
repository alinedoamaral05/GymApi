using AutoMapper;
using GymApi.Data.Request.Workout;
using GymApi.Data.Response.Workout;
using GymApi.Models;

namespace GymApi.Profiles;

public class WorkoutProfile: Profile
{
    public WorkoutProfile()
    {
        CreateMap<CreateWorkoutDto, Workout>();
        CreateMap<UpdateWorkoutDto, Workout>();
        CreateMap<Workout, ReadWorkoutDto>();
    }
}
