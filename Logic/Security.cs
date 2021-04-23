using Jolia.Core.Libraries;
using Jolia.Core.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using static Jolia.Core.Enums;

namespace Jolia.Core.Logic
{
    public class AreaSecurity<AppAreasT, BasicRolesT, CustomRolesT>
    {
        public AreaSecurity(AppAreasT Area, List<BasicRolesT> BasicRoles, List<CustomRolesT> CustomRoles)
        {
            this.Area = Area;
            this.BasicRoles = BasicRoles;
            this.CustomRoles = CustomRoles;
        }
        public AppAreasT Area { get; set; }
        public List<BasicRolesT> BasicRoles { get; set; }
        public List<CustomRolesT> CustomRoles { get; set; }
    }

    public class FixedRoleSecurity<AppAreasT, BasicRolesT, CustomRolesT, FixedRolesT>
    {
        public FixedRoleSecurity(FixedRolesT FixedRole, List<AreaBasicRolePair<AppAreasT, BasicRolesT>> AreaBasicRolePairs, List<AreaCustomRolePair<AppAreasT, CustomRolesT>> AreaCustomRolePairs)
        {
            this.FixedRole = FixedRole;
            this.AreaBasicRolePairs = AreaBasicRolePairs;
            this.AreaCustomRolePairs = AreaCustomRolePairs;
        }
        public FixedRolesT FixedRole { get; set; }
        public List<AreaBasicRolePair<AppAreasT, BasicRolesT>> AreaBasicRolePairs { get; set; }
        public List<AreaCustomRolePair<AppAreasT, CustomRolesT>> AreaCustomRolePairs { get; set; }
    }

    public class AreaBasicRolePair<AppAreasT, BasicRolesT>
    {
        public AreaBasicRolePair(AppAreasT Area, BasicRolesT BasicRole)
        {
            this.Area = Area;
            this.BasicRole = BasicRole;
        }

        public AppAreasT Area { get; set; }
        public BasicRolesT BasicRole { get; set; }
    }

    public class AreaCustomRolePair<AppAreasT, CustomRolesT>
    {
        public AreaCustomRolePair(AppAreasT Area, CustomRolesT CustomRole)
        {
            this.Area = Area;
            this.CustomRole = CustomRole;
        }

        public AppAreasT Area { get; set; }
        public CustomRolesT CustomRole { get; set; }
    }

    public class Security<AppAreasT, BasicRolesT, CustomRolesT, FixedRolesT> 
        where AppAreasT : Enum where BasicRolesT : Enum where CustomRolesT : Enum where FixedRolesT : Enum, new()
    {
        public Security()
        {
            AreaSecurities = new List<AreaSecurity<AppAreasT, BasicRolesT, CustomRolesT>>();
            FixedRolesSecurities = new List<FixedRoleSecurity<AppAreasT, BasicRolesT, CustomRolesT, FixedRolesT>>();
        }

        protected List<FixedRoleSecurity<AppAreasT, BasicRolesT, CustomRolesT, FixedRolesT>> FixedRolesSecurities;
        protected List<AreaSecurity<AppAreasT, BasicRolesT, CustomRolesT>> AreaSecurities;

        public List<string> GetAllRoleNames()
        {
            var result = Enum.GetNames(typeof(FixedRolesT)).ToList();

            foreach (var area in AreaSecurities)
            {

                var RoleNames = area.BasicRoles.Select(r => GetRoleName(area.Area, r)).ToList()
                    .Union(area.CustomRoles.Select(r => GetRoleName(area.Area, r)))
                    .ToList();

                result = result.Union(RoleNames).ToList();
            }

            return result;
        }

        public string GetRoleName(AppAreasT area, BasicRolesT role)
        {
            return GetRoleName(area.ToString(), role.ToString());
        }

        public string GetRoleName(AppAreasT area, CustomRolesT role)
        {
            return GetRoleName(area.ToString(), role.ToString());
        }

        public string GetRoleName(string areaName, string role)
        {
            return $"{areaName}_{role}";
        }


        public static class Passwords
        {
            public static string GetRandomPassword()
            {
                var r = new Random();
                return r.Next(100000, 999999).ToString();
            }
        }
        
        public static class Google
        {
            public static PR VerifyGoogleRecaptcha(string RecaptchaResponseString, string Ip)
            {
                var sb = new StringBuilder("https://www.google.com/recaptcha/api/siteverify?");
                sb.Append($"secret={Application.Configurations.GoogleConfiguration.RecaptchaSecretKey}&response={RecaptchaResponseString}&remoteip={Ip}");

                using (var client = new WebClient())
                {
                    var uri = sb.ToString();
                    var json = client.DownloadString(uri);
                    var serializer = new DataContractJsonSerializer(typeof(RecaptchaResult));
                    var ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                    var result = serializer.ReadObject(ms) as RecaptchaResult;

                    if (result == null)
                    {
                        return new PR(PS.Warning, "يرجى المحاولة مرة أخرى");
                    }
                    else
                    {
                        if (result.ErrorCodes != null)
                            return new PR(PS.Warning, string.Join(", ", result.ErrorCodes));
                        else if (!result.Success)
                            return new PR(PS.Warning, "لم ينجح التحقق");
                    }
                }

                return new PR(PS.Success);
            }
        }
        
    }
}
