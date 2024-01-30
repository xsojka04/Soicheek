using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soicheek.BL.ViewModels
{
    public abstract class ViewModelBase : IViewModel
    {
        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != this.GetType())
                return false;
            return this.GetHashCode() == obj.GetHashCode();
        }

        public abstract override int GetHashCode();
    }
}
