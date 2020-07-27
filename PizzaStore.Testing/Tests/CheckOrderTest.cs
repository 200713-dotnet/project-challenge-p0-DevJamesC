using System;
using Xunit;
using PizzaStore.Client;

namespace PizzaStore.Testing
{
    public class CheckOrderTest
    {
        [Fact]
        public void CheckDisplayEntryText()
        {
            var sut = new PizzaStore.Client.MenuManager();

            //action
            string output =sut.DisplayEntryTextT();

            //assert

            Assert.True(output!=null);
        }
    }
}
