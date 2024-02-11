﻿using ConsoleApp.Entities;
using ConsoleApp_CODE_FIRST.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_CODE_FIRST.Services
{
    internal class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public RoleEntity CreateRole(string roleName)
        {
            var roleEntity = _roleRepository.Get(x => x.RoleName == roleName );
            roleEntity ??= _roleRepository.Create(new RoleEntity { RoleName = roleName });

            return roleEntity;
        }

        public RoleEntity GetRoleByRoleName(string roleName)
        {
            var roleEntity = _roleRepository.Get(x => x.RoleName == roleName);
            return roleEntity;
        }

        public RoleEntity GetRoleById(int id)
        {
            var roleEntity = _roleRepository.Get(x => x.Id == id);
            return roleEntity;
        }

        public IEnumerable<RoleEntity> GetRoles()
        {
            var roles = _roleRepository.GetAll();
            return roles;
        }

        public RoleEntity UpdateRole(RoleEntity roleEntity)
        {
            var updatedRoleEntity = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
            return updatedRoleEntity;
        }

        public bool DeleteRole(int id)
        {
            _roleRepository.Delete(x => x.Id == id);
            return true;
        }

    }
}
