namespace hiastHRApi.Areas.UserManagment.Models
{
    public class ChangePasswordViewModel
    {
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
