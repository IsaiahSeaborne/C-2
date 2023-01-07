using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI
{
    public static class Extension
    {
        
        public static string Left(this string name, int length)
        {
            if (name == null)
                return null;
            int stringLength = name.Length;
            if (length >= stringLength)
                return name;
            return name.Substring(0, length);
        }
        public static string Right(this string name, int length)
        {
            if (name == null)
                return null;
            int stringLength = name.Length;
            if (length >= stringLength)
                return name;
            return name.Substring(stringLength - length, length);
        }
        public static string ZipCode(this int zip)
        {
            

            string zipp = zip.ToString().PadLeft(5, '0');
            Console.WriteLine(zipp);
            return zipp;
            
        }
    }
    public class ExtensionTutorial
    {
        public ExtensionTutorial()
        {
            var name = "Amanda Shelton";
            var firstName = name.Left(3);
            var lastName = name.Right(4);
            Console.WriteLine($"Name: {name}\t\tFirstName: {firstName}");
            Console.WriteLine($"LastName: {lastName}");
        }
    }
   
}
