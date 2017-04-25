using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInventory.Domain
{
    public interface IWangService
    {
        int MyIntProperty { get; set; }
        void Init();

        int Process(int num);
    }
    public class ForTestClass
    {
        private readonly IWangService _service;

        public ForTestClass(IWangService service)
        {
            _service = service;
        }

        public bool Setup()
        {
            var returnVal = false;
            try
            {
                _service.Init();
                returnVal = true;
            }
            catch (Exception e)
            {
                returnVal = false;
            }
            return returnVal;
        }

        public bool SetupTwice()
        {
            var returnVal = false;
            try
            {
                _service.Init();
                _service.Init();
                returnVal = true;
            }
            catch (Exception e)
            {
                returnVal = false;
            }
            return returnVal;
        }

        public int GetMyIntProperty()
        {
            return _service.MyIntProperty;
        }

        public void Process()
        {
            _service.Process(10);
        }
    }
}
