using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInventory.Testables
{
    public interface IGreatWallService
    {
        int MyIntProperty { get; set; }

        string MyStringProperty { get; set; }

        List<int> MyListProperty { get; set; }

        void Init();

        int Process(int num);
    }

    public class GreatWallClass
    {
        private readonly IGreatWallService _service;

        public GreatWallClass(IGreatWallService service)
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
            catch
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
            catch
            {
                returnVal = false;
            }

            return returnVal;
        }

        public int GetMyIntProperty()
        {
            return _service.MyIntProperty;
        }

        public string GetMyStringProperty()
        {
            return _service.MyStringProperty;
        }

        public List<int> GetMyListProperty()
        {
            return _service.MyListProperty;
        }

        public void Process()
        {
            _service.Process(10);
        }
    }
}
