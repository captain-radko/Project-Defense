using AutoMapper;

namespace IdeGames.Services.Mapping
{
    public interface ICustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}