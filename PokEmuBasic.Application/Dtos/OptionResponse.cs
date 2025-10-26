using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos
{
    public class OptionResponse
    {
        public virtual int Value { get; set; }
        public virtual string Name { get; set; } = default!;
    }
}
