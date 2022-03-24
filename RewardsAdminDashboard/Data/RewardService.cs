namespace RewardsAdminDashboard.Data
{
    public class RewardService
    {
        private readonly RewardsContext _dbContext;

        private List<RewardsDto> _rewards;

        public RewardService(RewardsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<RewardsDto> GetRewards()
        {
            return GetRewardsInternal();
        }

        private IEnumerable<RewardsDto> GetRewardsInternal()
        {
            
            if (_dbContext == null)
            {
                _rewards = _dbContext.Rewards.Where(p => p.Amount > 0).ToList();
            }

            return _rewards;
        }
    }
}
