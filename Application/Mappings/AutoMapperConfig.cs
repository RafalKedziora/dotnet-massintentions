namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                #region Intention

                cfg.CreateMap<Intention, IntentionDto>()
                .ForMember(dest => dest.LastModified, act => act.MapFrom(src => src.Detail.LastModified));
                cfg.CreateMap<CreateIntentionDto, Intention>();
                cfg.CreateMap<UpdateIntentionDto, Intention>();
                cfg.CreateMap<IEnumerable<Intention>, ListIntentionsDto>()
                .ForMember(dest => dest.Intentions, act => act.MapFrom(src => src))
                .ForMember(dest => dest.Count, act => act.MapFrom(src => src.Count()));

                #endregion

                #region Category

                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<CreateCategoryDto, Category>();
                cfg.CreateMap<UpdateCategoryDto, Category>();

                #endregion

                #region User

                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.PasswordHash, act => act.MapFrom(src => src.Password));
                cfg.CreateMap<LoginUserDto, User>();

                #endregion
            }).CreateMapper();
    }
}
