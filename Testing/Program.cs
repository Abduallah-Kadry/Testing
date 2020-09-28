using System;
using System.Collections.Generic;
using System.IO;

public class strings
{
    public static void printString1()
    {
        Console.Write(@"
 _______________________________________________________
|                                                       |
|                                                       |
|                      Welcome To                       |
|              Hospital Management System               |
|                                                       |
|                                                       |
|_______________________________________________________|

Press any key to contniue . . .
");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine(@"
 _______________________________________________________
|                                                       |
|                                                       |
|             Hospital Management System                |
|            ----------------------------               |
|               Please Choose between:                  |
|                                                       |
|   1. Analysis department                              |
|   2. Clinic department                                |
|_______________________________________________________|
");
    }
    public static void printString2()
    {
        Console.WriteLine(@"
 _______________________________________________________
|                                                       |
|     Please, Choose from the following Options:        |
|                                                       |
|        1  >>  Internal Medicine clinic                |
|        2  >>  Eye clinic                              |
|        3  >>  Ear,nose and throat clinic              |
|        4  >>  Urology clinic                          |
|        5  >>  General Surgery Clinic                  |
|                                                       |
|_______________________________________________________|
");
    }
}

public class Doctor
{
    public string ClinicName { get; set; }
    public string DoctorName { get; set; }
    public string DoctorAppointment1 { get; set; }
    public string DoctorAppointment2 { get; set; }

    public static int indexNum1;
    public static int indexNum2;

    public static string drName;
    public static string drTime;

    public static string[] clinicArr = new string[5]
    {
        "InternalMedicine clinic",
        "Heart clinic",
        "Ear,nose and throat clinic",
        "Urology clinic",
        "General Surgery Clinic",
    };

    public static List<int> indexList = new List<int>();

    public static void printDoctor(List<Doctor> enterdList, int i)
    {
        foreach (Doctor e in enterdList)
        {
            if (e.ClinicName == clinicArr[i - 1])
            {
                Console.WriteLine("Doctor: {0}", e.DoctorName);
                Console.WriteLine("\nAvailable times:\n");
                Console.WriteLine("\t" + e.DoctorAppointment1);
                Console.WriteLine("\t" + e.DoctorAppointment2);
                Console.WriteLine("\n____________________________");

            }
            indexNum1 = i;
        }
    }

    public static void chooseDoctor(List<Doctor> enterdList, int i)
    {
        foreach (Doctor e in enterdList)
        {
            if (e.ClinicName == clinicArr[indexNum1 - 1])
            {
                indexList.Add(enterdList.IndexOf(e));
            }

        }
        while (i < 1 || i > 2)
        {
            Console.Write("\nWrong Choice ... Please choose between the two doctors:");
            i = int.Parse(Console.ReadLine());
        }
        if (i == 1)
        {
            Console.WriteLine("\nYou have choosen Dr.{0}", enterdList[indexList[0]].DoctorName);
            indexNum2 = i;
            drName = enterdList[indexList[0]].DoctorName;
        }
        else if (i == 2)
        {
            Console.WriteLine("\nYou have choosen Dr.{0}", enterdList[indexList[1]].DoctorName);
            indexNum2 = i;
            drName = enterdList[indexList[0]].DoctorName;
        }
    }

    public static void chooseTime(List<Doctor> enterdList, int z)
    {
        while (z < 1 || z > 2)
        {
            Console.Write("\nWrong Choice ... Please choose between the two Times:");
            z = int.Parse(Console.ReadLine());
        }
        if (z == 1)
        {
            Console.WriteLine("\nYou have choosen to make the appointment at: {0}", enterdList[indexList[indexNum2 - 1]].DoctorAppointment1);
            drTime = enterdList[indexList[indexNum2 - 1]].DoctorAppointment1;
        }
        else if (z == 2)
        {
            Console.WriteLine("\nYou have choosen to make the appointment at: {0}", enterdList[indexList[indexNum2 - 1]].DoctorAppointment2);
            drTime = enterdList[indexList[indexNum2 - 1]].DoctorAppointment1;
        }
    }
}

public class profCreate
{
    static string name;
    static string address;
    static string gender;
    static string bloodType;
    static string disease;
    static double phone;
    static double id;
    static double age;

    public static void createFile()
    {
        Console.Write("\nnow to finish your reservation please enter your profile information:\n");

        Console.Write("\nName:");
        name = Console.ReadLine();
        Console.Write("address:");
        address = Console.ReadLine();
        Console.Write("gender:");
        gender = Console.ReadLine();
        Console.Write("bloodType:");
        bloodType = Console.ReadLine();
        Console.Write("disease:");
        disease = Console.ReadLine();
        Console.Write("phone:");
        phone = int.Parse(Console.ReadLine());
        Console.Write("id:");
        id = int.Parse(Console.ReadLine());
        Console.Write("age:");
        age = int.Parse(Console.ReadLine());

        string stringInFile = "Name:" + name + "\nAddress:" + address + "\nGender:" + gender + "\nBloodType:" + bloodType +
         "\nDisease:" + disease + "\nPhone:" + phone + "\nID:" + id + "\nAge:" + age + "\nThis profile has an appointment with Dr." 
         + Doctor.drName + " at " + Doctor.drTime + " at " + Doctor.clinicArr[Doctor.indexNum1 - 1];

        string fileName = name + ".txt";

        File.WriteAllText(@"C:\Users\spect\Desktop\Testing\" + fileName, stringInFile);

        Console.WriteLine("Your profile has been created successfully");
    }
}

class mkDoctor
{
    public static List<Doctor> DoctorList = new List<Doctor>();

    public static void mkDoctors()
    {

        Doctor doc1 = new Doctor()
        {
            ClinicName = "Heart clinic",
            DoctorName = "Ahmed AlMasry",
            DoctorAppointment1 = "Tuesday from 9am to 5pm",
            DoctorAppointment2 = "Friday  from 2pm to 7pm"
        };
        Doctor doc2 = new Doctor()
        {
            ClinicName = "InternalMedicine clinic",
            DoctorName = "Ahmed Abdullah",
            DoctorAppointment1 = "Sunday from 11am to 6pm",
            DoctorAppointment2 = "Wednesday from 7am to 2pm"
        };
        Doctor doc3 = new Doctor()
        {
            ClinicName = "General Surgery Clinic",
            DoctorName = "Ahmed Atef",
            DoctorAppointment1 = "Thursday from 5pm to 9pm",
            DoctorAppointment2 = "Saturday from 10am to 1pm"
        };
        Doctor doc4 = new Doctor()
        {
            ClinicName = "InternalMedicine clinic",
            DoctorName = "Moahmoud Elsaeed",
            DoctorAppointment1 = "Friday from 12pm to 8pm",
            DoctorAppointment2 = "Sunday from 9am to 4pm"
        };
        Doctor doc5 = new Doctor()
        {
            ClinicName = "Ear,nose and throat clinic",
            DoctorName = "Mohamed Sherif",
            DoctorAppointment1 = "Sunday from 10pm to 1am",
            DoctorAppointment2 = "Wednesday from 10pm to 1pm"
        };
        Doctor doc6 = new Doctor()
        {
            ClinicName = "General Surgery Clinic",
            DoctorName = "Sayed Khairy",
            DoctorAppointment1 = "Monday from 11am to 5pm",
            DoctorAppointment2 = "Wednesday from 2pm to 9pm"
        };
        Doctor doc7 = new Doctor()
        {
            ClinicName = "Ear,nose and throat clinic",
            DoctorName = "Ahmed Metwaly",
            DoctorAppointment1 = "Thursday from 8am to 3pm",
            DoctorAppointment2 = "Sunday from 1pm to 7pm"
        };
        Doctor doc8 = new Doctor()
        {
            ClinicName = "Urology clinic",
            DoctorName = "Shehab Ayman",
            DoctorAppointment1 = "Tuesday from 2pm to 9pm",
            DoctorAppointment2 = "Friday from 3pm to 11pm"
        };
        Doctor doc9 = new Doctor()
        {
            ClinicName = "Heart clinic",
            DoctorName = "Karim Ashraf",
            DoctorAppointment1 = "Saturday from 11am to 6pm",
            DoctorAppointment2 = "Wednesday from 4pm to 12am"
        };
        Doctor doc10 = new Doctor()
        {
            ClinicName = "Urology clinic",
            DoctorName = "Anas Hosny",
            DoctorAppointment1 = "Monday from 9am to 3pm",
            DoctorAppointment2 = "Thursday from 2pm to 9pm"
        };
        DoctorList.Add(doc1);
        DoctorList.Add(doc2);
        DoctorList.Add(doc3);
        DoctorList.Add(doc4);
        DoctorList.Add(doc5);
        DoctorList.Add(doc6);
        DoctorList.Add(doc7);
        DoctorList.Add(doc8);
        DoctorList.Add(doc9);
        DoctorList.Add(doc10);
    }
}

public static class printarray
{
    public static void printlabels(List<string> aks)
    {
        Console.WriteLine("Please choose from the following Analyzes:\n");
        foreach (string i in aks)
        {
            Console.WriteLine(i);
        }

    }
}

public class dictionary
{
    public int id { get; set; }
    public string analyzingName { get; set; }
    public int analyzingPrice { get; set; }

}
public class printtotalprice : dictionary
{
    static int o = 0;

    public static void print(Dictionary<int, dictionary> abe)
    {
        Console.Write("Please Enter your choice:");

        int z = int.Parse(Console.ReadLine());

        while (z > 10 || z < 0)
        {
            Console.WriteLine("Wrong Choice ... please Choose again");
            Console.Write("Your chice:");
            z = int.Parse(Console.ReadLine());
        }

        int Totalprice = 0;

        do
        {
            Totalprice = Totalprice + abe[z].analyzingPrice;
            z += z;
            Console.WriteLine("Do you want to choose another analysis");
            Console.WriteLine("Write \"yes\" if you want to continue:");
            string s = Console.ReadLine();
            if (s == "yes")
            {
                Console.WriteLine("Please Enter your choice");
                z = int.Parse(Console.ReadLine());
                while (z > 10 || z < 0)
                {
                    Console.WriteLine("Wrong Choice ... please Choose again");
                    Console.Write("Your chice:");
                    z = int.Parse(Console.ReadLine());
                }
                Totalprice += abe[z].analyzingPrice;
            }
            else
            {
                break;
            }
            o += 1;

        } while (o <= 10);

        Console.WriteLine("The Total Price is {0}", Totalprice);

        Console.WriteLine("\nThe process has been done sucessfully");
    }
}

class Program
{
    static void Main()
    {
        mkDoctor.mkDoctors();
        strings.printString1();

        var c1 = int.Parse(Console.ReadLine());

        while (c1 > 2 || c1 < 1)
        {
            Console.WriteLine("\nWrong choice ... Please chose again!");
            Console.Write("Your Choice is:");
            c1 = int.Parse(Console.ReadLine());
        }
        if (c1 == 1)
        {
            Console.Clear();
            strings.printString2();

            Console.Write("\nPlease choose the clinic department you want:");

            int c2 = int.Parse(Console.ReadLine());
            while (c2 <= 0 || c2 > 5)
            {
                Console.WriteLine("\nIncorrect Choice ... Please Choose again!");
                Console.Write("\nChoose the clinic department you want:");
                c2 = int.Parse(Console.ReadLine());
            }

            Console.Clear();

            Doctor.printDoctor(mkDoctor.DoctorList, c2);

            Console.WriteLine("\nWhich doctor would you like to make appointment with?");
            Console.Write("Your choice is:");

            int c3 = int.Parse(Console.ReadLine());

            Doctor.chooseDoctor(mkDoctor.DoctorList, c3);

            Console.WriteLine("\nWhich time would you like to make appointment at?");
            Console.Write("Your choice is:");

            int c4 = int.Parse(Console.ReadLine());

            Doctor.chooseTime(mkDoctor.DoctorList, c4);

            profCreate.createFile();
        }
        else if (c1 == 2)
        {

            List<string> arraydictionary = new List<string> { "1. C.B.C", "2. R.B.C", "3. L.C.D", "4. W.B.C", "5. Hgb",
                "6. E.S.R", "7. APTT", "8. G6PD", "9. TSH", "10. C.B.R" };

            Dictionary<int, dictionary> analyzingdictionary = new Dictionary<int, dictionary>();

            dictionary analyzing1 = new dictionary()
            {
                analyzingName = "C.B.C",
                id = 1,
                analyzingPrice = 300

            };
            dictionary analyzing2 = new dictionary()
            {
                analyzingName = "R.B.C",
                id = 2,
                analyzingPrice = 400

            };
            dictionary analyzing3 = new dictionary()
            {
                analyzingName = "L.C.D",
                id = 3,
                analyzingPrice = 500

            };
            dictionary analyzing4 = new dictionary()
            {
                analyzingName = "W.B.C",
                id = 4,
                analyzingPrice = 600

            };
            dictionary analyzing5 = new dictionary()
            {
                analyzingName = "Hgb",
                id = 5,
                analyzingPrice = 700

            };
            dictionary analyzing6 = new dictionary()
            {
                analyzingName = "E.S.R",
                id = 6,
                analyzingPrice = 800

            };
            dictionary analyzing7 = new dictionary()
            {
                analyzingName = "APTT",
                id = 7,
                analyzingPrice = 350

            };
            dictionary analyzing8 = new dictionary()
            {
                analyzingName = "G6PD",
                id = 8,
                analyzingPrice = 550

            };
            dictionary analyzing9 = new dictionary()
            {
                analyzingName = "TSH",
                id = 9,
                analyzingPrice = 650

            };
            dictionary analyzing10 = new dictionary()
            {
                analyzingName = "C.B.R",
                id = 10,
                analyzingPrice = 750
            };
            analyzingdictionary.Add(analyzing1.id, analyzing1);
            analyzingdictionary.Add(analyzing2.id, analyzing2);
            analyzingdictionary.Add(analyzing3.id, analyzing3);
            analyzingdictionary.Add(analyzing4.id, analyzing4);
            analyzingdictionary.Add(analyzing5.id, analyzing5);
            analyzingdictionary.Add(analyzing6.id, analyzing6);
            analyzingdictionary.Add(analyzing7.id, analyzing7);
            analyzingdictionary.Add(analyzing8.id, analyzing8);
            analyzingdictionary.Add(analyzing9.id, analyzing9);
            analyzingdictionary.Add(analyzing10.id, analyzing10);

            printarray.printlabels(arraydictionary);
            printtotalprice.print(analyzingdictionary);
        }
    }
}

