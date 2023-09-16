using Microsoft.AspNetCore.Mvc;
using app.helpers;
using app.Models.ModelView;
using app.middlewares;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using app.actions.usuario;
using Microsoft.IdentityModel.Tokens;


namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private UsuarioActions actions;
        private PasswordHasherService hash;
        private UsuarioValidation validation;


        public LoginController()
        {
            this.actions = new UsuarioActions();
            this.hash = new PasswordHasherService();
            this.validation = new UsuarioValidation();

        }
        private string SecretKey = Environment.GetEnvironmentVariable("JWT_KEY");
        private static readonly TimeSpan TokenLifeTime = TimeSpan.FromHours(8);

        [HttpPost("Post")]
        public async Task<IActionResult> Post(Login login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(
                        new ReturnClassDefault()
                        .returnDataDefault
                        (
                            Reply.FAIL,
                            ErrorValidationHelper.GetModelStateErrors(ModelState),
                            new ErrorHelperMessage().ErrorMessages(
                                ErrorHelperMessage.DEFAULT_VALUE,
                                ErrorHelperMessage.DEFAULT_VALUE,
                                ErrorHelperMessage.INVALIDO
                                )
                        )
                    );
                }
                else
                {

                    var usuario = await this.actions.buscarXNombre(login.nombre_usuario);

                    if (string.IsNullOrEmpty(usuario != null ? usuario.nombre_usuario : ""))
                        return BadRequest(
                        new ReturnClassDefault()
                        .returnDataDefault(
                            Reply.FAIL,
                            Reply.DATA_FAIL,
                            new ErrorHelperMessage().ErrorMessages(
                                    "nombre_usuario",
                                    ErrorHelperMessage.DEFAULT_VALUE,
                                    ErrorHelperMessage.NOT_FOUND
                                    )
                            )
                        );

                    if (!hash.VerifyPassword(usuario.password, login.password))
                        return BadRequest(
                            new ReturnClassDefault()
                            .returnDataDefault(
                                Reply.FAIL,
                                Reply.DATA_FAIL,
                                new ErrorHelperMessage().ErrorMessages(
                                        "password",
                                        ErrorHelperMessage.DEFAULT_VALUE,
                                        ErrorHelperMessage.NOT_FOUND
                                        )
                                )
                            );

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(SecretKey);

                    var claims = new List<Claim>
                    {
                        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new(JwtRegisteredClaimNames.Sub, usuario.nombre_usuario),
                        new(JwtRegisteredClaimNames.Email, usuario.correo),
                        new("rol_id", usuario.rol_id.ToString())
                    };

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.Add(TokenLifeTime),
                        Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
                        Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandle = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                    string TokenAcceso = tokenHandler.WriteToken(createdToken);

                    return Ok(
                    new ReturnClassDefault()
                        .returnDataDefault
                        (
                            Reply.SUCCESSFULL,
                            TokenAcceso,
                            new ErrorHelperMessage().ErrorMessages(
                                ErrorHelperMessage.DEFAULT_VALUE,
                                ErrorHelperMessage.DEFAULT_VALUE,
                                ErrorHelperMessage.OBTENIDO
                                )
                        )
                );
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,
                    new ReturnClassDefault()
                        .returnDataDefault(
                        Reply.FAIL,
                        Reply.DATA_FAIL,
                        $"Error: {e.Message}"
                        )
                );
            }
        }
    }
}