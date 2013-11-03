using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracker
{
    class ProjectNames
    {
        private static string[] NAMES = new String[] {
            "Ashley", "Jessica", "Emily", "Sarah", "Samantha", "Brittany", "Amanda", "Elizabeth", "Taylor",
            "Megan", "Stephanie", "Kayla", "Lauren", "Jennifer", "Rachel", "Hannah", "Nicole", "Amber",
            "Alexis", "Courtney", "Victoria", "Danielle", "Alyssa", "Rebecca", "Jasmine", "Katherine",
            "Melissa", "Alexandra", "Brianna", "Chelsea", "Michelle", "Morgan", "Kelsey", "Tiffany", "Kimberly",
            "Christina", "Madison", "Heather", "Shelby", "Anna", "Mary", "Maria", "Allison", "Sara", "Laura",
            "Andrea", "Olivia", "Erin", "Haley", "Abigail", "Kaitlyn", "Jordan", "Natalie", "Vanessa", "Kelly",
            "Brooke", "Erica", "Kristen", "Julia", "Crystal", "Amy", "Katelyn", "Marissa", "Lindsey", "Paige",
            "Cassandra", "Sydney", "Katie", "Caitlin", "Kathryn", "Emma", "Shannon", "Angela", "Gabrielle",
            "Jacqueline", "Jenna", "Jamie", "Mariah", "Alicia", "Briana", "Alexandria", "Destiny", "Miranda",
            "Monica", "Brittney", "Catherine", "Savannah", "Sierra", "Sabrina", "Breanna", "Whitney", "Caroline",
            "Molly", "Madeline", "Erika", "Grace", "Diana", "Leah", "Angelica", "Lindsay"};

        private static Random random = new Random();

        public static String GenerateName()
        {
            return NAMES[random.Next(NAMES.Length)];
        }
    }
}
