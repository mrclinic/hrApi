using hiastHRApi.Services.Common.Activation;
using hiastHRApi.Services.IService;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace hiastHRApi.Services.Service
{
    class HelperService : IHelperService
    {
        private readonly IOptions<ActivationSetting> _activationSetting;
        public HelperService(IOptions<ActivationSetting> activationSetting)
        {
            _activationSetting = activationSetting;
        }
        public string GenerateLicenseKey(string input)
        {
            string productIdentifier = (input + "-" + _activationSetting.Value.ProductName + "-" + _activationSetting.Value.ClientIdentificationId + "-" + _activationSetting.Value.VersionNumber).ToLower();
            return FormatLicenseKey(GetMd5Sum(productIdentifier));
        }

        string GetMd5Sum(string productIdentifier)
        {
            System.Text.Encoder enc = System.Text.Encoding.Unicode.GetEncoder();
            byte[] unicodeText = new byte[productIdentifier.Length * 2];
            enc.GetBytes(productIdentifier.ToCharArray(), 0, productIdentifier.Length, unicodeText, 0, true);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }
            return sb.ToString();
        }

        string FormatLicenseKey(string productIdentifier)
        {
            productIdentifier = productIdentifier.Substring(0, 28).ToUpper();
            char[] serialArray = productIdentifier.ToCharArray();
            StringBuilder licenseKey = new StringBuilder();

            int j = 0;
            for (int i = 0; i < 28; i++)
            {
                for (j = i; j < 4 + i; j++)
                {
                    licenseKey.Append(serialArray[j]);
                }
                if (j == 28)
                {
                    break;
                }
                else
                {
                    i = (j) - 1;
                    licenseKey.Append("-");
                }
            }
            return licenseKey.ToString();
        }
    }
}
