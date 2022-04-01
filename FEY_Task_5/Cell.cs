using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_5
{
    enum CellType
    {
        WALL,
        EMPTY,
    }
    internal class Cell
    {
        public Vector Position;
        public CellType Type { get; private set; }
        public char Symbol { get; set; }
        public List<Object> Contains { get; private set;}
        public Cell(CellType type, char symbol, Vector pos)
        {
            Contains = new List<Object>();
            Type = type;
            Symbol = symbol;
            Position = pos;
        }
        public Cell()
        {

        }
        public void AddObject(Object obj)
        {
            Contains.Add(obj);
        }
        
    }
}
