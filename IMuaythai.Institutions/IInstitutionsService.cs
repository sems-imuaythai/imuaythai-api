﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.Models.Institutions;
using IMuaythai.Models.Users;

namespace IMuaythai.Institutions
{
    public interface IInstitutionsService
    {
        Task<InstitutionModel> Get(int id);
        Task<IEnumerable<UserModel>> GetMembers(int institutionId);
        Task<IEnumerable<UserModel>> GetFighters(int institutionId);
        Task<IEnumerable<UserModel>> GetJudges(int institutionId);
        Task<IEnumerable<UserModel>> GetCoaches(int institutionId);
        Task<IEnumerable<UserModel>> GetDoctors(int institutionId);
        Task<InstitutionModel> Save(InstitutionModel institution);
        Task Remove(int institutionId);
    }
}