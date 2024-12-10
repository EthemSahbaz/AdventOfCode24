using System.Text.RegularExpressions;

var input = File.ReadAllText("input.txt");

var foundIndex = 0;
var searchString = "mul";
var startIndex = 3;
var subString = input;
var total = 0;

while (true)
{
    foundIndex = subString.IndexOf(searchString);
    var found = true;
    var iteratorIndex = 0;


    if (foundIndex == -1)
        break;

    subString = subString.Substring(foundIndex+ startIndex);

    var validResult = IsValid(subString);
    if (validResult.isValid)
    {
        total = total + validResult.value;
    }

    subString = subString.Substring(1);


}

Console.WriteLine($"Total: {total}");

Console.WriteLine();

(bool isValid,int value) IsValid(string subString)
{
    string firstNumberString = string.Empty;
    string secondNumberString = string.Empty;
    
    if (subString[0] != '(')
        return (false, 0);

    var open = subString.IndexOf("(") + 1;

    var comma = subString.IndexOf(',') - 1;

    if (!(comma >=1 && comma <= 3) ||
        comma == -1)
        return (false, 0);

    firstNumberString = subString.Substring(open, comma);


    var indexWithoutComma = comma + 2;

    var split = subString.Substring(indexWithoutComma);

    var close = split.IndexOf(")");

    if (!(close >= 1 && close <= 3) ||
        close == -1)
        return (false, 0);

    secondNumberString = split.Substring(0, close);

    Console.WriteLine($"{firstNumberString} | {secondNumberString}");
    var multResult = int.Parse(firstNumberString) * int.Parse(secondNumberString);
    
    return (true,  multResult);

}