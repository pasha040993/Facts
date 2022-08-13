using Facts.Web.Data;
using Facts.Web.Infrastructure.Mappers.Base;
using Facts.Web.ViewModels;
using System.Collections.Generic;
using Calabonga.AspNetCore.Controllers;
using Calabonga.UnitOfWork;

namespace Facts.Web.Infrastructure.Mappers
{
    public class TagMapperConfiguration : MapperConfigurationBase
    {
        public TagMapperConfiguration()
        {
            CreateMap<Tag, TagViewModel>();
            CreateMap<Tag, TagUpdateViewModel>();
            CreateMap<TagUpdateViewModel, Tag>()
                .ForMember(x => x.Facts, o => o.Ignore());
        }
    }
}
