using DoradosBlazor.Shared;

namespace DoradosBlazor.Client.Services
{
    public interface IRolesService
    {
        Task<List<RolesDTO>> Lista();
    }
}
