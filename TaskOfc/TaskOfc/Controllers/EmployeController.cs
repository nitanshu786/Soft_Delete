using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TaskOfc.Data;
using TaskOfc.Model;

namespace TaskOfc.Controllers
{
    [Route("api/Employe")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly Applicationdbcontext _context;

        public EmployeController(Applicationdbcontext context)
        {
            _context = context;
        }
        [Route("getEmploye")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Employes.Where(m => !m.IsDeleted).ToList());
        }

        [Route("saveEmploye")]
        [HttpPost]
        public IActionResult Save([FromBody] Employe employe)
        {
            if (employe != null)
            {
                var file = HttpContext.Request.Form.Files;
                if (file.Count > 0)
                {
                    byte[] pp = null;

                    using (var ps1 = file[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            ps1.CopyTo(ms1);
                            pp = ms1.ToArray();
                            var base64 = Convert.ToBase64String(pp);
                        }

                    }

                }

                _context.Employes.Add(employe);
                _context.SaveChanges();
            }

            else
                return BadRequest(ModelState);

            return Ok();
        }

            [Route("updateEmploye")]
            [HttpPut]
            public IActionResult Update(int Id, [FromBody] Employe employe)
            {
                if (employe != null)
                {
                  var nbsd = _context.Employes.Find(employe.ID);
                   employe.Picture = nbsd.Picture;
                 _context.Update(employe);
                _context.SaveChanges();
                    
                }
                else
                    return BadRequest(ModelState);
                return Ok();
            }
            [Route("DeleteEmploye")]
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var model = _context.Employes.FirstOrDefault(m => m.ID == id);

                if (model == null)
                    return NotFound();

                _context.Remove(model);
                _context.SaveChanges();
                return Ok();
            }
        }
    }

