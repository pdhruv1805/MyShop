﻿using MyShhop.Core.Contracts;
using MyShhop.Core.Models;
using MyShhop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShhop.Services
{
    public class OrderService: IOrderService
    {
        private IRepository<Order> orderContext;

        public OrderService(IRepository<Order> OrderContext)
        {
            this.orderContext = OrderContext;
        }
        public void CreateOrder(Order baseOrder,List<BasketItemViewModel> basketItems)
        {
            foreach(var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    Image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                });
            }

            orderContext.Insert(baseOrder);
            orderContext.Commit();

        }

        
    }
}
