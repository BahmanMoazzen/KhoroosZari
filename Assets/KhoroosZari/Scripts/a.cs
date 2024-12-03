using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;

public static class a 
{
    public static class b
    {
        public static string FetchURI = "https://www.google.com";
        public static string GoogleContainText = "schema.org/WebPage";
        public static string IsAdRemovedTag = "isAdRemoved";
        public static string SceneNumberTag = "sceneNumber";
        public static string IsLoadingText = "Is Loading ...";
        public static string AdRemovedText = "Ad Removed Successfuly";
        public static string PlaySongText = "In Recent Future";
        public static string[] ChapterNames = { "scnChapter1" };
        public static string TitleMenuSceneName = "scnTitleMenu";
    }
    public static bool IsConnectedtoInternet()
    {
        string HtmlText = GetHtmlFromUri("https://google.com");
        if (HtmlText == "")
        {
            return false;
        }
        else if (!HtmlText.Contains(a.b.GoogleContainText))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private static string GetHtmlFromUri(string resource)
    {
        string html = string.Empty;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
        try
        {
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                if (isSuccess)
                {
                    using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                    {
                        //We are limiting the array to 80 so we don't have
                        //to parse the entire html document feel free to 
                        //adjust (probably stay under 300)
                        char[] cs = new char[80];
                        reader.Read(cs, 0, cs.Length);
                        foreach (char ch in cs)
                        {
                            html += ch;
                        }
                    }
                }
            }
        }
        catch
        {
            return "";
        }
        return html;
    }
}
