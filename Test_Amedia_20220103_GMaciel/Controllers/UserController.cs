using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Amedia_20220103_GMaciel.Models;

namespace Test_Amedia_20220103_GMaciel.Controllers
{
    
    public class UserController : Controller
    {
        private readonly TestCrudContext _context;
        // GET: UserController

        public UserController(TestCrudContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _context.TUsers.ToListAsync();
            return View(users);
        }


        //AddOrEdit Get Method
        public async Task<IActionResult> AddOrEdit(int? codUsuario)
        {
            ViewBag.PageName = codUsuario == null ? "Create User" : "Edit User";
            ViewBag.IsEdit = codUsuario == null ? false : true;
            if (codUsuario == null)
            {
                return View();
            }
            else
            {
                var user = await _context.TUsers.FindAsync(codUsuario);

                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
        }

        //AddOrEdit Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int codUsuario, [Bind("CodUsuario,TxtUser,TxtPassword,TxtNombre,TxtApellido,NroDoc,CodRol,SnActivo")]
TUser userData)
        {
            bool IsUserExist = false;

            TUser user = await _context.TUsers.FindAsync(codUsuario);

            if (user != null)
            {
                IsUserExist = true;
            }
            else
            {
                user = new TUser();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    user.TxtUser = userData.TxtUser;
                    user.TxtPassword = userData.TxtPassword;
                    user.TxtNombre = userData.TxtNombre;
                    user.TxtApellido = userData.TxtApellido;
                    user.NroDoc = userData.NroDoc;
                    user.CodRol = userData.CodRol;
                    user.SnActivo = userData.SnActivo;

                    if (IsUserExist)
                    {
                        _context.Update(user);
                    }
                    else
                    {
                        _context.Add(user);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userData);
        }

        // User Details
        public async Task<IActionResult> Details(int? CodUsuario)
        {
            if (CodUsuario == null)
            {
                return NotFound();
            }
            var user = await _context.TUsers.FirstOrDefaultAsync(m => m.CodUsuario == CodUsuario);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }




        // GET: User/Delete/1
        public async Task<IActionResult> Delete(int? codUsuario)
        {
            if (codUsuario == null)
            {
                return NotFound();
            }
            var employee = await _context.TUsers.FirstOrDefaultAsync(m => m.CodUsuario == codUsuario);

            return View(employee);
        }

        // POST: User/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int codUsuario)
        {
            var user = await _context.TUsers.FindAsync(codUsuario);
            _context.TUsers.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
