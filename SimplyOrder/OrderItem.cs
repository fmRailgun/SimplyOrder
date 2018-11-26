using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyOrder
{
    class OrderItem{
        public Food Food { set; get; }
        public int Count { set; get; }
        public double Price { set; get; }
        public string Name { set; get; }

        public OrderItem(Food food) {
            this.Food = food;
            this.Count = 1;
            this.Price = Food.Price;
            this.Name = Food.Name;

            for (int i=1; i<Food.RequiredCustom.Length; i++) {
                ReqCustom curr = Food.RequiredCustom[i];
                this.Name += curr.Options[curr.Selected].Name;
            }
            for (int i = 1; i < Food.OptionalCustom.Length; i++) {
                foreach (Option option in Food.OptionalCustom[i].Options) {
                    if(option.Selected){
                        this.Name += option.Name; 
                    }
                }
            }
        }

        public double CalculatePrice() {
            return this.Count * this.Price;
        }
    }
}
