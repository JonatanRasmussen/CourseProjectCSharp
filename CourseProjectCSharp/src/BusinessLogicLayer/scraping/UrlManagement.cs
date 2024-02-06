

namespace CourseProject;

public static class UrlManagement
{
    public static readonly string CourseBaseUrl = "https://kurser.dtu.dk/course/";
    public static readonly string GradesUrl = "https://karakterer.dtu.dk/Histogram/";
    public static readonly string EvaluationsUrl = "https://evaluering.dtu.dk/kursus/";
    public static readonly string EvaluationsSearchUrl = "https://evaluering.dtu.dk/CourseSearch";
    public static readonly string CourseArchiveUrl = "https://kurser.dtu.dk/archive";
    public static readonly string ArchiveVolumesUrl = "https://kurser.dtu.dk/archive/volumes";

    public static string GetUrlForSpecificVolume(AcademicYear academicYear)
    {
        return $"{CourseArchiveUrl}/{academicYear}";
    }

    public static List<string> CourseArchive(AcademicYear academicYear)
    {
        // Deterministically generate a list of URLs that cover the full course archive for a given academic year.
        // The course list is split across several URLs, one per starting letter.
        // Example URL: https://kurser.dtu.dk/archive/2022-2023/letter/A
        const string UrlHostname = "https://kurser.dtu.dk";
        List<string> Alphabet = new()
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
            "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            "U", "V", "W", "X", "Y", "Z", "Æ", "Ø", "Å",
        };
        List<string> Urls = new()
        {
            ArchiveVolumesUrl
        };
        foreach (string character in Alphabet)
        {
            string urlPath = $"{GetUrlForSpecificVolume(academicYear)}/letter/{character}";
            string fullUrl = UrlHostname + urlPath;
            Urls.Add(fullUrl);
        }
        return Urls;
    }
}
