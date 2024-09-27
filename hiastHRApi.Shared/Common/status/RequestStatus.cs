namespace hiastHRApi.Shared.Common.status
{
    public class RequestStatus
    {
        public enum ReqStatusCode
        {
            New = 0,
            Immanence = 1,//ذاتية
            HeadCommittee = 2,//رئيس لجنة
            HeadBranch = 3,//رئيس فرع
            Accepted = 4,//مقبولة
            Rejected = 5//مرفوضة
        }
    }
}
