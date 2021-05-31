using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using d01_ex00;
using d01_ex00.Models;

string sum;
string ratesDirectory;
double doubleSum;
string currencyFromInput;

if (args.Length != 2)
{
    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
    return ;
}

sum = args[0];
ratesDirectory = args[1];
if (sum == "" || ratesDirectory == "")
{
    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
    return ;
}

var indexSpace = sum.IndexOf(' ');
if (indexSpace == -1)
{
    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
    return ;
}

var sumFromInput = sum.Substring(0, indexSpace);
currencyFromInput = sum.Substring(indexSpace + 1);
if (double.TryParse(sumFromInput, out doubleSum) == false)
{
    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
    return ;
}

var arrayList = new List<ExchangeRate>();
if (Directory.Exists(ratesDirectory) == false)
{
    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
    return ;
}

var massivOfPaths = Directory.GetFiles(ratesDirectory);

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ru-RU");

foreach (var elem in massivOfPaths)
{
    var reader = new StreamReader(elem);
    string line = null;
    var currencyFromFileName = Path.GetFileNameWithoutExtension(elem);
    while ((line = reader.ReadLine()) != null)
    {
        var indexDoubleDot = line.IndexOf(':');
        if (indexDoubleDot == -1)
        {
            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
            return ;
        }
        var currencyFromFile = line.Substring(0, indexDoubleDot);
        var rateFromFile = line.Substring(indexDoubleDot + 1);
        double doubleRateFromFile;
        if (Double.TryParse(rateFromFile, out doubleRateFromFile) == false)
        {
            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
            return ;
        }

        arrayList.Add(new ExchangeRate(currencyFromFileName, currencyFromFile, doubleRateFromFile));
    }

    reader.Close();
}

var exchanger = new Exchanger(arrayList);
var convertSum = exchanger.Exchange(currencyFromInput, doubleSum);

if (convertSum.Count == 0)
{
    Console.WriteLine("Не найдено данных в файле валют.");
    return ;
}

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

Console.WriteLine($"Сумма в исходной валюте: {doubleSum:F2} {currencyFromInput}");
foreach (var iterator in convertSum)
{
    Console.WriteLine(iterator);
}