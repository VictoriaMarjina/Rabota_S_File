
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Rabota_S_File
{
    public class Program
    {
        static ArrayList list = new ArrayList();
        
        public static void Main()
        {
            AddClientBase();
            Switch();
            Console.ReadKey();
        }

        public static void Switch()
        {
            Console.WriteLine("нажмите 1 чтобы получить информацию о всех клиентах");
            Console.WriteLine("нажмите 2 чтобы получить информацию о конкретном клиенте");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    PrintInfoStu(list);
                    Switch();
                    break;
                case "2":
                    FindClient(list);
                    Switch();
                    break;
                default:
                    break;
            }
        }
        static bool CheckNum(string a)
        {
            if (decimal.TryParse(a, out decimal b))
                return true;
            else
                return false;
        }
        static bool CheckStr(string a)
        {
            char[] ch = new char[] { 'A', 'Z', 'E','0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
           
                    if (a[0] != ch[0] && a[1] != ch[1] && a[2] != ch[2])
                    {
                        return false;
                    }
                        
            for (int i = 3; i <a.Length; i++)
            {
                char ch1 = a[i];
                int indexOfChar = Array.IndexOf(ch, ch1);

                if (indexOfChar != -1 && indexOfChar >2)//ok
                {
                    continue;
                }
                else if (indexOfChar == -1 || indexOfChar == 0 ||indexOfChar == 1 || indexOfChar == 2)//mistake
                {
                    return false;
                }

            }
            return true;
        }
        static string CheckName()
        {
            string name = Console.ReadLine();
            char[] eng = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] big_eng = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] rus = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ', 'э', 'ю', 'я' };
            char[] big_rus = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 'Я' };
            char first = name[0];
            int j = 0;
            for (int i = 0; i < big_eng.Length; i++)

            {
                if (first == big_eng[i])
                {
                    j++;

                    break;
                }

            }

            if (j == 0)
            {
                for (int i = 0; i < big_rus.Length; i++)

                {
                    if (first == big_rus[i])
                    {
                        j++;

                        break;
                    }

                }

            }

            if (j == 0)
            {
                Console.WriteLine(j);
                Console.WriteLine("Введите правильные данные");
                CheckName();
                return name;
            }
            else// j=1;
            {

                for (int k = 1; k < name.Length; k++)
                {
                    char second = name[k];
                    for (int i = 0; i < eng.Length; i++)

                    {

                        if (name[k] == eng[i])
                        {
                            j++;

                            break;
                        }
                    }
                }
                for (int k = 1; k < name.Length; k++)
                {
                    char second = name[k];
                    for (int i = 0; i < rus.Length; i++)

                    {

                        if (name[k] == rus[i])
                        {
                            j++;

                            break;
                        }
                    }
                }
            }
            if (j != name.Length)
            {
                Console.WriteLine(j);
                Console.WriteLine("Введите правильные данные");
                CheckName();
                return name;
            }
            else
            {
                return name;
            }

        }
        static string CheckLastName()
        {
            string lastname = Console.ReadLine();
            char[] eng = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] big_eng = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] rus = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ', 'э', 'ю', 'я' };
            char[] big_rus = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 'Я' };
            char first = lastname[0];
            int j = 0;
            for (int i = 0; i < big_eng.Length; i++)

            {
                if (first == big_eng[i])
                {
                    j++;

                    break;
                }

            }

            if (j == 0)
            {
                for (int i = 0; i < big_rus.Length; i++)

                {
                    if (first == big_rus[i])
                    {
                        j++;

                        break;
                    }

                }

            }

            if (j == 0)
            {
                Console.WriteLine("Введите правильные данные");
                CheckName();
                return lastname;
            }
            else// j=1;

            {

                for (int k = 1; k < lastname.Length; k++)
                {
                    char second = lastname[k];
                    for (int i = 0; i < eng.Length; i++)

                    {

                        if (lastname[k] == eng[i])
                        {
                            j++;

                            break;
                        }


                    }
                }
                for (int k = 1; k < lastname.Length; k++)
                {
                    char second = lastname[k];
                    for (int i = 0; i < rus.Length; i++)

                    {

                        if (lastname[k] == rus[i])
                        {
                            j++;

                            break;
                        }

                    }
                }
            }
            if (j != lastname.Length)
            {
                Console.WriteLine("Введите правильные данные");
                CheckName();
                return lastname;
            }
            else
            {
                return lastname;
            }

        }
        static decimal InNum()
        {
            for (; ; )
            {
                string a = Console.ReadLine();
                bool b = CheckNum(a);
                if (b == true)
                {
                    decimal c = Convert.ToDecimal(a);
                    return c;
                }
                else
                    Console.WriteLine("не коректные данные повторите ввод");
            }
        }
        static string InStr()
        {
            for (; ; )
            {
                string a = Console.ReadLine();
                bool b = CheckStr(a);
                if (b == true)
                    return a;
                else
                    Console.Write("не коректные данные повторите ввод:\t");
            }
        }
      
        public static void AddClientBase()
        {
            string path = @"C:\Users\Vika\Desktop\Rabota_S_File\Rabota_S_File\ClientBase.txt";
            string newPath = @"C:\Users\Vika\Desktop\Rabota_S_File\Rabota_S_File\NewBase\ClientBase.txt";
            FileInfo fileInf = new FileInfo(path);
            try
            {
                File.Copy(path, newPath, true);
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex);
            }

            try
            {

                using (StreamReader sr = new StreamReader(newPath, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        /* Console.WriteLine(line);*/
                        CheckInfo(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        
        public static void CheckInfo(string line)
        {
            string[] info = new string[5];
            for (int i = 0; i < 5; i++)
            {
                char ch = ';';
                int indexOfChar = line.IndexOf(ch);
                string line1 = line.Substring(0, indexOfChar);
                /*Console.WriteLine(line1);*/
                info[i] = line1;
    
                line = line.Substring(indexOfChar + 1);
               /* Console.WriteLine(line);*/
            }
            Client client = new Client();
            client.Name = info[1];
            client.Lastname = info[0];
            client.Id = Convert.ToDecimal(info[2]);
            client.Passport = info[3];
            client.Balance = Convert.ToDecimal(info[4]);

            list.Add(client);
        }
        public static ArrayList AddClient(ArrayList list)
        {
            Client client = new Client();
            Console.WriteLine("Введите имя клиента");
            client.Name = CheckName();
            Console.WriteLine("Введите фамилию клиента");
            client.Lastname = CheckLastName();
            Console.WriteLine("Введите ID клиента");
            client.Id = InNum();
            Console.WriteLine("Введите серию паспорта клиента (AZE*******)");
            client.Passport = InStr();
            Console.WriteLine("Введите сумму на счету клиента");
            client.Balance = InNum();
            list.Add(client);
            Client.PrintInfo(client);
            
            string writePath = @"C:\Users\Vika\Desktop\Rabota_S_File\Rabota_S_File\NewBase\ClientBase.txt";
            string text = $"{client.Lastname};{client.Name};{client.Id};{client.Passport};{client.Balance};";

            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
                Console.WriteLine("Клиент добавлен в базу");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Switch();
            return list;
        }

        public static void PrintInfoStu(ArrayList list)
        {
            for (int i = 0; i < list.Count; i++)
            {

                Client client = (Client)list[i];

                Client.PrintInfo(client);

            }
        
            
        }

        public static void FindClient(ArrayList list)
        {
            Console.WriteLine("Введите Id клиента");

            decimal check = InNum();

            for (int i = 0; i < list.Count; i++)
            {
          
                Client client = (Client)list[i];

                if (client.Id == check)
                {
                    Client.PrintInfo(client);
                    Console.WriteLine("чтобы  изменить сумму на счету клиента нажмите 1");
                    Console.WriteLine("чтобы выйти в меню нажмите любую цифру");
                    decimal a = InNum();
                    if (a == 1)
                    {
                        NewSum(client);
                 
                    }
                    else
                    {
                        Switch();

                    }

                }
                else if (client.Id != check && i != list.Count-1)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Клиент с таким ID отсутствует в базе данных");
                    Console.WriteLine("чтобы добавить клиента в список нажмите 1");
                    Console.WriteLine("чтобы выйти в меню нажмите любую другую цифру");
                    decimal a = InNum();
                    if (a == 1)
                    {
                        AddClient(list);

                    }
                    else
                    {
                        Switch();

                    }

                }

            }
           
        }
        public static void NewSum(Client client)
        {
            Console.WriteLine("Введите новое значение баланса");
            decimal newbalance = InNum();
            client.Balance = newbalance;
            
            Client.PrintInfo(client);
            NewData();
            Switch();
        }
        public static void NewData()
        {
            for (int i = 0; i < list.Count; i++)
            {

                Client client = (Client)list[i];

                string clientdata = $"{client.Lastname};{client.Name};{client.Id};{client.Passport};{client.Balance};";
                string writePath = @"C:\Users\Vika\Desktop\Rabota_S_File\Rabota_S_File\NewBase\ClientBase.txt";
                try{
                    if (i == 0)
                    {
                        using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(clientdata);
                        }
                    }

                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(clientdata);
                        
                    }
                    Console.WriteLine("База данных обновлена");
                    Switch();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }


    }
   

    public abstract class People
    {
        public string Name { get; set; }
        public string Lastname { get; set; }

        public People()
        {

        }

        public People(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
        }

    }
    public class Client : People
    {
        private decimal id;
        public decimal Id { get; set; }
        private string passport;
        public string Passport { get; set; }
        public decimal Balance { get; set; }

       

        public Client() { }

        public Client(string name, string lastname, decimal id, string passport, decimal balance) : base(name, lastname)
        {

            Id = id;
            Passport = passport;
            Balance = balance;

        }


        public static void PrintInfo(Client client)
        {
            Console.WriteLine($" Имя и фамилия клиента: {client.Name} {client.Lastname} \n Индентификационный номер: {client.Id} \n Серия и номер пааспорта: {client.Passport}\n Сумма на счету: {client.Balance}");
            Console.WriteLine("\n");
        }

    }
 

}
