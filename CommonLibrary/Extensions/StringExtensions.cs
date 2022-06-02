namespace CommonLibrary.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks a given string to see if it's numeric
        /// </summary>
        /// <param name="value"></param>
        /// <returns>bool</returns>
        public static bool IsNumeric(this string value)
        {
            if (string.IsNullOrEmpty(value)) { return false; }
            return float.TryParse(value, out float x);
        }

        /// <summary>
        /// Parse string to float
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ParseFloat(this string value)
        {
            return float.Parse(value);
        }
    }
}
