using System;

namespace Modul_2_Task_3.Model
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        {
        }
    }
}
