﻿using AutoMapper;
using GymApi.Data.Request.ExerciseDetail;
using GymApi.Data.Response.ExerciseDetail;
using GymApi.Domain.Models;

namespace GymApi.Profiles;

public class ExerciseDetailProfile: Profile
{
    public ExerciseDetailProfile()
    {
        CreateMap<CreateExerciseDetailDto, ExerciseDetail>();
        CreateMap<ExerciseDetail, ReadExerciseDetailDto>();
        CreateMap<UpdateExerciseDetailDto, ExerciseDetail>();
        CreateMap<UpdateExerciseDetailDto, CreateExerciseDetailDto>();
    }
}
