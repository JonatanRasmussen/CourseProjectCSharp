

namespace CourseProject;

public class TimeInterval
{
    public static readonly string EmptyTimeName = "Timeless";
    public Term Term { get; private set; }
    public AcademicYear AcademicYear { get; private set; }
    public string Name { get; private set; }

    public TimeInterval()
    {
        Term = Term.CreateEmpty();
        AcademicYear = Term.AcademicYear;
        Name = EmptyTimeName;
    }

    public static TimeInterval CreateTimeIntervalFromString(string timeString)
    {
        var timeInterval = new TimeInterval();
        if (InputCanBeParsedAsYear(timeString))
        {
            int firstYear = int.Parse(timeString[..4]);
            var academicYear = new AcademicYear(firstYear);
            timeInterval.SetAcademicYear(academicYear);
        }
        else if (InputIsValidTermCode(timeString))
        {
            string termCode = timeString;
            var term = Term.CreateFromTermCode(termCode);
            timeInterval.SetTerm(term);
        }
        else
        {
            throw new Exception($"Failed to parse {timeString} as a termCode or a year.");
        }
        return timeInterval;
    }

    public static TimeInterval CreateEmpty()
    {
        return new TimeInterval();
    }

    private void UpdateTimePeriodName()
    {
        if (!Term.IsEmpty())
        {
            Name = Term.Name;
        }
        else if (!AcademicYear.IsEmpty())
        {
            Name = AcademicYear.Name;
        }
        else
        {
            Name = EmptyTimeName;
        }
    }

    public void SetAcademicYear(AcademicYear academicYear)
    {
        AcademicYear = academicYear;
        UpdateTimePeriodName();
    }

    public void SetTerm(Term term)
    {
        Term = term;
        SetAcademicYear(term.AcademicYear);
    }

    private static bool InputIsValidTermCode(string input)
    {
        if (input.Length != 3)
        {
            return false;
        }
        if (!char.IsLetter(input[0]))
        {
            return false;
        }
        if (!char.IsDigit(input[1]) || !char.IsDigit(input[2]))
        {
            return false;
        }
        return true;
    }

    private static bool InputCanBeParsedAsYear(string input)
    {
        if (input.Length < 4)
        {
            return false;
        }
        for (int i = 0; i < 4; i++)
        {
            if (!char.IsDigit(input[i]))
            {
                return false;
            }
        }
        return true;
    }
}