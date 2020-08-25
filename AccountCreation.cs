using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountCreation
{
    class AccountCreation
    {
        static string getItem(string prompt)
        {
            ConsoleKey conf = ConsoleKey.N;
            string user_name = "temp";

            while (conf != ConsoleKey.Y || conf != ConsoleKey.N)
            {
                if (conf == ConsoleKey.Y)
                {
                    return user_name;
                }
                else if (conf == ConsoleKey.N)
                {
                    Console.Clear();
                    Console.Write("What is your {0}: ", prompt);
                    user_name = Console.ReadLine();
                    Console.WriteLine("Does this look right?: \"{0}\"", user_name);
                    Console.Write("[Y/N]: ");
                    conf = Console.ReadKey().Key;
                    Console.WriteLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Does this look right?: \"{0}\"", user_name);
                    Console.Write("[Y/N]: ");
                    conf = Console.ReadKey().Key;
                    Console.WriteLine();
                }
            }

            return user_name;
        }

        static void login(List<User> user_list)
        {
            Console.Clear();

            string current_prompt;
            int list_index = 0;
            StringBuilder password = new StringBuilder();
            ConsoleKey key = ConsoleKey.N;

            Console.Write("Username: ");
            current_prompt = Console.ReadLine();

            for(int i = 0; i < user_list.Count; i++)
            {
                if (user_list[i].getUsername().Equals(current_prompt))
                {
                    Console.WriteLine("Username successful");
                    list_index = i;
                }
                else
                {
                    Console.WriteLine("No matching Username.");
                    Console.ReadKey();
                    return;
                }
            }

            Console.Clear();

            while (true)
            {
                if(key == ConsoleKey.Enter)
                {
                    break;
                }
                else
                {
                    key = Console.ReadKey().Key;
                    if(key != ConsoleKey.Backspace)
                    {
                        password.Append(key.ToString());
                    }
                    else
                    {

                    }

                }
            }

            Console.WriteLine(password.ToString());
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.Clear();

            User base_user = new User();
            List<User> user_list = new List<User>();
            string[] choices = { "Create new Account", "Login to Account" };
            
            base_user.changePassword("Slicer4101");
            base_user.changeUsername("SRGTxTwinkie");
            user_list.Add(base_user);

            int choice;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("What do you want to do?");
                
                for(int i = 0; i < choices.Length; i++)
                {
                    Console.WriteLine("{0}: {1} ", i + 1 , choices[i]);
                }

                Console.Write("Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        User new_user = new User();
                        Console.Clear();
                        new_user.changeUsername(getItem("Username"));
                        Console.Clear();
                        new_user.changePassword(getItem("Password"));
                        user_list.Add(new_user);
                        Console.Clear();
                        break;
                    case 2:
                        login(user_list);
                        break;
                    default:
                        Console.WriteLine("Case defaulted, shouldn't be able to happen");
                        break;
                }
                GC.Collect();
            }

        }
    }
}

class User
{
    private string username;
    private string password;

    public void changeUsername(string new_username)
    {
        username = new_username;
    }

    public void changePassword(string new_password)
    {
        password = new_password;
    }

    public string getUsername()
    {
        return username;
    }

    public string getPassword()
    {
        return password;
    }
}
 