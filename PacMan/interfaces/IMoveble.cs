using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.enums;

namespace PacMan.interfaces
{
    public interface IMoveble
    {
        public void Move(Direction direction);
    }
}
