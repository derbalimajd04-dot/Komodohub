namespace KomodoHub
{
    public static class RoleHelper
    {
        public static bool IsTeacher()
            => KomodoHub.UserRole.Equals("TEACHER", System.StringComparison.OrdinalIgnoreCase);

        public static bool IsAdmin()
            => KomodoHub.UserRole.Equals("ADMIN", System.StringComparison.OrdinalIgnoreCase)
            || KomodoHub.UserRole.Equals("SCHOOL_ADMIN", System.StringComparison.OrdinalIgnoreCase);

        public static bool IsTeacherOrAdmin()
            => IsTeacher() || IsAdmin();

        public static bool IsStudent()
            => KomodoHub.UserRole.Equals("STUDENT", System.StringComparison.OrdinalIgnoreCase);

        public static bool IsGuest()
            => Properties.Settings.Default.LoggedIn == 2;

        public static bool IsLoggedIn()
            => Properties.Settings.Default.LoggedIn == 1;
    }
}