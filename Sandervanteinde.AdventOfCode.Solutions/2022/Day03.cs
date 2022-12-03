﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandervanteinde.AdventOfCode.Solutions._2022;
internal class Day03 : BaseSolution
{
    public Day03()
        : base("Rucksack Reorganization", 2022, 3)
    {
            
    }

    public override object DetermineStepOneResult(FileReader reader)
    {
        var sum = 0;
        foreach(var line in reader.ReadAsSpanLineByLine())
        {
            var firstPArt = line[..(line.Length / 2)];
            var secondPart = line[(line.Length / 2)..];
            var matchingIndex = secondPart.IndexOfAny(firstPArt);
            var matchingLetter = secondPart[matchingIndex];
            sum += ValueOfChar(matchingLetter);

        }
        return sum;
    }

    public override object DetermineStepTwoResult(FileReader reader)
    {
        ReadOnlySpan<char> first, second, third;
        var enumerator = reader.ReadAsSpanLineByLine();
        var sum = 0;

        while (enumerator.MoveNext())
        {
            first = enumerator.Current;
            enumerator.MoveNext();
            second = enumerator.Current;
            enumerator.MoveNext();
            third = enumerator.Current;

            foreach(var c in first)
            {
                if(second.Contains(c) && third.Contains(c))
                {
                    sum += ValueOfChar(c);
                    break;
                }
            }
        }

        return sum;
    }
    private static int ValueOfChar(char c) => c switch
    {
        >= 'a' and <= 'z' => ((int)c) - 96,
        >= 'A' and <= 'Z' => ((int)c) - 38
    };
}
