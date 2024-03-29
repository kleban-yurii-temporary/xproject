﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProject.Core;
using XProject.Repositories.Models;
using XProject.WebApp.Data;

namespace XProject.Repositories
{
    public class UserRoleRepository
    {
        private readonly AppDbContext _ctx;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleRepository(AppDbContext ctx,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<AppUser> CreateAsync(AppUserCreateModel model)
        {
            var newUser = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = false,
                NormalizedUserName = model.Email.ToUpper(),
                Email = model.Email
            };            

            await _userManager.CreateAsync(newUser, model.Password);

            return await _ctx.Users.FirstAsync(x => x.Email == model.Email);
        }

        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            return await _ctx.Roles.ToListAsync();
        }

        public async Task<int> IsConfirmed(string id)
        {
            return (await _ctx.Users.FirstAsync(x=> x.Id == id)).EmailConfirmed ? 1 : 0;
        }

        public async Task UpdateAsync(AppUserViewModel model, string[] roles)
        {
            var user = _ctx.Users.Find(model.Id);

            if (user.Email != model.Email)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                user.NormalizedEmail = model.Email.ToUpper();
            }

            if(user.FirstName != model.FirstName)            
                user.FirstName = model.FirstName;

            if (user.LastName != model.LastName)
                user.LastName = model.LastName;

            if (user.EmailConfirmed != model.IsEmailConfirmed)
                user.EmailConfirmed = model.IsEmailConfirmed;

            var admRole = await _roleManager.FindByNameAsync("Admin");

            if((await _userManager.GetRolesAsync(user)).Any())
            {
               await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            }

            if (roles.Any())
            {
                await _userManager.AddToRolesAsync(user, roles.ToList());
            }
        }

        public async Task DeleteAsync(string id)
        {
            var user = _ctx.Users.Find(id);

            if ((await _userManager.GetRolesAsync(user)).Any())
            {
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            }
            await _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<AppUserViewModel>> GetAllWithRolesAsync()
        {
            var list = new List<AppUserViewModel>();

            foreach (var user in await _ctx.Users.ToListAsync())            
                list.Add(await GetOneWithRolesAsync(user.Id));            

            return list;
        }

        public async Task<AppUserViewModel> GetOneWithRolesAsync(string id)
        {
            var user = await _ctx.Users.FirstAsync(x => x.Id == id);
            var userModel = new AppUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsEmailConfirmed = user.EmailConfirmed,
                Roles = new List<IdentityRole>()
            };

            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                userModel.Roles.Add(await _ctx.Roles.FirstAsync(x => x.Name.ToLower() == role.ToLower()));
            }

            return userModel;
        }

    }
}
