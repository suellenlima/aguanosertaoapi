using Microsoft.AspNetCore.Http;

namespace AguaNoSertao.Domain.Helpers
{
    public static class ExtensionMethods
    {
        public static T GetClaim<T>(this IHttpContextAccessor obj, string key)
        {
            try
            {
                return (T)Convert.ChangeType(obj.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type.Contains(key))?.Value, typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
