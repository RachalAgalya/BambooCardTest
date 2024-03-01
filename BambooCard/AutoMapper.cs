using AutoMapper;
using BambooCard.Models;

namespace BambooCard
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<StoryModel, StoryDetailModel>()
                .ForMember(dest =>
                    dest.PostedBy,
                    opt => opt.MapFrom(src => src.By))
                .ForMember(dest =>
                    dest.Uri,
                    opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time == 0 ? "" :
                     DateTimeOffset.FromUnixTimeSeconds(src.Time).UtcDateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.ffffK")))
                .ForMember(dest =>
                    dest.CommentCount,
                    opt => opt.MapFrom(src => src.Descendants));
        }
    }
}
