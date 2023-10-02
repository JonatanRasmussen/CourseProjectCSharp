

namespace CourseProject;

public class Info
{
    public enum GenericInfoType
    {
        CourseID,
        CourseName,
        Year,
        Announcement,
        StudyLines,
        LastUpdated,
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