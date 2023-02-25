namespace Home_Works_Library
{
    public class Home_Work_01
    {
        public static void main()
        {
            // exercise 1

            Console.WriteLine("Please enter two strings: ");
            string string1 = Console.ReadLine();
            string string2 = Console.ReadLine();

            bool isEqual = CheckLowerUpperEquals(string1, string2);

            if (isEqual == true)
                Console.WriteLine("The two string are equals (ignoring camelcase)");
            else
                Console.WriteLine("The two string are not equals (ignoring camelcase)");

            //////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine();
            /////////////////////////////////////////////////////////////////////////////////////////////////
            
            // exercise 2

            Console.WriteLine("Please enter username and emailtype: ");
            string username = Console.ReadLine();
            string emailtype = Console.ReadLine();

            string msg = ToEmail(username, emailtype);

            if (msg.Contains('@') == true)
                Console.WriteLine($"Valid: {msg}");
            else
                Console.WriteLine($"Not valid: {msg}");

        }


        public static bool CheckLowerUpperEquals(string s1, string s2)
        {
            if (s1.ToLower() == s2.ToLower())
                return true;
            else
                return false;
        }

        public static string ToEmail(string username, string emailtype)
        {
            string msg = "";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(emailtype))
                msg += "*At least One of the parametters is empty! ";

            if (username.Length > 10)
                msg += "*Not valid username length! ";

            if (username.Contains('.') || username.Contains('_'))
                msg += "*. or _ are not allowed for username";

            if (msg == "")
                msg = $"{username}@{emailtype}.com";

            return msg;
        }
    }
}