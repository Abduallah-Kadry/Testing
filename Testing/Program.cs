﻿using System;
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
    public string DoctorAppointment3 { get; set; }

    public static int indexNum1;
    public static int indexNum2;

    public static string drName;
    public static string drTime;

    public static string[] clinicArr = new string[5]
    {
        "InternalMedicine",
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

        string stringInFile = "\nname:" + name + "\naddress:" + address + "\ngender:" + gender + "\nbloodType:" + bloodType +
         "\ndisease:" + disease + "\nphone:" + phone + "\nid:" + id + "\nage:" + age + "\nThis profile has an appointment with Dr."+ Doctor.drName + " at "+ Doctor.drTime;

        string fileName = name + ".txt";

        File.WriteAllText(@"C:\Users\spect\Desktop\Testing\"+fileName, stringInFile);
    }
}

class Program
{
    static void Main()
    {
        mkDoctor.mkDoctors();
        strings.printString1();

        var c1 = int.Parse(Console.ReadLine());
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
            ClinicName = "InternalMedicine",
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
            ClinicName = "InternalMedicine",
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