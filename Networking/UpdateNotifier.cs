﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Forms;
using Octokit;

namespace MupenUtils.Networking
{
    public class UpdateNotifier
    {
        public void CheckForUpdates(byte versionResult, bool silenced)
        {
            if (versionResult == MainForm.UPDATE_UNKNOWN)
            versionResult = GetGithubVersion();

            if ((versionResult == MainForm.UPDATE_CLIENT_AHEAD || versionResult == MainForm.UPDATE_EQUAL) && !silenced)
                System.Windows.Forms.MessageBox.Show("You are up to date!",MainForm.PROGRAM_NAME + " - Up to date");
            else if (versionResult == MainForm.UPDATE_CLIENT_OUTDATED && System.Windows.Forms.MessageBox.Show("Your " + MainForm.PROGRAM_NAME + " is outdated. Do you want to download the latest release?", MainForm.PROGRAM_NAME + " - Outdated!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Process.Start("https://github.com/Aurumaker72/MupenUtilities/zipball/main");
            
        }
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
