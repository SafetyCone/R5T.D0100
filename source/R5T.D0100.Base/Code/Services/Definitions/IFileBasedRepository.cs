using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0100
{
    [ServiceDefinitionMarker]
    public interface IFileBasedRepository : IServiceDefinition
    {
        Task Load();
        Task Save();
    }
}