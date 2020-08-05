using Mapster;
using System;
using Trackings.Application.Queries;
using Trackings.Application.Queries.Mappers;

namespace Trackings.API.Infrastructure.Profile
{
    public class MapsterProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ReceiverMapper, ReceiverViewModel>()
                .Map(dest => dest.id, src => src.mall_id)
                .Map(dest => dest.realId, src => src.mall_real_id)
                .Map(dest => dest.realName, src => src.mall_real_name)
                .Map(dest => dest.realAddress, src => src.mall_real_address)
                .Map(dest => dest.contactName, src => src.mall_contact_name)
                .Map(dest => dest.contactEmail, src => src.mall_contact_email)
                .Map(dest => dest.contactPhone, src => src.mall_contact_phone)
                .Map(dest => Convert.ToBoolean(dest.autoGo), src => src.mall_auto_go)
                .Map(dest => Convert.ToBoolean(dest.active), src => src.mall_active);

            config.NewConfig<BrandMapper, BrandViewModel>()
                .Map(dest => dest.id, src => src.brand_id)
                .Map(dest => dest.name, src => src.brand_name)
                .Map(dest => dest.ruc, src => src.brand_ruc);

            config.NewConfig<StateMapper, StateViewModel>()
                .Map(dest => dest.id, src => src.state_id)
                .Map(dest => dest.name, src => src.state_name)
                .Map(dest => Convert.ToBoolean(dest.active), src => src.state_active);
        }
    }
}
