﻿using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace Google.YouTube.Net.Emailing
{
    public class YouTubeSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public YouTubeSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}