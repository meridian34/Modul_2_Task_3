namespace Modul_2_Task_1
{
    public class Actions
    {
        private readonly Logger _logger = Logger.Instance;

        public Result Create()
        {
            _logger.LogInfo($"Start method: {nameof(Create)}");
            return new Result() { Status = true };
        }

        public Result Update()
        {
            _logger.LogWarning($"Skipped logic in method: {nameof(Update)}");
            return new Result() { Status = true };
        }

        public Result Remove()
        {
            return new Result() { Status = false, ErrorMessage = "I broke a logic" };
        }
    }
}
