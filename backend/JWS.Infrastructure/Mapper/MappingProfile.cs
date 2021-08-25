using AutoMapper;
using JWS.Data.Entities;
using JWS.Service.FundCriteria.ViewModels;
using JWS.Service.FundHistories.ViewModels;
using JWS.Service.FundInvestments.ViewModels;
using System.Linq;

namespace JWS.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FundHistoryEntity, FundHistoryViewModel>();

            CreateMap<FundInvestmentEntity, FundInvestmentViewModel>().ForMember(
                dest => dest.Criterias,
                opt => opt.MapFrom(src => src.InvestmentCriterias.Select(n => n.CriteriaId)));

            CreateMap<FundCriteriaEntity, FundCriteriaViewModel>();
        }
    }
}
