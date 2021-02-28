using System;
using Modul_2_Task_3.Model;
using Modul_2_Task_3.Services;

namespace Modul_2_Task_3.Helpers
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
            throw new Exception($"Skipped logic in method: {nameof(Update)}");
        }

        public Result Remove()
        {
            throw new BusinessException($"I broke a logic: {nameof(Remove)}");
        }
    }
}
