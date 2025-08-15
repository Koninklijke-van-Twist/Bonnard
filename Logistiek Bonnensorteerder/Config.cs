using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Logistiek_Bonnensorteerder
{
    public class Config
    {
        public string LocalizedDestinationPathRoot
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

        public List<RestrictableListEntry> departments;
        public List<RestrictableListEntry> documentTypes;
        public string destinationPathRoot;
        public bool keepOriginalFile;

        public class RestrictableListEntry
        {
            public string name;
            public Dictionary<string, bool> allowedEntries = new Dictionary<string, bool>();
            public Dictionary<string, bool> requiredEntries = new Dictionary<string, bool>();

            public RestrictableListEntry Clone()
            {
                return new RestrictableListEntry
                {
                    name = this.name,
                    allowedEntries = new Dictionary<string, bool>(this.allowedEntries),
                    requiredEntries = new Dictionary<string, bool>(this.requiredEntries)
                };
            }

            public void FixDictionaries()
            {
                string[] entries = new string[]
                {
                    "department",
                    "orderNumber",
                    "pickbon",
                    "customerName",
                    "transporterName"
                };

                foreach (string entryName in entries)
                {
                    if (!requiredEntries.ContainsKey(entryName))
                        requiredEntries.Add(entryName, false);

                    if (!allowedEntries.ContainsKey(entryName))
                        allowedEntries.Add(entryName, true);
                }
            }
        }
    }
}
