namespace Toolkit.Validation
{
    public static class ValidationMessage
    {
        /// <summary>
        /// Must specify {what}
        /// </summary>
        public static string MustSpecify( string what ) => $"Must specify {what}";

        /// <summary>
        /// Exceeded max length {what}
        /// </summary>
        public static string ExceededMaxLength( string what ) => $"Exceeded max length {what}";

        /// <summary>
        /// {what} must be {whichOf}
        /// </summary>
        public static string MustBe( string what, string whichOf ) => $"{what} must be {whichOf}";

        /// <summary>
        /// {what} must be null
        /// </summary>
        public static string MustBeNull( string what ) => $"{what} must be null";

        /// <summary>
        /// {what} length must be {whichOf}
        /// </summary>
        public static string LengthMustBe( string what, string whichOf ) => $"{what} length must be {whichOf}";

        /// <summary>
        /// {what} length must be {whichOf}
        /// </summary>
        public static string LengthMustBe( string what, int whichOf ) => $"{what} length must be {whichOf}";

        /// <summary>
        /// {what} must be equal {whichOf}
        /// </summary>
        public static string MustBeEqual( string what, string whichOf ) => $"{what} must be equal {whichOf}";

        /// <summary>
        /// {what} must be equal {whichOf}
        /// </summary>
        public static string MustBeEqual( string what, int whichOf ) => $"{what} must be equal {whichOf}";

        /// <summary>
        /// {what} can't be changed
        /// </summary>
        public static string CanNotBeChanged( string what ) => $"{what} can't be changed";

        /// <summary>
        /// {what} can't be {whichOf}
        /// </summary>
        public static string CanNotBe( string what, string whichOf ) => $"{what} can't be {whichOf}";

        /// <summary>
        /// {what} must be greater than {whichOf}
        /// </summary>
        public static string MustBeGreater( string what, string whichOf ) => $"{what} must be greater than {whichOf}";

        /// <summary>
        /// {what} must be greater or equal {whichOf}
        /// </summary>
        public static string MustBeGreaterOrEqual( string what, string whichOf ) =>
            $"{what} must be greater or equal {whichOf}";

        /// <summary>
        /// {what} must be greater or equal {whichOf}
        /// </summary>
        public static string MustBeGreaterOrEqual( string what, decimal whichOf ) =>
            $"{what} must be greater or equal {whichOf}";

        /// <summary>
        /// {what} must be less than {whichOf}
        /// </summary>
        public static string MustBeLess( string what, string whichOf ) => $"{what} must be less than {whichOf}";

        /// <summary>
        /// {what} must be less or equal {whichOf}
        /// </summary>
        public static string MustBeLessOrEqual( string what, string whichOf ) =>
            $"{what} must be less or equal {whichOf}";

        /// <summary>
        /// {what} must be within the range [{start}, {end}]
        /// </summary>
        public static string MustBeWithinRange( string what, string start, string end ) =>
            $"{what} must be within the range [{start}, {end}]";

        /// <summary>
        /// {what} must be within the range [{start}, {end}]
        /// </summary>
        public static string MustBeWithinRange( string what, int start, int end ) =>
            $"{what} must be within the range [{start}, {end}]";

        /// <summary>
        /// {what} length must be within the range [{start}, {end}]
        /// </summary>
        public static string LengthMustBeWithinRange( string what, int start, int end ) =>
            $"{what} length must be within the range [{start}, {end}]";

        /// <summary>
        /// Could not support {what}
        /// </summary>
        public static string CouldNotSupport( string what ) => $"Could not support {what}";

        /// <summary>
        /// {what} not found
        /// </summary>
        public static string NotFound( string what ) => $"{what} not found";

        /// <summary>
        /// {what} not allowed
        /// </summary>
        public static string NotAllowed( string what ) => $"{what} not allowed";

        /// <summary>
        /// {what} already exists
        /// </summary>
        public static string AlreadyExists( string what ) => $"{what} already exists";

        /// <summary>
        /// {what} already {whatOf}
        /// </summary>
        public static string Already( string what, string whatOf ) => $"{what} already {whatOf}";

        /// <summary>
        /// Incorrect {what}
        /// </summary>
        public static string Incorrect( string what ) => $"Incorrect {what}";

        /// <summary>
        /// {what} does not exist
        /// </summary>
        public static string DoesNotExist( string what ) => $"{what} does not exist";
    }
}
