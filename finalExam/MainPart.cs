using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Data;
using System.Text.Json;
using Newtonsoft.Json;
using CV;
using Notification;
using Vacancy;
using Worker;


namespace finalExam
{
    internal class Func
    {
        #region CreatCv
        static public void CreatCv(Workerc worker, List<Workerc> workers, int index)
        {
            Console.Write("Enter qualification: ");
            var qualification = Console.ReadLine();
            Console.Write("Enter school you graduated: ");
            var school = Console.ReadLine();
            Console.Write("Enter university: ");
            var university = Console.ReadLine();
            Console.Write("Enter skill: ");
            var skill = Console.ReadLine();
            var skills = new List<string> { };
            skills.Add(skill);
            Console.Write("Do you want to add another skill? (Y/N)");
            while (true)
            {
                var result = Console.ReadLine();
                if (result.ToUpper() == "Y")
                {
                    Console.Write("Enter skill: ");
                    var newSkill = Console.ReadLine();
                    skills.Add(newSkill);
                    Console.Write("If you want to finish adding skill press n/N: ");
                }
                else if (result.ToUpper() == "N")
                {
                    break;
                }
            }
            Console.Write("Enter company: ");
            var companies = Console.ReadLine();
            var companiess = new List<string> { };
            companiess.Add(companies);
            Console.Write("Do you want to add another company? (Y/N)");
            Console.Write("Do you want to add another companie? (Y/N)");
            while (true)
            {
                var result = Console.ReadLine();
                if (result.ToUpper() == "Y")
                {
                    Console.Write("Enter company: ");
                    var newCompany = Console.ReadLine();
                    companiess.Add(newCompany);
                    Console.Write("If you want to finish adding company press n/N: ");
                }
                else if (result.ToUpper() == "N")
                {
                    break;
                }
            }
            Console.Write("Enter language: ");
            var language = Console.ReadLine();
            var languages = new List<string> { };
            languages.Add(language);
            Console.Write("Do you want to add another language? (Y/N)");

            Console.Write("Do you want to add another company? (Y/N)");
            while (true)
            {
                var result = Console.ReadLine();
                if (result.ToUpper() == "Y")
                {
                    Console.Write("Enter companies: ");
                    var newLanguage = Console.ReadLine();
                    languages.Add(newLanguage);
                    Console.Write("If you want to finish adding language press n/N: ");

                }
                else if (result.ToUpper() == "N")
                {
                    break;
                }
            }
            Console.Write("Enter work start date: ");
            string? start = Console.ReadLine();
            Console.Write("Enter work end date: ");
            var end = Console.ReadLine();
            Console.Write("Honors Diploma (Y/N): ");
            var checkDiplom = Console.ReadLine();
            bool HonorsDiploma = false;
            if (checkDiplom.ToUpper() == "Y")
            {
                HonorsDiploma = true;
            }
            Console.Write("Gitlink (Y/N): ");
            var checkGit = Console.ReadLine();
            string gitlink = null;
            if (checkGit.ToUpper() == "Y")
            {
                gitlink = Console.ReadLine();
            }
            Console.Write("Linkedin (Y/N): ");
            var checkLinkedin = Console.ReadLine();
            string linkedin = null;
            if (checkLinkedin.ToUpper() == "Y")
            {
                linkedin = Console.ReadLine();
            }
            CVc workercv = new CVc();
            CVc cV = new CVc()
            {
                Qualification = qualification,
                School = school,
                UniversityScore = university,
                Skills = skills,
                Companies = companiess,
                StartTime = $"{start}",
                EndTime = $"{end}",
                Languages = languages,
                HasHonorDiplom = HonorsDiploma,
                GitLink = gitlink,
                Linkedin = linkedin
            };
            worker.AddCv(workercv);


        }
        #endregion


        #region Worker

        static public void Worker(Workerc worker, List<Employer> employers, int index1, List<Workerc> workers)
        {
            string a = "\n\t\t\t\t\t\t";
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{a}Welcome {worker.name} {worker.surname}");
                Console.WriteLine();
                Console.WriteLine("\n1. Show cv");
                Console.WriteLine("\n2. Search vacancy");
                Console.WriteLine("\n3. Update cv");
                Console.WriteLine("\n4. Creat cv");
                Console.WriteLine("\n5. Notification");
                Console.WriteLine("\n6. Sign Out");
                Console.Write("Your choice: ");
                string cvselection = Console.ReadLine();
                if (cvselection == "1")
                {
                    if (worker.cv != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Your CV");
                        worker.ShowCv();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("You have no CV. Please create your Cv!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadKey();
                    }
                }
                else if (cvselection == "2")
                {
                    string search = String.Empty;
                    int result;
                    while (true)
                    {
                        var letter = Console.ReadKey();
                        if (letter.Key == ConsoleKey.D1 || letter.Key == ConsoleKey.D2 ||
                            letter.Key == ConsoleKey.D3 || letter.Key == ConsoleKey.D4 ||
                            letter.Key == ConsoleKey.D5 || letter.Key == ConsoleKey.D6 ||
                            letter.Key == ConsoleKey.D7 || letter.Key == ConsoleKey.D8 ||
                            letter.Key == ConsoleKey.D9)
                        {
                            var result1 = letter.Key.ToString();
                            result1 = result1.Replace('D', ' ');
                            result = int.Parse(result1);
                            break;
                        }
                        Console.Clear();
                        search += letter.KeyChar;
                        search = search.ToLower();
                        if (letter.Key == ConsoleKey.Backspace)
                        {
                            search = "";
                        }
                        Console.WriteLine(search);
                        var selectedVacancy = from e in employers
                                              from v in e.vacancies
                                              where v.Specification.ToLower().Contains(search)
                                              select v;
                        foreach (var vacancy in selectedVacancy)
                        {
                            Console.WriteLine($"{vacancy.id} - {vacancy.Specification}");
                        }
                        Console.WriteLine("\n\n");
                    }
                    Console.Clear();
                    var vacancy1 = from e in employers
                                   from v in e.vacancies
                                   where v.id == result
                                   select v;
                    Vacancyc vacancyResult = new Vacancyc();
                    foreach (var vacancy in vacancy1)
                    {
                        vacancyResult = vacancy;
                    }
                    vacancyResult.ShowVacancy();
                    Console.WriteLine("1. Apply");
                    Console.WriteLine("2. Back");
                    Console.Write("Select : ");
                    var select1 = Console.ReadLine();
                    if (select1 == "1")
                    {
                        for (int i = 0; i < employers.Count; i++)
                        {
                            for (int k = 0; k < employers[i].vacancies.Count; k++)
                            {
                                if (result == employers[i].vacancies[k].id)
                                {
                                    employers[i].Notifications.Count += 1;
                                    employers[i].Applicant.Add(worker);
                                    employers[i].vacancies.Add(vacancyResult);
                                }
                            }
                        }
                        Notificationc notification = new Notificationc();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Request sent successfully");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadKey();
                    }
                    else if (cvselection == "2") { }
                }
                else if (cvselection == "3")
                {
                    if (worker.cv != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Your CV");
                        worker.ShowCv();
                        Console.WriteLine("1. Qualification\n");
                        Console.WriteLine("2. Graduated school\n");
                        Console.WriteLine("3. University score\n");
                        Console.WriteLine("4. Skills\n");
                        Console.WriteLine("5. Companies\n");
                        Console.WriteLine("6. Language\n");
                        Console.WriteLine("7. Honor diplom\n");
                        Console.WriteLine("8. GitLink\n");
                        Console.WriteLine("9. Linkedin\n");
                        Console.WriteLine("10. Exit\n");
                        Console.Write("Your chice: ");
                        var select1 = Console.ReadLine();
                        if (select1 == "1")
                        {
                            Console.Write("Enter new speciality : ");
                            var newspeciality = Console.ReadLine();
                            worker.cv.Qualification = newspeciality;
                            workers[index1].cv.Qualification = newspeciality;
                        }
                        else if (select1 == "2")
                        {
                            Console.Write("Enter new school : ");
                            var newSchool = Console.ReadLine();
                            worker.cv.School = newSchool;
                            workers[index1].cv.School = newSchool;
                        }
                        else if (select1 == "3")
                        {
                            Console.Write("Enter new university : ");
                            var newUniScr = Console.ReadLine();
                            worker.cv.UniversityScore = newUniScr;
                            workers[index1].cv.UniversityScore = newUniScr;
                        }
                        else if (select1 == "4")
                        {
                            Console.Write("Add or uptade? (1/2) : ");
                            var choice = Console.ReadLine();
                            if (choice == "1")
                            {
                                Console.Write("Enter skill : ");
                                var skill = Console.ReadLine();
                                worker.cv.Skills.Add(skill);
                                workers[index1].cv.Skills.Add(skill);
                                Console.Write("Do you want to add a new skill? (Y/N)");
                                while (true)
                                {
                                    var skillupdate = Console.ReadLine();
                                    if (skillupdate.ToUpper() == "Y")
                                    {
                                        Console.Write("Enter skill : ");
                                        var newSkill = Console.ReadLine();
                                        worker.cv.Skills.Add(newSkill);
                                        workers[index1].cv.Skills.Add(newSkill);
                                    }
                                    else if (skillupdate.ToUpper() == "N")
                                    {
                                        break;
                                    }
                                }
                            }
                            else if (choice == "2")
                            {
                                bool flag = true;
                                while (flag)
                                {
                                    Console.Clear();
                                    worker.cv.Skills.ForEach(s => Console.WriteLine($"Skill : {s}"));
                                    Console.Write("Enter skill name : ");
                                    var skill = Console.ReadLine();
                                    foreach (var skill1 in worker.cv.Skills)
                                    {
                                        if (skill == skill1)
                                        {
                                            Console.Write("Enter new skill name : ");
                                            var result = Console.ReadLine();
                                            var index = worker.cv.Skills.IndexOf(skill1);
                                            worker.cv.Skills[index] = result;
                                            workers[index1].cv.Skills[index] = result;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("Succesfully!!! ");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Thread.Sleep(1000);
                                            flag = false;
                                            break;
                                        }
                                    }
                                    if (flag)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Skill not found!!");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Thread.Sleep(1000);
                                    }
                                }
                            }
                        }
                        else if (select1 == "5")
                        {
                            Console.Write("Add or uptade? (1/2) : ");
                            var CvUpdatechoice = Console.ReadLine();
                            if (CvUpdatechoice == "1")
                            {
                                Console.Write("Enter companies : ");
                                var companies = Console.ReadLine();
                                worker.cv.Companies.Add(companies);
                                workers[index1].cv.Companies.Add(companies);
                                Console.Write("Do you want to add a new company? (Y/N)");
                                while (true)
                                {
                                    var result = Console.ReadLine();
                                    if (result.ToUpper() == "Y")
                                    {
                                        Console.Write("Enter companies : ");
                                        var companies1 = Console.ReadLine();
                                        worker.cv.Companies.Add(companies1);
                                        workers[index1].cv.Companies.Add(companies1);
                                    }
                                    else if (result.ToUpper() == "N")
                                    {
                                        break;
                                    }
                                }
                            }
                            else if (CvUpdatechoice == "2")
                            {
                                bool flag = true;
                                while (flag)
                                {
                                    Console.Clear();
                                    worker.cv.Companies.ForEach(c => Console.WriteLine($"Companies: {c}"));
                                    Console.Write("Enter companies name: ");
                                    var companies = Console.ReadLine();
                                    foreach (var companies1 in worker.cv.Companies)
                                    {
                                        if (companies == companies1)
                                        {
                                            Console.Write("Enter new companies name : ");
                                            var result = Console.ReadLine();
                                            var index = worker.cv.Companies.IndexOf(companies1);
                                            worker.cv.Companies[index] = result;
                                            workers[index1].cv.Companies[index] = result;
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.Write("Succesfully!!!");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Thread.Sleep(900);
                                            flag = false;
                                            break;
                                        }
                                    }
                                    if (flag)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Companies not found!!");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Thread.Sleep(900);
                                    }
                                }
                            }
                        }
                        else if (select1 == "6")
                        {
                            Console.Write("Add or uptade? (1/2) : ");
                            var langChoice = Console.ReadLine();
                            if (langChoice == "1")
                            {
                                Console.Write("Enter language: ");
                                var language = Console.ReadLine();
                                worker.cv.Languages.Add(language);
                                workers[index1].cv.Languages.Add(language);
                                Console.Write("Do you want to add a new language? (Y/N)");
                                while (true)
                                {
                                    var addlang = Console.ReadLine();
                                    if (addlang.ToUpper() == "Y")
                                    {
                                        Console.Write("Enter language : ");
                                        var newLang = Console.ReadLine();
                                        worker.cv.Languages.Add(newLang);
                                        workers[index1].cv.Languages.Add(newLang);
                                    }
                                    else if (addlang.ToUpper() == "N")
                                    {
                                        break;
                                    }
                                }
                            }
                            else if (langChoice == "2")
                            {
                                bool flag = true;
                                while (flag)
                                {
                                    Console.Clear();
                                    worker.cv.Languages.ForEach(s => Console.WriteLine($"Language : {s}"));
                                    Console.Write("Enter language: ");
                                    var language = Console.ReadLine();
                                    foreach (var language1 in worker.cv.Languages)
                                    {
                                        if (language == language1)
                                        {
                                            Console.Write("Enter new language name : ");
                                            var result = Console.ReadLine();
                                            var index = worker.cv.Languages.IndexOf(language1);
                                            worker.cv.Languages[index] = result;
                                            workers[index1].cv.Languages[index] = result;
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.Write("Succesfully!!! ");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Thread.Sleep(900);
                                            flag = false;
                                            break;
                                        }
                                    }
                                    if (flag)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Language not found!!");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Thread.Sleep(900);
                                    }
                                }
                            }
                        }
                        else if (select1 == "7")
                        {
                            if (worker.cv.HasHonorDiplom == false)
                            {
                                Console.Write("Do you want to add an honor diplom? (Y/N) ");
                                var honordiplomch = Console.ReadLine();
                                if (honordiplomch.ToUpper() == "Y")
                                {
                                    worker.cv.HasHonorDiplom = true;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("Succesfully!!! ");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Thread.Sleep(900);
                                }
                                else if (honordiplomch.ToUpper() == "N") { }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have a diploma of distinction");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Thread.Sleep(900);
                            }
                        }
                        else if (select1 == "8")
                        {
                            if (worker.cv.GitLink == null)
                            {
                                Console.Write("Enter gitlink: ");
                                var githublink = Console.ReadLine();
                                worker.cv.GitLink = githublink;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Succesfully!!! ");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Thread.Sleep(900);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have a github link");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Thread.Sleep(900);
                            }
                        }
                        else if (select1 == "9")
                        {
                            if (worker.cv.Linkedin == null)
                            {
                                Console.Write("Enter linkedin link : ");
                                var linkedin = Console.ReadLine();
                                worker.cv.Linkedin = linkedin;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Succesfully!!! ");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Thread.Sleep(900);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have a linkedin");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Thread.Sleep(900);
                            }
                        }
                        else if (select1 == "10")
                        {
                            Worker(worker, employers, index1, workers);
                        }

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("You have no CV. Please create your Cv !");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(900);
                    }
                }
                else if (cvselection == "4")
                {
                    if (worker.cv == null)
                    {
                        CreatCv(worker, workers, index1);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("You already have a CV !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(900);
                    }
                }
                else if (cvselection == "5")
                {
                    if (worker.Applicant.Count != 0)
                    {
                        worker.Applicant.ForEach(shempl => shempl.ShowEmployer());
                        worker.ApplicantVacancy.ForEach(shvac => shvac.ShowVacancy());
                        Console.WriteLine(worker.Notification.NotificationContent);
                        Console.ReadKey();
                        worker.Applicant.Clear();
                        worker.ApplicantVacancy.Clear();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There is no information.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(900);
                    }
                }
                else if (cvselection == "6")
                {
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid select !");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(900);
                }

            }
        }

        #endregion


        #region Employer

        static public void Employer(Employer employer, List<Employer> employers)
        {
            string a = "\n\t\t\t";
            string?[] EmpmenuOptions = new string[] { "\n\t\t 1. Show vacancy/s   ", "\n\t\t 2. Add vacancy   ", "\n\t\t 3. Update vacancy   ", "\n\t\t 4. Exit   " };
            int EmpmenuSelect = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{a}Welcome {employer.name} {employer.surname}");

                for (int i = 0; i < EmpmenuOptions.Length; i++)
                {
                    Console.WriteLine((i == EmpmenuSelect ? " " : "") + EmpmenuOptions[i] + (i == EmpmenuSelect ? "<--" : ""));
                }

                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && EmpmenuSelect != EmpmenuOptions.Length - 1)
                {
                    EmpmenuSelect++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && EmpmenuSelect >= 1)
                {
                    EmpmenuSelect--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (EmpmenuSelect)
                    {
                        case 0:

                            if (employer.vacancies.Count != 0)
                            {
                                employer.vacancies.ForEach(v => v.ShowVacancy());
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have not vacancy!!");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                            break;
                        case 1:
                            Console.WriteLine();
                            Console.Write("Specification: ");
                            var speciality = Console.ReadLine();

                            Console.WriteLine();
                            Console.Write("Salary: ");
                            var salary = double.Parse(Console.ReadLine());

                            Console.WriteLine();
                            Console.Write("Experience year: ");
                            var experienceYear = int.Parse(Console.ReadLine());

                            Vacancyc v1 = new Vacancyc(speciality, salary, experienceYear);
                            employer.vacancies.Add(v1);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Added succesfully!!!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case 2:
                            employer.vacancies.ForEach(v => v.ShowVacancy());
                            Console.Write("Enter vacancy id: ");
                            var id = int.Parse(Console.ReadLine());
                            var vacancy = employer.GetVacancyById(id);
                            if (vacancy != null)
                            {
                                Console.WriteLine("1. Speciality\n");
                                Console.WriteLine("2. Salary\n");
                                Console.WriteLine("3. Experience year\n");
                                Console.Write("Select: ");
                                var updatech = Console.ReadLine();
                                if (updatech == "1")
                                {
                                    Console.WriteLine();
                                    Console.Write("Enter new speciality: ");
                                    var newSpecification = Console.ReadLine();
                                    vacancy.Specification = newSpecification;
                                }
                                else if (updatech == "2")
                                {
                                    Console.WriteLine();
                                    Console.Write("Enetr new salary: ");
                                    var newSalary = double.Parse(Console.ReadLine());
                                    vacancy.Salary = newSalary;

                                }
                                else if (updatech == "3")
                                {
                                    Console.WriteLine();
                                    Console.Write("Enter new experience year: ");
                                    var newExperienceYear = int.Parse(Console.ReadLine());
                                    vacancy.Experience = newExperienceYear;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("Invalid select!!!");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.ReadKey();
                                }

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("Vacancy not found!!!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Begin();
                            break;
                    }
                }

            }
        }
        #endregion


        static public void Begin()
        {
            List<Workerc> workers = new List<Workerc>();
            Workerc worker1 = new Workerc(
                "Baris",
                "Akarsu",
                "Baris_",
                "123Baris",
                25,
                "Istanbul",
                "0557132456");
            Workerc worker2 = new Workerc(
                "John",
                "Doe",
                "John_doe",
                "JD1357",
                29,
                "Canada",
                "0708080791");
            Workerc worker3 = new Workerc(
                "Aysu",
                "Qenberli",
                "Aysu_mammadova",
                "ayandsu",
                20,
                "Baku",
                "0503935567");
            worker1.AddCv(new CVc()
            {
                Qualification = "C# Developer",
                School = "244",
                UniversityScore = "BSU",
                Skills = new List<string> { "C#", "CSS", "HTML" },
                Companies = new List<string> { "Socar" },
                StartTime = " 20 / 05 / 2017 ",
                EndTime = " 10 / 10 / 2019 ",
                Languages = new List<string> { "English", "French" },
                HasHonorDiplom = false,
                GitLink = "github.com/1Baris3"
            });

            string jsonW1 = Newtonsoft.Json.JsonConvert.SerializeObject(worker1);
            File.WriteAllText($"{worker3.name}.json", jsonW1);

            string jsonW2 = Newtonsoft.Json.JsonConvert.SerializeObject(worker2);
            File.WriteAllText($"{worker3.name}.json", jsonW2);

            string jsonW3 = Newtonsoft.Json.JsonConvert.SerializeObject(worker3);
            File.WriteAllText($"{worker3.name}.json", jsonW3);


            workers.Add(worker1);
            workers.Add(worker2);
            workers.Add(worker3);


            List<Employer> employers = new List<Employer>();
            Employer empl1 = new Employer(
                "nigar.m",
                "123niqa",
                "Nigar",
                "Mustafazada",
                45,
                "Baku",
                "0708095641");
            Employer empl2 = new Employer(
                "mammadova",
                "ay2ten",
                "Ayten",
                "Mammadova",
                21,
                "Baku",
                "+994555555555");
            empl1.vacancies.Add(new Vacancyc("Senior C# Developer", 7000, 4));
            empl2.vacancies.Add(new Vacancyc("Java Developer", 5000, 2));

            string jsonE1 = Newtonsoft.Json.JsonConvert.SerializeObject(empl1);
            File.WriteAllText($"{empl1.name}.json", jsonE1);

            string jsonE2 = Newtonsoft.Json.JsonConvert.SerializeObject(empl2);
            File.WriteAllText($"{empl2.name}.json", jsonE2);


            employers.Add(empl1);
            employers.Add(empl2);

            while (true)
            {
                Console.CursorVisible = false;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t::::::::    ::::::::::   ::::::::::   ::::::::::              :::          :::::::::       ");
                Console.WriteLine("\t\t\t::     ::   ::      ::   ::      ::   ::      ::             :: ::               ::        ");
                Console.WriteLine("\t\t\t::     ::   ::      ::   ::           ::                    ::   ::             ::         ");
                Console.WriteLine("\t\t\t::::::::    ::      ::   ::::::::::   ::::::::::           :::::::::           ::          ");
                Console.WriteLine("\t\t\t::     ::   ::      ::           ::           ::          ::       ::         ::           ");
                Console.WriteLine("\t\t\t::     ::   ::      ::           ::           ::         ::         ::      ::             ");
                Console.WriteLine("\t\t\t::::::::    ::::::::::   ::::::::::   ::::::::::   ::   ::           ::    ::::::::::      ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(1700);


                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t1. Login ");
                    Console.WriteLine("\n\t\t2. SignUp ");
                    Console.Write("\n\tSelect : ");
                    string choice = Console.ReadLine();
                    Workerc worker = null;
                    int wIndex = 0;
                    Employer employer = null;
                    int eIndex = 0;
                    if (choice == "1")
                    {
                        Console.Clear();
                        Console.Write("\n\n*******Enter username : ");
                        string username = Console.ReadLine();
                        Console.Write("\n*******Enter password : ");
                        string password = Console.ReadLine();
                        for (int i = 0; i < workers.Count; i++)
                        {
                            if (username == workers[i].username && password == workers[i].password)
                            {
                                worker = workers[i];
                                wIndex = i;
                            }
                        }
                        for (int i = 0; i < employers.Count; i++)
                        {
                            if (username == employers[i].username && password == employers[i].password)
                            {
                                employer = employers[i];
                                eIndex = i;
                            }
                        }
                        if (worker != null)
                        {
                            Worker(worker, employers, wIndex, workers);
                        }
                        else if (employer != null)
                        {
                            Employer(employer, employers);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t\t\tUser not found. Please try again !");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.ReadKey();
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t\t1. Worker");
                        Console.WriteLine("\n\t\t2. Employer");
                        var select1 = Console.ReadLine();
                        if (select1 == "1")
                        {
                            Console.Clear();
                            Console.Write("Name: ");
                            var name = Console.ReadLine();
                            Console.Write("Surname: ");
                            var surname = Console.ReadLine();
                            Console.Write("Age: ");
                            var age = int.Parse(Console.ReadLine());
                            Console.Write("City: ");
                            var city = Console.ReadLine();
                            Console.Write("Phone number: ");
                            var phone = Console.ReadLine();
                            Console.Write("Create username: ");
                            var username = Console.ReadLine();
                            Console.Write("Create password: ");
                            var password = Console.ReadLine();
                            Workerc newWorker = new Workerc(name, surname, username, password, age, city, phone);
                            Console.WriteLine("Do you want add CV? (Y/N) ");
                            string jsonNewWorker = Newtonsoft.Json.JsonConvert.SerializeObject(newWorker);
                            File.WriteAllText($"{newWorker.name}.json", jsonNewWorker);
                            var choise1 = Console.ReadLine();

                            if (choise1.ToUpper() == "Y")
                            {
                                CreatCv(newWorker, workers, wIndex);

                            }
                            else
                            {

                                Console.WriteLine();
                            }
                            workers.Add(newWorker);

                        }
                        else if (select1 == "2")
                        {
                            Console.Write("Name: ");
                            var name = Console.ReadLine();
                            Console.Write("Surname: ");
                            var surname = Console.ReadLine();
                            Console.Write("Age: ");
                            var age = int.Parse(Console.ReadLine());
                            Console.Write("City: ");
                            var city = Console.ReadLine();
                            Console.Write("Phone number: ");
                            var phone = Console.ReadLine();
                            Console.Write("Create username: ");
                            var username = Console.ReadLine();
                            Console.Write("Create password: ");
                            var password = Console.ReadLine();
                            Employer newEmployer = new Employer(username, password, name, surname, age, city, phone);
                            string jsonNewEmpl = Newtonsoft.Json.JsonConvert.SerializeObject(newEmployer);
                            File.WriteAllText($"{newEmployer.name}.json", jsonNewEmpl);
                            employers.Add(newEmployer);

                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("User added succesfully!!! ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadKey();
                    }
                    Thread.Sleep(1700);
                }
            }
        }
    }
}
