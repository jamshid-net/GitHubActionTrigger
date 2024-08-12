using LibGit2Sharp;

namespace GitHubActionTrigger;

internal class Program
{
    static async Task Main(string[] args)
    {
        var token = "token";

        string repoUrl = "giturl"; // Replace with your repository URL
        string localPath = @"D:\TestGitClone"; // Replace with the desired local path
        await GithubAction.ActionTrigger(token, "jamshid-net/MyOila");
    }

   
}
