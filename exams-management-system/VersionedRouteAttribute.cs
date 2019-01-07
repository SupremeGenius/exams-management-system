using Microsoft.AspNetCore.Mvc;

namespace exams_management_system
{
    public class VersionedRouteAttribute : RouteAttribute
    {
        public VersionedRouteAttribute(string value, int version) : base(ApplyVersioning(value, version))
        {
        }

        public static string ApplyVersioning(string value, int version)
        {
            var apiVersion = "api/v" + version + "/";
            return value.Replace("api/", apiVersion);
        }
    }
}
