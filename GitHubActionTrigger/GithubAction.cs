using LibGit2Sharp;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace GitHubActionTrigger;
public static class GithubAction
{
    
    public async static Task<bool> ActionTrigger(string githubToken, string githubRepo)
    {
        var url = $"https://api.github.com/repos/{githubRepo}/dispatches";

        using var httpClient = new HttpClient();
       
        var payload = new
        {
            event_type = "trigger-build"
        };

        var httpMessage = new HttpRequestMessage(HttpMethod.Post, url);
        httpMessage.Headers.Add("Authorization", $"token {githubToken}");
        httpMessage.Headers.Add("User-Agent", "YourAppName");

        var json = JsonSerializer.Serialize(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        httpMessage.Content = content;

        var response = await httpClient.SendAsync(httpMessage);
        var responseContent = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"Response: {responseContent}");

        return response.IsSuccessStatusCode;
    }

    private async static Task<bool> LastTriggerStatus(string githubToken, string githubRepo)
    {
        var url = $"https://api.github.com/repos/{githubRepo}/actions/runs";
        using var httpClient = new HttpClient();
        var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);
        httpMessage.Headers.Add("Authorization", $"token {githubToken}");

        ////to be con.........
        ///
        return false;
    }

}
public class Root
{
    public int total_count { get; set; }
    public List<WorkflowRun> workflow_runs { get; set; }
}

public class WorkflowRun
{
    public string display_title { get; set; }
    public string status { get; set; }
    public string conclusion { get; set; }
}
