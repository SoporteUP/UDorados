using DoradosBlazor.Shared;
using System.Net.Http.Json;

namespace DoradosBlazor.Client.Services
{
    public class RolesService : IRolesService
    {

        private readonly HttpClient _http;

        public RolesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<RolesDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<RolesDTO>>>("api/Roles/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);

        }
    }
}
