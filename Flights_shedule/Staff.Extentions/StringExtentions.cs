namespace Staff.Extentions
{
    public static class StringExtentions
    {
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        public static string TrimOrNull(this string value)
        {
            var trimmed = value?.Trim();
            return trimmed.IsNullOrEmpty() ? null : trimmed;
        }
    }
}
