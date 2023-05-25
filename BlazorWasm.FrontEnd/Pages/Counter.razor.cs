using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace BlazorWasmServer.Client.Pages
{

    public partial class Counter
    {

        private int currentCount = 0;

        private void IncrementCount()
        {

            var array = new double[] { 1, 2, 3, 4, 5 };
            var max = array.Maximum();
            var min = array.Minimum();

            Console.WriteLine($"Max: {max }");
            currentCount+=12;
        }
    }
}
