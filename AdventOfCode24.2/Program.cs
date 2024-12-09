//var reports = File.ReadLines("input.txt");

//int safeReports = 0;
// Part 1
//foreach (var report in reports)
//{
//    var levels = report
//        .Split(' ')
//        .Select(x=> int.Parse(x))
//        .ToList();


//    var increasing = false;
//    var decreasing = false;

//    var previousLevel = 0;
//    var firstElement = true;
//    foreach (var currentLevel in levels)
//    {
//        if (firstElement)
//        {
//            previousLevel = currentLevel;

//            increasing = currentLevel < levels[1];
//            decreasing = !increasing;
//            firstElement = false;
//            continue;
//        }

//        if (increasing)
//        {
//            if ((currentLevel > previousLevel) == false) // Sagt aus, dass es sich nicht erhöht
//            {
//                break;
//            }

//            var difference = currentLevel - previousLevel;

//            if ((difference >= 1 &&  difference <= 3) == false)
//            {
//                break;
//            }

//            if (levels.IndexOf(currentLevel) == levels.Count -1)
//            {
//                safeReports++;
//                break;

//            }

//            previousLevel = currentLevel;
//            continue;
//        }

//        if (decreasing)
//        {
//            if ((currentLevel < previousLevel) == false)
//            {
//                break;
//            }

//            var difference = previousLevel - currentLevel;

//            if ((difference >= 1 && difference <= 3) == false)
//            {
//                break;
//            }

//            if (levels.IndexOf(currentLevel) == levels.Count - 1)
//            {
//                safeReports++;
//                break;

//            }

//            previousLevel = currentLevel;
//            continue;
//        }


//    }
//}

// Part 2


var reports = File.ReadLines("input.txt");

int safeReports = 0;

const int badReportTolerance = 1;

foreach (var report in reports)
{
    var levels = report
        .Split(' ')
        .Select(x => int.Parse(x))
        .ToList();

    for (int i = 0; i < levels.Count; i++)
    {
        var copyList = levels.ToList();
        copyList.RemoveAt(i);

        if (isValidReport(copyList))
        {
            safeReports++;
            break;
        }
    }



}

Console.WriteLine();


bool isValidReport(List<int> levels)
{
    var allIncreasing = OnlyIncreasing(levels);
    var allDecreasing = OnlyDecreasing(levels);

    if (allIncreasing == false &&  allDecreasing == false)
        return false;

    var prevLevel = levels[0];

    for (int i = 1; i < levels.Count; i++)
    {
        var diff = 0;
        var currentLevel = levels[i];

        if (allIncreasing)
        {
            diff = currentLevel - prevLevel;
        }

        if (allDecreasing)
        {
            diff = prevLevel - currentLevel;
        }

        if (!(diff >= 1 && diff <= 3))
        {
            return false;
        }

        prevLevel = currentLevel;

    }
    return true;
}

bool OnlyIncreasing(List<int> levels)
{
    var level = levels.First();

    for (int i = 1; i < levels.Count; i++)
    {
        if (level >= levels[i])
        {
            return false;
        }

        level = levels[i];
    }

    return true;
}

bool OnlyDecreasing(List<int> levels)
{
    var level = levels.First();

    for (int i = 1; i < levels.Count; i++)
    {
        if (level <= levels[i])
        {
            return false;
        }

        level = levels[i];
    }

    return true;
}