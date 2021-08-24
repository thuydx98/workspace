using AutoMapper;
using JWS.Data.Entities;
using JWS.Service.FundCriteria.ViewModels;
using JWS.Service.FundHistories.ViewModels;
using JWS.Service.FundInvestments.ViewModels;

namespace JWS.Infrastructure.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<FundHistoryEntity, FundHistoryViewModel>();
			CreateMap<FundInvestmentEntity, FundInvestmentViewModel>();
			CreateMap<FundCriteriaEntity, FundCriteriaViewModel>();
		}
	}
}
