using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public interface IConfigReader
    {
        void Process();
    }

    public class ConfigReader : IConfigReader
    {
        private readonly string _configName;
        private readonly bool _isFiltered;

        public ConfigReader(string configName,bool isFiltered)
        {
            this._configName = configName;
            this._isFiltered = isFiltered;
        }
        public void Process()
        {
            Console.WriteLine($"Process config. configName:{this._configName};isFilter={this._isFiltered.ToString()}");
        }
    }
}
