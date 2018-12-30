using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exams_management_system
{
  public class VersionedRouteAttribute : RouteAttribute
    {
        public VersionedRouteAttribute(string value) : base(ApplyVersioning(value))
        {
        }

        public static string ApplyVersioning(string value)
        {
            return value.Replace("api/", "api/v1/");
        }
    }
}
