using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Transaction
{

    public Transaction(int PlayerId, int CompanyId, int TotalStocks)
    {
        this.PlayerId = PlayerId;
        this.CompanyId = CompanyId;
        this.TotalStocks = TotalStocks;


    }
    public int PlayerId { get; set; }
    public int CompanyId { get; set; }
    public int TotalStocks { get; set; }
}
