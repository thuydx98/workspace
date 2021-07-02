using AutoMapper;
using JWS.Data.Entities;
using JWS.Service.FundHistories.ViewModels;

namespace JWS.Infrastructure.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<FundHistoryEntity, FundHistoryViewModel>();//.ForMember(
				//dest => dest.Type,
				//opt => opt.MapFrom(src => src.Type.ToString()));
		}
	}
}
