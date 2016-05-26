using System.Collections.Generic;
using System.Linq;

using StructureMapIntro.Plugins;
using StructureMapIntro.Repositories;

namespace StructureMapIntro.Services
{
    public class MyService : IMyService
    {
      private readonly IMyRepository _repository;
      private readonly IList<IMyPlugin> _plugins; 

      public MyService(IMyRepository repository, IEnumerable<IMyPlugin> plugins)
      {
        _repository = repository;
        _plugins = plugins.ToList();
      }

      public IMyRepository MyRepository { get; set; }

      public IList<IMyPlugin> Plugins
      {
        get
        {
          return _plugins;
        }
      }

      public override string ToString()
      {
        return string.Format("{0}.{1}", _repository, MyRepository);
      }
    }
}
