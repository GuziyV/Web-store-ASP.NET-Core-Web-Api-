using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contexts
{
    public enum OrderStatus {
        Pending = 0,
        Declined = 1,
        Payed = 2,
		Basket
    }
}
