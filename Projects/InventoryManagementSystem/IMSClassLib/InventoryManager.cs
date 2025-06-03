using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSClassLib
{
    public class InventoryManager
    {
        public int CheckStockStatus(int quantity)
        {
            if (quantity < 10)
            {
                return -1;
            } 
            else if (quantity >= 10 &&  quantity <= 20)
            {
                return 0;
            } 
            else
            {
                return 1;
            }
        }
    }
}
