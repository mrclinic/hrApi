﻿namespace hiastHRApi.Shared.Common.Mail
{
    public class MailSettings
    {
        public string Mail { get; set; } = String.Empty;
        public string DisplayName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Host { get; set; } = String.Empty;
        public int Port { get; set; }
    }
}
