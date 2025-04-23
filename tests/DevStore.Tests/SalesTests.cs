using DevStore.Domain.Entities;
using Xunit;
public class SalesTests
{
    [Fact] public void Discount10(){var i=new SaleItem(Guid.NewGuid(),"P",4,100);Assert.Equal(360,i.Total);}
    [Fact] public void Discount20(){var i=new SaleItem(Guid.NewGuid(),"P",10,50);Assert.Equal(400,i.Total);}
    [Fact] public void Limit(){Assert.Throws<ArgumentException>(()=>new SaleItem(Guid.NewGuid(),"P",21,10));}
}
