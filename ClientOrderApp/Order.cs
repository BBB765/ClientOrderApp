using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Order
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public string Product { get; set; }
    public DateTime OrderDate { get; set; }
    public double Amount { get; set; }
}
