using System;
using Modul_2_Task_3.Helpers;
using Modul_2_Task_3.Model;
using Modul_2_Task_3.Services;

namespace Modul_2_Task_3
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
                try
                {
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
                }
                catch (BusinessException e)
                {
                    _logger.LogWarning($"Action failed by a reason: {e}");
                }
                catch (Exception e)
                {
                    _logger.LogError($"Action failed by a reason: {e}");
                }
            }
        }
    }
}
