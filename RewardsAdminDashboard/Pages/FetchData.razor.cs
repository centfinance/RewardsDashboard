using Microsoft.JSInterop;
using RewardsAdminDashboard.Data;
using System.Text;
using System.Text.Json;

namespace RewardsAdminDashboard.Pages
{
    public class CombinedReward
    {
        public string Address { get; set; }

        public Single Amount { get; set; }
    }


    public partial class FetchData
    {
        public List<RewardsAdminDashboard.Data.RewardsDto> Rewards { get; set; }

        protected override void OnInitialized()
        {
            LoadRewards();
        }

        private DateTime rangeStart = DateTime.Now;
        private DateTime rangeEnd = DateTime.Now;

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

        private async Task DownloadCSVFromStreamCelo()
        {
            StringBuilder results = new StringBuilder();

            foreach (var record in GetRewardsSubset(42220))
            {
                results.Append(record.Address).Append(",").Append(record.Amount.ToString()).Append(Environment.NewLine);
            }
            byte[] buffer = Encoding.UTF8.GetBytes(results.ToString());
            var fileStream = new MemoryStream(buffer);

            var fileName = $"rewards{DateTime.Now}.csv";

            using var streamRef = new DotNetStreamReference(stream: fileStream);

            await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
        }

        private async Task DownloadJSONFromStreamCelo()
        {
            var fileName = $"rewards{DateTime.Now}.json";

            var json = JsonSerializer.Serialize(GetRewardsSubset(42220).Select(reward => new
            {
                reward.Address,
                reward.Amount
            }));

            byte[] buffer = Encoding.UTF8.GetBytes(json.ToString());
            var fileStream = new MemoryStream(buffer);

            using var streamRef = new DotNetStreamReference(stream: fileStream);

            await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
        }

        private async Task DownloadCSVFromStreamGnosis()
        {
            StringBuilder results = new StringBuilder();

            foreach (var record in GetRewardsSubset(100))
            {
                results.Append(record.Address).Append(",").Append(record.Amount.ToString()).Append(Environment.NewLine);
            }
            byte[] buffer = Encoding.UTF8.GetBytes(results.ToString());
            var fileStream = new MemoryStream(buffer);

            var fileName = $"rewards{DateTime.Now}.csv";

            using var streamRef = new DotNetStreamReference(stream: fileStream);

            await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
        }

        private async Task DownloadJSONFromStreamGnosis()
        {
            var fileName = $"rewards{DateTime.Now}.json";

            var json = JsonSerializer.Serialize(GetRewardsSubset(100).Select(reward => new
            {
                reward.Address,
                reward.Amount
            }));

            byte[] buffer = Encoding.UTF8.GetBytes(json.ToString());
            var fileStream = new MemoryStream(buffer);

            using var streamRef = new DotNetStreamReference(stream: fileStream);

            await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
        }

        private List<CombinedReward> GetRewardsSubset(int chainId)
        {
            using (var db = new RewardsContext())
            {
                var uniqueWallets = db.Rewards.Where(p => p.ChainId == chainId)
                                              .Select(rewardAddress => new
                                              {
                                                  rewardAddress.Address
                                              }).Distinct().ToList();

                List<CombinedReward> combinedReward = new();

                foreach (var wallet in uniqueWallets)
                {
                    var thisReward = new CombinedReward();
                    
                    var totalAmount = db.Rewards
                        .Where(b => b.Amount > 0 && b.RewardDate >= rangeStart && b.RewardDate <= rangeEnd && b.Address == wallet.Address)
                        .Sum(lt => lt.Amount);

                    thisReward.Address = wallet.Address;
                    thisReward.Amount = totalAmount;

                    combinedReward.Add(thisReward);
                }

                return combinedReward;
            }
        }
    }
}
