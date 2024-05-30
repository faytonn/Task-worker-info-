using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace Task__worker_info_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Employee Management system.");

            List<string> name = new List<string>();
            List<string> surname = new List<string>();
            List<string> patronymic = new List<string>();
            List<int> age = new List<int>();
            List<string> FIN_Code = new List<string>();
            List<string> phoneNumber = new List<string>();
            List<string> positions = new List<string>();
            List<decimal> salary = new List<decimal>();


            while (true)
            {
                Console.WriteLine("Available commands:");
                Console.WriteLine("1. Add a new employee                    OR  /add");
                Console.WriteLine("2. View information about an employee    OR  /view");
                Console.WriteLine("3. Exit                                  OR  /exit");

                string command = Console.ReadLine();
                if (command == "1" || command == "/add")
                {
                    int i = 0;
                    while (true)
                    {
                        name.Add(nameInput());
                        surname.Add(surnameInput());
                        patronymic.Add(patronymicInput());
                        age.Add(ageInput());
                        FIN_Code.Add(FIN_Input());
                        phoneNumber.Add(phoneNumber_input());
                        positions.Add(positionInput());
                        salary.Add(salaryInput());
                        Console.WriteLine($"Employee added successfully. ({surname[i]}, {name[i]})");
                        Console.WriteLine("Enter command or type '/exit' to terminate:");
                        command = Console.ReadLine();
                        if (command == "/exit")
                            break;
                        i++;
                    }
                }
                else if (command == "2" || command == "/view")
                {
                    for (int i = 0; i < name.Count; i++)
                    {
                        Console.WriteLine($"FullName: {name[i]} {surname[i]} {patronymic[i]}, \nAge: {age[i]}, \nFIN: {FIN_Code[i]} \n Phone number: {phoneNumber[i]}, \nPosition: {positions[i]}, \nSalary: {salary[i]}");
                    }
                }
                else if (command == "3" || command == "/exit")
                {
                    Console.WriteLine("Program is terminated");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid command");

                }
            }
        }


        private static string nameInput()
        {
            string name;
            while (true)
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                if (OnlyFirstLetterCapital(name) && validCharacterLength(name, 2, 20))
                    break;

                else
                {
                    Console.WriteLine("Please enter a valid name (Length should be between 2 and 20, and only the first letter should be capital");
                }

            }
            return name;
        }

        private static string surnameInput()
        {
            string surname;
            while (true)
            {
                Console.Write("Surname: ");
                surname = Console.ReadLine();
                if (OnlyFirstLetterCapital(surname) && validCharacterLength(surname, 2, 35))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid surname (Length should be between 2 and 35, and only the first letter should be capital");
                }
            }
            return surname;
        }


        private static string patronymicInput()
        {
            string patronymic;
            while (true)
            {

                Console.Write("Patronymic: ");
                patronymic = Console.ReadLine();
                if (OnlyFirstLetterCapital(patronymic) && validCharacterLength(patronymic, 2, 20))
                    break;

                else
                {
                    Console.WriteLine("Please enter a valid patronymic (Length should be between 2 and 20, and only the first letter should be capital)");
                }

            }

            return patronymic;
        }

        private static int ageInput()
        {
            int age = 0;
            while (true)
            {
                Console.Write("Age: ");
                age = int.Parse(Console.ReadLine());
                if (age >= 18 && age <= 65)
                    break;
                else
                {
                    Console.WriteLine("Please enter a legal age of employment (Age should be between 18 and 65)");
                }

            }
            return age;
        }

        private static string FIN_Input()
        {
            string fin;
            while (true)
            {
                Console.Write("FIN Code: ");
                fin = Console.ReadLine();
                if (fin.Length == 7 && validFIN_Code(fin))
                    break;
                else
                {
                    Console.WriteLine("Please enter a valid FIN code (it should only consist of capital letters & numbers and should consist of 7 characters");
                }
            }
            return fin;
        }
        private static bool validFIN_Code(string FIN_Code)
        {
            string FIN;
            for (int i = 0; i < FIN_Code.Length; i++)
            {
                int value = (int)(FIN_Code[i]);
                if (!(value >= 65 && value <= 90) && !(value >= 48 && value <= 57))
                    return false;
            }
            return true;

        }

        private static string phoneNumber_input()
        {
            string phoneNumber;
            while (true)
            {
                Console.Write("Phone number: +994 ");
                phoneNumber = Console.ReadLine();
                if (phoneNumber.Length == 9 && validPhoneNumber(phoneNumber))
                    break;

                else
                {
                    Console.WriteLine("Please enter a valid phone number (The next digits after +994)");
                }
            }
            return phoneNumber;
        }
        private static bool validPhoneNumber(string phoneNumber)
        {
            bool correctNumber = true;
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                int value = (int)phoneNumber[i];
                if (value < 48 || value > 57)
                {
                    correctNumber = false;
                    break;
                }

            }

            return correctNumber;
        }

        private static string positionInput()
        {
            string[] positions = { "Engineer", "Audit", "HR" };
            string position;
            bool positionAssigned = false;

            while (true)
            {
                Console.Write("Position (HR, Audit, Engineer): ");
                position = Console.ReadLine();
                for (int i = 0; i < positions.Length; i++)
                {
                    if (position == positions[i])
                    {
                        positionAssigned = true;
                        break;
                    }
                }

                if (positionAssigned)
                    break;
                else
                {
                    Console.WriteLine("Please enter a valid position from the list: \n Engineer \n Audit \n HR");

                }
            }
            return position;
        }

        private static decimal salaryInput()
        {
            decimal salary;
            while (true)
            {
                Console.Write("Salary: ");
                salary = decimal.Parse(Console.ReadLine());
                if (salary >= 1500 && salary <= 5000)
                    break;
                else
                {
                    Console.WriteLine("Please enter a valid salary (The amount should be between 1500 and 5000");
                }
            }
            return salary;
        }


        private static bool OnlyFirstLetterCapital(string givenWord)
        {
            bool firstIsUpper = false;
            bool endIsLower = true;

            if ((int)givenWord[0] >= 65 && (int)givenWord[0] <= 90)
                firstIsUpper = true;

            for (int i = 1; i < givenWord.Length; i++)
            {
                int value = (int)givenWord[i];
                if (value < 97 || value > 122)
                {
                    endIsLower = false;
                    break;
                }
            }
            if (firstIsUpper && endIsLower)
                return true;

            return false;


        }

        private static bool validCharacterLength(string givenWord, int start, int end)
        {
            if (givenWord.Length > start && givenWord.Length < end)

                return true;
            return true;
        }

    }
}
