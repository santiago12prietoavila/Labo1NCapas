﻿using DAL;
using Entities.Models;
using System.Linq.Expressions;

//CreateAsync().GetAwaiter().GetResult();
//RetreiveAsync().GetAwaiter().GetResult();
updateAsync().GetAwaiter().GetResult();

Console.ReadKey();  
static async Task CreateAsync()
{
    //Add Customer
    Customer customer = new Customer()
    {
        FirstName = "Santiago",
        LastName = "Avila",
        City = "Bogotá",
        Country = "Colombia",
        Phone = "3125594627"

    };

    using (var repository = RepositoryFactory.CreateRepository())
    {
        try
        {
            var createdCustomer = await repository.CreateAsync(customer);
            Console.WriteLine($"Added Customer: {createdCustomer.FirstName} {createdCustomer.LastName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error {ex.Message}");
        }


    }

}

static async Task RetreiveAsync()
{
    using (var repository = RepositoryFactory.CreateRepository())
    {
        try
        {
            Expression<Func<Customer, bool>> criteria = c => c.FirstName == "Santiago" && c.LastName == "Avila";
            var customer = await repository.RetreiveAsync(criteria);
            if (customer != null)
            {
                Console.WriteLine($"Retrived customer: {customer.FirstName} \t{customer.LastName}\t City: {customer.City}\t Country: {customer.Country}");
            }
            Console.WriteLine($"Customer not exist");
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

static async Task updateAsync()
{
    //Supuesto; Existe el objeto a modificar
    using (var repository = RepositoryFactory.CreateRepository())
    {
        var customerYoUpdate = await repository.RetreiveAsync<Customer>(c => c.Id == 78);

        if (customerYoUpdate != null)
        {
            customerYoUpdate.FirstName = "Liu";
            customerYoUpdate.LastName = "Wong";
            customerYoUpdate.City = "Toronto";
            customerYoUpdate.Country = "Canada";
            customerYoUpdate.Phone = "+14337 6353039";
        }
        try
        {
            bool update = await repository.UpdateAsync(customerYoUpdate);
            if (update)
            {
                Console.WriteLine("Customer update succesfully.");
            }
            else
            {
                Console.WriteLine("Customer update failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error:{ex.Message}");
        }
    }

}
