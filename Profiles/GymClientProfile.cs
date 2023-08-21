using AutoMapper;
using GymApi.Data.Request.GymClient;
using GymApi.Data.Response.GymClient;
using GymApi.Domain.Models;

namespace GymApi.Profiles;

public class GymClientProfile: Profile
{
    public GymClientProfile()
    {
        CreateMap<CreateGymClientDto, GymClient>();
        CreateMap<GymClient, ReadGymClientDto>();
        CreateMap<UpdateGymClientDto, GymClient>();
    }
}
