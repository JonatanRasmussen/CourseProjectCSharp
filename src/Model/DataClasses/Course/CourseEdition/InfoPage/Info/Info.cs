

namespace CourseProject;

public class Info
{
    public string TableKey { get; }
    public string Value { get; }

    public Info(string tableKey, string value)
    {
        TableKey = tableKey;
        Value = value;
    }

    public enum PrimaryTableInfoType
    {
        DanishTitle,
        LanguageOfInstruction,
        Ects,
        CourseType,
        Location,
        ScopeAndForm,
        DurationOfCourse,
        DateOfExamination,
        TypeOfAssessment,
        ExamDuration,
        Aid,
        Evaluation,
        Responsible,
        CourseCoResponsible,
        Department,
        HomePage,
        RegistrationSignUp,
        GreenChallengeParticipation,
        Schedule,
        NotApplicableTogetherWith,
        RecommendedPrerequisites,
        PreviousCourse,
        ParticipantsRestrictions,
        MandatoryPrerequisites,
        DepartmentInvolved,
        ExternalInstitution,
    }
    public enum SecondaryTableInfoType
    {
        GeneralCourseObjectives,
        LearningObjectives,
        Content,
        CourseLiterature,
        Remarks,
    }
}