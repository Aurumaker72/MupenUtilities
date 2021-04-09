using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace MupenUtils.Networking
{
    public class UpdateNotifier
    {
        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                    using (client.OpenRead("http://google.com/generate_204")) 
                        return true; 
            }
            catch
            {
                return false;
            }
        }

        // https://stackoverflow.com/questions/25678690/how-can-i-check-github-releases-in-c
        public byte GetGithubVersion()
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("muputils"));
            IReadOnlyList<Release> releases = client.Repository.Release.GetAll("Aurumaker72", "MupenUtilities").Result;
            Version latestGitHubVersion = new Version(releases[0].TagName);

            Version localVersion = new Version(MainForm.PROGRAM_VERSION);
            int versionComparison = localVersion.CompareTo(latestGitHubVersion);

            if (versionComparison < 0)
                return MainForm.UPDATE_CLIENT_OUTDATED;
            else if (versionComparison > 0)
                return MainForm.UPDATE_CLIENT_AHEAD;
            else
                return MainForm.UPDATE_EQUAL;
        }
    }
}
