using IntegrandoApisConAdoNet.Controllers.DTOS;
using IntegrandoApisConAdoNet.Model;
using IntegrandoApisConAdoNet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IntegrandoApisConAdoNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        //CONSULTAR USUARIO
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsuarios();
        }


        //BORRAR USUARIO
        [HttpDelete(Name = "BorrarUsuario")]
        //                          este metodo lo que hace es para que se reciba del body del POSTMAN
        public bool EliminarUsuario([FromBody] int id)
        {
            try
            {
                return UsuarioHandler.EliminarUsuario(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        //MODIFICAR UN USUARIO
        [HttpPut]
        public bool ModificarUsuario([FromBody] PutUsuario usuario)
        {
            return UsuarioHandler.ModificarUsuario(new Usuario
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                NombreUsuario = usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Mail = usuario.Mail
            });
        }


        //CREAR UN USUARIO
        [HttpPost]
        public string CrearUsuario([FromBody] PostUsuario usuario)
        {
            try
            {

                return UsuarioHandler.CrearUsuario(new Usuario
                {

                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    NombreUsuario = usuario.NombreUsuario,
                    Contraseña = usuario.Contraseña,
                    Mail = usuario.Mail

                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error";
            }
        }
    }
}
