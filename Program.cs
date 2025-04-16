// See https://aka.ms/new-console-template for more information
using System.Globalization;
using modul8_103022300158;

class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig config = BankTransferConfig.ReadConfigFile();
        bool checkLanguage = config.lang.ToLower() switch
        {
            "en" => true,
            "id" => false,
            _ => true
        };

        Console.WriteLine("Current Language: " + (checkLanguage ? "English" : "Indonesian"));
    }
}