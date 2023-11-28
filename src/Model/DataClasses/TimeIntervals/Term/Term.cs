

using System.Diagnostics;

namespace CourseProject;

public class Term
{
    public static readonly string AutumnSemesterKey = "E";
    public static readonly string SpringSemesterKey = "F";
    public static readonly string UnknownSemesterKey = "X";
    public enum DtuSemesterType
    {
        Autumn,
        Spring,
        EmptyValue,
    }
    public static readonly Dictionary <DtuSemesterType,string> SemesterKeys = new()
    {
        { DtuSemesterType.Autumn, AutumnSemesterKey },
        { DtuSemesterType.Spring, SpringSemesterKey },
        { DtuSemesterType.EmptyValue, UnknownSemesterKey },
    };
    public DtuSemesterType Semester { get; }
    public AcademicYear AcademicYear { get; }
    public string Name { get; }
    private Term(DtuSemesterType semester, AcademicYear academicYear)
    {
        Semester = semester;
        AcademicYear = academicYear;
        Name = GenerateName(Semester, AcademicYear);
    }

    public static Term CreateAutumnSemester(AcademicYear academicYear)
    {
        var semester = DtuSemesterType.Autumn;
        return new Term(semester, academicYear);
    }

    public static Term CreateSpringSemester(AcademicYear academicYear)
    {
        var semester = DtuSemesterType.Spring;
        return new Term(semester, academicYear);
    }

    public static Term CreateEmpty()
    {
        var semester = DtuSemesterType.EmptyValue;
        var academicYear = AcademicYear.CreateEmpty();
        return new Term(semester, academicYear);
    }

    public static Term CreateFromTermCode(string termCode)
    {
        var semester = ParseSemester(termCode);
        int startYear = ParseYear(termCode);
        var academicYear = new AcademicYear(startYear);
        return new Term(semester, academicYear);
    }

    public static string GenerateName(DtuSemesterType semester, AcademicYear academicYear)
    {
        return semester switch
        {
            DtuSemesterType.Autumn => $"{AutumnSemesterKey}{academicYear.StartYear - 2000}",
            DtuSemesterType.Spring => $"{SpringSemesterKey}{academicYear.EndYear - 2000}",
            DtuSemesterType.EmptyValue => "EmptyTerm_PlaceHolderValue",
            _ => throw new ArgumentOutOfRangeException(nameof(semester), "Unknown semester"),
        };
    }

    public static DtuSemesterType ParseSemester(string termCode)
    {
        string firstLetter = termCode[..1];
        if (firstLetter == AutumnSemesterKey || firstLetter.ToLower() == "v")
        {
            return DtuSemesterType.Autumn;
        }
        else if (firstLetter == SpringSemesterKey || firstLetter.ToLower() == "s")
        {
            return DtuSemesterType.Spring;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(firstLetter), "Unknown semester key");
        };
    }

    public static int ParseYear(string termCode)
    {
        if (int.TryParse(termCode[1..], out int numericPart))
        {
            int year = numericPart + 2000;
            return year;
        }
        else
        {
            throw new Exception($"Failed to parse numericPart of {termCode}.");
        }
    }

    public static List<string> GenerateTermRange(string startTermCode, string endTermCode)
    {
        List<string> result = new();
        int startNumber = int.Parse(startTermCode[1..]);
        string currentSemester = startTermCode[0].ToString();
        int endNumber = int.Parse(endTermCode[1..]);

        while (startNumber <= endNumber)
        {
            result.Add($"{currentSemester}{startNumber}");
            if (currentSemester == AutumnSemesterKey)
            {
                currentSemester = SpringSemesterKey;
            }
            else
            {
                currentSemester = AutumnSemesterKey;
                startNumber++;
            }
        }
        if (AutumnSemesterKey.Length != 1 || SpringSemesterKey.Length != 1)
        {
            throw new ArgumentException("Autumn/SpringSemesterKey must be single characters.");
        }
        return result;
    }

    public static List<int> GenerateYearRangeFromTerms(List<string> termList)
    {
        List<int> years = new();
        foreach (var term in termList)
        {
            if (int.TryParse(term[1..], out int numericPart))
            {
                int year = numericPart + 2000;
                if (!years.Contains(year))
                {
                    years.Add(year);
                }
            }
        }
        years.Sort();
        return years;
    }

    public bool IsEmpty()
    {
        if (Semester == DtuSemesterType.EmptyValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}