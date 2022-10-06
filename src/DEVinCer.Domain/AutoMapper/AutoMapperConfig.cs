using AutoMapper;
namespace DEVinCer.Domain.AutoMapper;

public class AutoMapperConfig
{
    public static IMapper Configure()
    {
        var ConfigMap = new MapperConfiguration( config => {
            config.AddProfile(new EntityAutoMapper());
        });

        return ConfigMap.CreateMapper();
    }
}
