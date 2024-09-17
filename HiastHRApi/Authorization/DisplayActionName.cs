using Microsoft.AspNetCore.Mvc.Filters;

namespace hiastHRApi.Authorization
{
    public class DisplayActionName : ActionFilterAttribute
    {
        public string DisplayName { get; set; }
    }
}
