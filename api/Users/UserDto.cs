﻿using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace MuaythaiSportManagementSystemApi.Users
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public int Type { get; set; }
        public int? CountryId { get; set; }
        public int? InstitutionId { get; set; }
        public int? KhanLevelId { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string VK { get; set; }
        public string CoachLevel { get; set; }
        public bool Accepted { get; set; }
        public string CountryName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string AvatarImage { get; set; }

        public UserDto()
        {

        }

        public UserDto(ApplicationUser user)
        {
            if (user == null)
            {
                return;
            }
            Id = user.Id;
            Firstname = user.FirstName;
            Surname = user.Surname;
            Birthdate = user.Birthdate;
            Nationality = user.Nationality;
            Facebook = user.Facebook;
            Twitter = user.Twitter;
            Instagram = user.Instagram;
            InstitutionId = user.InstitutionId;
            VK = user.VK;
            Gender = user.Gender;
            Phone = user.Phone;
            CountryId = user.CountryId;
            CountryName = user.Country?.Name;
            Email = user.Email;
            //TODO: Add roles from userRoles
            Roles = user.Roles?.Select(r => r.RoleId).ToList();
            Photo = user.Photo;
        }

        public static explicit operator UserDto(ApplicationUser user)
        {
            if (user == null)
            {
                return null;
            }
            return new UserDto(user);
        }
    }

    public class FighterDto : UserDto
    {
        public string GymName { get; set; }

        public FighterDto()
        {

        }

        public FighterDto(ApplicationUser user):base(user)
        {
            GymName = user?.Institution?.Name;
        }

        public static explicit operator FighterDto(ApplicationUser user)
        {
            return new FighterDto(user);
        }
    }

    public class JudgeDto : FighterDto
    {
        public JudgeDto()
        {

        }

        public JudgeDto(ApplicationUser user) : base(user)
        {
           
        }


        public static explicit operator JudgeDto(ApplicationUser user)
        {
            return new JudgeDto(user);
        }
    }


}
