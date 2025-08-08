using System;
using System.Text.RegularExpressions;

namespace Logistiek_Bonnensorteerder
{
    public class Config
    {
        public string DestinationPathRoot
        {
            get
            {
                string result = destinationPathRoot;
                if(destinationPathRoot.ToLower().StartsWith("onedrive://"))
                {
                    result = Regex.Replace(result, "onedrive://", Environment.GetEnvironmentVariable("OneDrive"), RegexOptions.IgnoreCase);
                }
                else if (destinationPathRoot.ToLower().StartsWith("onedrive:\\\\"))
                {
                    result = Regex.Replace(result, "onedrive:\\\\", Environment.GetEnvironmentVariable("OneDrive"), RegexOptions.IgnoreCase);
                }

                return result;
            }
        }

        public string[] departments;
        public string[] documentTypes;
        public string destinationPathRoot;
        public bool keepOriginalFile;
    }
}
