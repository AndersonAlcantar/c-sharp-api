using Back_end.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Back_end.Repositories
{
    public class CustomerDataBaseContext: DbContext
    {
        public CustomerDataBaseContext(DbContextOptions<CustomerDataBaseContext> options) : base(options)
        {

        }
        public DbSet<CustomerEntity> Customers { get; set; }

        public async Task<CustomerEntity> Get(long id)
        {
            return await Customers.FirstAsync(x => x.id == id);
        }

        public async Task<CustomerEntity> Add(CreateCustomerDto createCustomer)
        {
            CustomerEntity entity = new CustomerEntity()
            {
                id = null,
                firstname = createCustomer.name,
                lastname = createCustomer.lastName,
                phone = createCustomer.phone,
                email = createCustomer.email,
                address = createCustomer.address,   
            };
            EntityEntry<CustomerEntity> response = await Customers.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.id ?? throw new Exception("No se ha podido guardar"));
        }
    }

    public class CustomerEntity
    {
        public long? id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public CustomerDto ToDto()
        {
            return new CustomerDto()
            {
                address = address,
                email = email,
                firstname = firstname,
                lastname = lastname,
                phone = phone,
                id = id ?? throw new Exception("El id no puede ser nulo")
            };
        }
    }
}
