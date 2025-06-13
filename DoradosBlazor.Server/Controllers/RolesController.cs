using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DoradosBlazor.Server.Models;
using DoradosBlazor.Shared;
using Microsoft.EntityFrameworkCore;

namespace DoradosBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DbcrudBlazorContext _dbContext;

        public RolesController(DbcrudBlazorContext dbCntext)
        {

            _dbContext = dbCntext;  
        }



        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<RolesDTO>>();
            var listaRolesDTO = new List<RolesDTO>();

            try
            {
                foreach (var item in await _dbContext.Roles.ToListAsync())
                {
                    listaRolesDTO.Add(new RolesDTO
                    {
                        IdRol = item.IdRol,
                        NombreRol = item.NombreRol
                    });

                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaRolesDTO;

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }
            return Ok(responseApi);
        }


    }
}
