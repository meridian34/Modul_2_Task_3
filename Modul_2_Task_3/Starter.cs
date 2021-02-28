using System;
using System.IO;

namespace Modul_2_Task_1
{
    public class Starter
    {
        private readonly int _minRandomValue = 1;
        private readonly int _maxRandomValue = 4;
        private readonly Random _random = new Random();
        private readonly Actions _actions = new Actions();
        private readonly Logger _logger = Logger.Instance;
        private Result _result;

        public void Run()
        {
            for (var i = 0; i < 100; i++)
            {
                var rnd = _random.Next(_minRandomValue, _maxRandomValue);
                switch (rnd)
                {
                    case 1:
                        _result = _actions.Create();
                        break;
                    case 2:
                        _result = _actions.Update();
                        break;
                    case 3:
                        _result = _actions.Remove();
                        break;
                }

                if (!_result.Status)
                {
                    _logger.LogError($"Action failed by a reason: {_result.ErrorMessage}");
                }
            }

            File.WriteAllText("log.txt", _logger.GetLogs());
        }
    }
}
