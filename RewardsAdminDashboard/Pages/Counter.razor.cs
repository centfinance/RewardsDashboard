using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RewardsAdminDashboard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Telerik.Blazor.Components;

namespace RewardsAdminDashboard.Pages
{
    public partial class Counter
    {
        public List<RewardsAdminDashboard.Data.RewardsDto> Rewards { get; set; }

        protected override void OnInitialized()
        {
            LoadRewards();
        }

        private void LoadRewards()
        {
            using (var db = new RewardsContext())
            {
                Rewards = db.Rewards
                    .Where(b => b.Address == "")
                    .OrderBy(b => b.RewardDate)
                    .ToList();
            }
        }


        public class ModelData
        {
            public double Series1 { get; set; }
            public double Series2 { get; set; }
            public double Series3 { get; set; }
        }

        public string[] Categories = new string[] { "Week 1", "Week 2", "Week 3", "Week 4", "Week 5", "Week 6", "Week 7", "Week 8", "Week 9", "Week 10" };

        public object[] AxisCrossingValue = new object[] { -10 };


        public List<ModelData> Data = new List<ModelData>()
        {
            new ModelData()
            {
                Series1 = 3.907,
                Series2 = 1.988,
                Series3 = 0.253
            },
            new ModelData()
            {
                Series1 = 7.943,
                Series2 = 2.733,
                Series3 = 0.362
            },
            new ModelData()
            {
                Series1 = 7.848,
                Series2 = 3.994,
                Series3 = 3.519
            },
            new ModelData()
            {
                Series1 = 9.284,
                Series2 = 3.464,
                Series3 = 1.799
            },
            new ModelData()
            {
                Series1 = 9.263,
                Series2 = 4.001,
                Series3 = 2.252
            },
            new ModelData()
            {
                Series1 = 9.801,
                Series2 = 3.939,
                Series3 = 3.343
            },
            new ModelData()
            {
                Series1 = 3.89,
                Series2 = 1.333,
                Series3 = 0.843
            },
            new ModelData()
            {
                Series1 = 8.238,
                Series2 = 2.245,
                Series3 = 2.877
            },
            new ModelData()
            {
                Series1 = 9.552,
                Series2 = 4.339,
                Series3 = 5.416
            },
            new ModelData()
            {
                Series1 = 6.855,
                Series2 = 2.727,
                Series3 = 5.59
            }
        };




        public class PieChartModelData
        {
            public string Source { get; set; }
            public int Percentage { get; set; }
            public bool Explode { get; set; }
        }

        public List<PieChartModelData> PieData = new List<PieChartModelData>()
        {
            new PieChartModelData()
            {
                Source = "SYMM/CELO",
                Percentage = 22,
                Explode = true
            },
            new PieChartModelData()
            {
                Source = "SYMM/CUSD",
                Percentage = 2,
                Explode = false
            },
            new PieChartModelData()
            {
                Source = "SYMM/CEUR",
                Percentage = 49,
                Explode = false
            },
            new PieChartModelData()
            {
                Source = "CELO/WBTC",
                Percentage = 27,
                Explode = false
            }
        };
    }
}
