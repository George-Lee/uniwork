using System;

namespace TableBill
{
    class TableBill
    {
        class TableBill
        {
            int table;
            TableOrder Order = new TableOrder;

            public TableBill(int table, TableOrder tableOrder = new TableOrder)
            {
                if(table > 0)
                {
                    table = table;
                }

                if(tableOrder != Null)
                {
                    Order = tableOrder;
                }
            }

        }
    }
}
