﻿using Facts.Web.Data;
using Facts.Web.Infrastructure.Mappers.Base;
using Facts.Web.ViewModels;
using System.Collections.Generic;
using Calabonga.AspNetCore.Controllers;
using Calabonga.UnitOfWork;

namespace Facts.Web.Infrastructure.Mappers
{
    public class FactMapperConfiguration : MapperConfigurationBase
    {
        public FactMapperConfiguration()
        {
            CreateMap<Fact, FactViewModel>();

            CreateMap<FactCreateViewModel, Fact>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.Tags, o => o.Ignore())
                .ForMember(x => x.CreatedAt, o => o.Ignore())
                .ForMember(x => x.CreatedBy, o => o.Ignore())
                .ForMember(x => x.UpdatedAt, o => o.Ignore())
                .ForMember(x => x.UpdatedBy, o => o.Ignore());

            CreateMap<Fact, FactUpdateViewModel>();

            CreateMap<FactUpdateViewModel, Fact>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.Tags, o => o.Ignore())
                .ForMember(x => x.CreatedAt, o => o.Ignore())
                .ForMember(x => x.CreatedBy, o => o.Ignore())
                .ForMember(x => x.UpdatedAt, o => o.Ignore())
                .ForMember(x => x.UpdatedBy, o => o.Ignore());

            CreateMap<IPagedList<Fact>, IPagedList<FactViewModel>>()
                .ConvertUsing<PagedListConverter<Fact, FactViewModel>>();
        }
    }
}
