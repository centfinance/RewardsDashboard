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
    public partial class Index
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
                    .Where(b => b.Amount > 0)
                    .OrderBy(b => b.RewardDate)
                    .ToList();
            }
        }
    }
}
