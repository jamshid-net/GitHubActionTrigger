using LibGit2Sharp;

namespace GitHubActionTrigger;
public class GithubRepoClonner
{
    public static void Clone(string githubToken, string repositoryUrl, string clonePath)
    {

        var cleanUrl = repositoryUrl.Substring(8);
        var cloneUrl = $"https://{githubToken}@{cleanUrl}";
        CloneOptions options = new CloneOptions()
        {


            BranchName = "output-front"
        };
        options.OnCheckoutProgress = CheckoutProgress;

        Console.WriteLine("Cloning repository...");
        Repository.Clone(cloneUrl, clonePath, options);
        Console.WriteLine("Repository cloned successfully.");

    }

    private static void CheckoutProgress(string path, int completedSteps, int totalSteps)
    {
        double percentage = (double)completedSteps / totalSteps * 100;
        int progressBarWidth = 50; // Width of the progress bar
        int filledBars = (int)(percentage / 100 * progressBarWidth); // Number of filled segments
        int emptyBars = progressBarWidth - filledBars; // Remaining empty segments

        string progressBar = new string('█', filledBars) + new string('░', emptyBars); // Construct progress bar


        Console.SetCursorPosition(0, Console.CursorTop);


        Console.Write($"[{progressBar}] {percentage:F2}% ({completedSteps}/{totalSteps})");


        Console.Write(new string(' ', Console.WindowWidth - Console.CursorLeft));
    }
}
