using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Model.DTO;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterApi : ControllerBase
    {
        private readonly IRegisterRepo _register;
        private readonly IMapper _mapper;

        public RegisterApi(IRegisterRepo register, IMapper mapper)
        {
            _register = register;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]  RegisterDTO  registerdto)
        {
            if (ModelState.IsValid)
            {
                var reg = _register.IsUniqueUser(registerdto.UserName ,registerdto.Email);
                if (!reg) return BadRequest("Username already exist please try new username");
                var logs = _mapper.Map<RegisterDTO, Register>(registerdto);
                var gg=  _register.Registers(logs.UserName, logs.Password,logs.Email);
                if (gg == null) return BadRequest();
                else
                    return Ok(gg);
            }
            return Ok();
        
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO loginVM)
        {
          
           
            var user = _mapper.Map<LoginDTO, LoginVM>(loginVM);
           
            var log = _register.Login(user.Email, user.Password);
            if (log == null) return BadRequest("wrong username & passward please enter valid usename & passward");
            return Ok(log);
        }


       
        }




    }

