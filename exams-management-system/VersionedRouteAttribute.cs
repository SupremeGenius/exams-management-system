using Microsoft.AspNetCore.Mvc;

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
