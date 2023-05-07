namespace UtilityLibrary
{
    public static class RegistrationLibrary
    {
        public static bool areNull(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return true;
            }
            return false;
        }
    }
}